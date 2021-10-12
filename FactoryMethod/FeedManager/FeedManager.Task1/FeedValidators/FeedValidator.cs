// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using FeedManager.Task1.Feeds;
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