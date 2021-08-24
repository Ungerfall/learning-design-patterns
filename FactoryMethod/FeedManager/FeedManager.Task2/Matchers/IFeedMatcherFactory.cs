using FeedManager.Task2.Feeds;
using System;

namespace FeedManager.Task2.Matchers
{
    public interface IFeedMatcherFactory
    {
        IFeedMatcher<T> CreateFeedMatcher<T>() where T : TradeFeed;
    }

    public class FeedMatcherFactory : IFeedMatcherFactory
    {
        public IFeedMatcher<T> CreateFeedMatcher<T>() where T : TradeFeed
        {
            if (typeof(T) == typeof(Delta1Feed))
                return (IFeedMatcher<T>)new Delta1FeedMatcher();
            if (typeof(T) == typeof(EmFeed))
                return (IFeedMatcher<T>)new EmFeedMatcher();

            throw new Exception("Unknown parameter type");
        }
    }
}