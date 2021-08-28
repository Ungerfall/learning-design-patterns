using FeedManager.Task2.Database;
using FeedManager.Task2.Feeds;
using FeedManager.Task2.FeedValidators;
using FeedManager.Task2.Matchers;
using System.Collections.Generic;

namespace FeedManager.Task2.Importers
{
    public abstract class FeedImporter
    {
        private readonly IDatabaseRepository database;

        protected FeedImporter(IDatabaseRepository database)
        {
            this.database = database;
        }

        public void Import<T>(IEnumerable<T> feeds) where T : TradeFeed
        {
            var validator = CreateFeedValidator<T>();
            var matcher = CreateFeedMatcher<T>();
            var existingFeeds = database.LoadFeeds<T>();
            foreach (var feed in feeds)
            {
                var validation = validator.Validate(feed);
                if (!validation.IsValid)
                {
                    database.SaveErrors(feed.StagingId, validation.Errors);
                    continue;
                }

                if (!existingFeeds.Exists(x => matcher.Match(x, feed)))
                {
                    database.SaveFeed(feed);
                }
            }
        }

        protected abstract IFeedValidator<T> CreateFeedValidator<T>() where T : TradeFeed;
        protected abstract IFeedMatcher<T> CreateFeedMatcher<T>() where T : TradeFeed;
    }
}