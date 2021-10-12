// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using FeedManager.Task2.Feeds;
using FeedManager.Task2.Matchers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeedManager.Task2.Tests
{
    [TestClass]
    public class Delta1FeedMatcherTests
    {
        private Delta1FeedMatcher feedMatcher;

        public Delta1FeedMatcherTests()
        {
            feedMatcher = new Delta1FeedMatcher();
        }

        [TestMethod]
        public void Should_match_two_delta_1_feeds()
        {
            var feed1 = new Delta1Feed
            {
                CounterpartyId = 10,
                PrincipalId = 13
            };

            var feed2 = new Delta1Feed
            {
                CounterpartyId = 10,
                PrincipalId = 13
            };

            feedMatcher.Match(feed1, feed2).Should().BeTrue();
        }

        [TestMethod]
        public void Should_not_match_two_delta_1_feeds()
        {
            var feed1 = new Delta1Feed
            {
                CounterpartyId = 11,
                PrincipalId = 13
            };

            var feed2 = new Delta1Feed
            {
                CounterpartyId = 10,
                PrincipalId = 12
            };

            feedMatcher.Match(feed1, feed2).Should().BeFalse();
        }
    }
}
