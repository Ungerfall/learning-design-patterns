using FeedManager.Task1.Feeds;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FeedManager.Task1.FeedValidators
{
    public class Delta1FeedValidator : FeedValidator, IFeedValidator<Delta1Feed>
    {
        public ValidateResult Validate(Delta1Feed feed)
        {
            var tradeFeedResult = base.Validate(feed);

            var errors = new List<string>();
            if (!IsIsinValid(feed.Isin))
            {
                errors.Add(ErrorCode.NotValidIsin);
            }

            if (feed.MaturityDate <= feed.ValuationDate)
            {
                errors.Add(ErrorCode.NotValidMaturityDate);
            }

            var result = errors.Any()
                ? new ValidateResult { Errors = errors, IsValid = false }
                : new ValidateResult { IsValid = true };

            return ValidateResult.Merge(tradeFeedResult, result);
        }

        private static bool IsIsinValid(string isin)
        {
            const string pattern = @"^[A-Z]{2}\d{10}$";
            return Regex.IsMatch(isin, pattern, RegexOptions.Compiled);
        }
    }
}