using FeedManager.Task1.Feeds;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static FeedManager.Task1.FeedValidators.FeedValidatorUtils;

namespace FeedManager.Task1.FeedValidators
{
    public class Delta1FeedValidator : IFeedValidator<Delta1Feed>
    {
        public ValidateResult Validate(Delta1Feed feed)
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

            if (!IsIsinValid(feed.Isin))
            {
                errors.Add(ErrorCode.NotValidIsin);
            }

            if (feed.MaturityDate <= feed.ValuationDate)
            {
                errors.Add(ErrorCode.NotValidMaturityDate);
            }

            if (errors.Any())
            {
                return new ValidateResult { Errors = errors, IsValid = false };
            }

            return new ValidateResult { IsValid = true };
        }

        private static bool IsIsinValid(string isin)
        {
            const string pattern = @"^[A-Z]{2}\d{10}$";
            return Regex.IsMatch(isin, pattern, RegexOptions.Compiled);
        }
    }
}