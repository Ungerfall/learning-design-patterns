using FeedManager.Task1.Feeds;
using System.Collections.Generic;
using System.Linq;

namespace FeedManager.Task1.FeedValidators
{
    public abstract class FeedValidator
    {
        public ValidateResult Validate(TradeFeed feed)
        {
            var errors = new List<string>();
            if (feed.StagingId < 1 || feed.CounterpartyId < 1 || feed.PrincipalId < 1 || feed.SourceAccountId < 1)
            {
                errors.Add(ErrorCode.IdIsNotValidMessage);
            }

            if (feed.CurrentPrice < 0 || FeedValidatorUtils.GetNumberOfDecimalPlaces(feed.CurrentPrice) != 2)
            {
                errors.Add(ErrorCode.PriceIsNotValid);
            }

            return errors.Any()
                ? new ValidateResult { Errors = errors, IsValid = false }
                : new ValidateResult { IsValid = true };
        }
    }
}