// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using FeedManager.Task2.Feeds;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FeedManager.Task2.FeedValidators
{
    public class Delta1FeedValidator : IFeedValidator<Delta1Feed>
    {
        private readonly FeedValidator feedValidator = new FeedValidator();

        public ValidateResult Validate(Delta1Feed feed)
        {
            var tradeFeedResult = feedValidator.Validate(feed);

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