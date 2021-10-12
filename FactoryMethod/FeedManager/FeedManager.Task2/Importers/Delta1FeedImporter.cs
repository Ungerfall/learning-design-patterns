// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using FeedManager.Task2.Database;
using FeedManager.Task2.FeedValidators;
using FeedManager.Task2.Matchers;

namespace FeedManager.Task2.Importers
{
    public class Delta1FeedImporter : FeedImporter
    {
        public Delta1FeedImporter(IDatabaseRepository database) : base(database)
        {
        }

        protected override IFeedValidator<T> CreateFeedValidator<T>()
        {
            return (IFeedValidator<T>)new Delta1FeedValidator();
        }

        protected override IFeedMatcher<T> CreateFeedMatcher<T>()
        {
            return (IFeedMatcher<T>)new Delta1FeedMatcher();
        }
    }
}