using FeedManager.Task2.Database;
using FeedManager.Task2.Feeds;
using FeedManager.Task2.FeedValidators;
using FeedManager.Task2.Matchers;
using System.Collections.Generic;

namespace FeedManager.Task2.Importers
{
    public class EmFeedImporter
    {
        private readonly IDatabaseRepository database;
        private readonly IFeedValidatorFactory validatorFactory = new FeedValidatorFactory();
        private readonly IFeedMatcherFactory matcherFactory = new FeedMatcherFactory();

        public EmFeedImporter(IDatabaseRepository database)
        {
            this.database = database;
        }

        public void Import(IEnumerable<EmFeed> feeds)
        {
            var validator = validatorFactory.CreateFeedValidator<EmFeed>();
            var matcher = matcherFactory.CreateFeedMatcher<EmFeed>();
            var existingFeeds = database.LoadFeeds<EmFeed>();

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
    }
}