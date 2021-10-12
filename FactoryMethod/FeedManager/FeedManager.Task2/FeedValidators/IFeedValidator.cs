// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using FeedManager.Task2.Feeds;

namespace FeedManager.Task2.FeedValidators
{
    public interface IFeedValidator<in T>
        where T: TradeFeed
    {
        ValidateResult Validate(T feed);
    }
}
