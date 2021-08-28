using FeedManager.Task2.Database;
using FeedManager.Task2.FeedValidators;
using FeedManager.Task2.Matchers;

namespace FeedManager.Task2.Importers
{
    public class Delta1FeedImporter : FeedImporter
    {
        public Delta1FeedImporter(IDatabaseRepository database) : base(database)
        {
        }

        protected override IFeedValidator<T> CreateFeedValidator<T>()
        {
            return (IFeedValidator<T>)new Delta1FeedValidator();
        }

        protected override IFeedMatcher<T> CreateFeedMatcher<T>()
        {
            return (IFeedMatcher<T>)new Delta1FeedMatcher();
        }
    }
}