using FeedManager.Task2.Feeds;
using System;

namespace FeedManager.Task2.FeedValidators
{
    public interface IFeedValidatorFactory
    {
        IFeedValidator<T> CreateFeedValidator<T>() where T : TradeFeed;
    }

    public class FeedValidatorFactory : IFeedValidatorFactory
    {
        public IFeedValidator<T> CreateFeedValidator<T>() where T : TradeFeed
        {
            if (typeof(T) == typeof(Delta1Feed))
                return (IFeedValidator<T>)new Delta1FeedValidator();
            if (typeof(T) == typeof(EmFeed))
                return (IFeedValidator<T>)new EmFeedValidator();

            throw new Exception("Unknown parameter type");
        }
    }
}