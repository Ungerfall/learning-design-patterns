using System.Collections.Generic;
using System.Linq;
using FeedManager.Task1.Feeds;
using static FeedManager.Task1.FeedValidators.FeedValidatorUtils;

namespace FeedManager.Task1.FeedValidators
{
    public class EmFeedValidator : IFeedValidator<EmFeed>
    {
        public ValidateResult Validate(EmFeed feed)
        {
            var errors = new List<string>();
            if (feed.StagingId < 1 || feed.CounterpartyId < 1 || feed.PrincipalId < 1 || feed.SourceAccountId < 1)
            {
                errors.Add(ErrorCode.IdIsNotValidMessage);
            }

            if (feed.CurrentPrice < 0 || GetNumberOfDecimalPlaces(feed.CurrentPrice) != 2)
            {
                errors.Add(ErrorCode.PriceIsNotValid);
            }

            if (feed.Sedol <= 0 || feed.Sedol >= 100)
            {
                errors.Add(ErrorCode.PropertyRangeError(nameof(feed.Sedol), 0, 100));
            } else if (feed.AssetValue <= 0 || feed.AssetValue >= feed.Sedol)
            {
                errors.Add(ErrorCode.PropertyRangeError(nameof(feed.AssetValue), 0, feed.Sedol));
            }

            if (errors.Any())
            {
                return new ValidateResult { Errors = errors, IsValid = false };
            }

            return new ValidateResult { IsValid = true };
        }
    }
}
