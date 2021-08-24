using FeedManager.Task2.Feeds;

namespace FeedManager.Task2.Matchers
{
    public class Delta1FeedMatcher : IFeedMatcher<Delta1Feed>
    {
        public bool Match(Delta1Feed current, Delta1Feed other)
        {
            return current.CounterpartyId == other.CounterpartyId
                   && current.PrincipalId == other.PrincipalId;
        }
    }
}