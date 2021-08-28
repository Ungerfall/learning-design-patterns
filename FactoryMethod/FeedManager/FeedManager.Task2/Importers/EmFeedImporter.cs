using FeedManager.Task2.Database;
using FeedManager.Task2.FeedValidators;
using FeedManager.Task2.Matchers;

namespace FeedManager.Task2.Importers
{
    public class EmFeedImporter : FeedImporter
    {
        public EmFeedImporter(IDatabaseRepository database) : base(database)
        {
        }

        protected override IFeedValidator<T> CreateFeedValidator<T>()
        {
            return (IFeedValidator<T>)new EmFeedValidator();
        }

        protected override IFeedMatcher<T> CreateFeedMatcher<T>()
        {
            return (IFeedMatcher<T>)new EmFeedMatcher();
        }
    }
}