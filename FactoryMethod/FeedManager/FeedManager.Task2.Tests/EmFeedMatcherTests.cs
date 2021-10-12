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
    public class EmFeedMatcherTests
    {
        private EmFeedMatcher feedMatcher;

        public EmFeedMatcherTests()
        {
            feedMatcher = new EmFeedMatcher();
        }

        [TestMethod]
        public void Should_match_two_em_feeds_by_source_account_id()
        {
            var feed1 = new EmFeed
            {
                SourceAccountId = 15
            };

            var feed2 = new EmFeed
            {
                SourceAccountId = 15
            };

            feedMatcher.Match(feed1, feed2).Should().BeTrue();
        }

        [TestMethod]
        public void Should_match_two_em_feeds_by_staging_id()
        {
            var feed1 = new EmFeed
            {
                SourceAccountId = 15,
                StagingId = 1
            };

            var feed2 = new EmFeed
            {
                SourceAccountId = 16,
                StagingId = 1
            };

            feedMatcher.Match(feed1, feed2).Should().BeTrue();
        }

        [TestMethod]
        public void Should_not_match_two_em_feeds()
        {
            var feed1 = new EmFeed
            {
                SourceAccountId = 15,
                StagingId = 1
            };

            var feed2 = new EmFeed
            {
                SourceAccountId = 16,
                StagingId = 2
            };

            feedMatcher.Match(feed1, feed2).Should().BeFalse();
        }
    }
}
