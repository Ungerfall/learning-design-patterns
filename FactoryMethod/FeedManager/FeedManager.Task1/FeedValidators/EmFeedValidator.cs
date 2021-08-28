using FeedManager.Task1.Feeds;
using System.Collections.Generic;
using System.Linq;

namespace FeedManager.Task1.FeedValidators
{
    public class EmFeedValidator : FeedValidator, IFeedValidator<EmFeed>
    {
        public ValidateResult Validate(EmFeed feed)
        {
            var tradeFeedResult = base.Validate(feed);

            var errors = new List<string>();
            if (feed.Sedol <= 0 || feed.Sedol >= 100)
            {
                errors.Add(ErrorCode.PropertyRangeError(nameof(feed.Sedol), 0, 100));
            }
            else if (feed.AssetValue <= 0 || feed.AssetValue >= feed.Sedol)
            {
                errors.Add(ErrorCode.PropertyRangeError(nameof(feed.AssetValue), 0, feed.Sedol));
            }

            var result = errors.Any()
                ? new ValidateResult { Errors = errors, IsValid = false }
                : new ValidateResult { IsValid = true };

            return ValidateResult.Merge(tradeFeedResult, result);
        }
    }
}