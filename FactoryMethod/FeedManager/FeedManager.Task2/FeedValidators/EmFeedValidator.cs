// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using FeedManager.Task2.Feeds;
using System.Collections.Generic;
using System.Linq;

namespace FeedManager.Task2.FeedValidators
{
    public class EmFeedValidator : IFeedValidator<EmFeed>
    {
        private readonly FeedValidator feedValidator = new FeedValidator();

        public ValidateResult Validate(EmFeed feed)
        {
            var tradeFeedResult = feedValidator.Validate(feed);

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