using FeedManager.Task2.Feeds;

namespace FeedManager.Task2.FeedValidators
{
    public interface IFeedValidator<T>
        where T: TradeFeed
    {
        ValidateResult Validate(T feed);
    }
}
