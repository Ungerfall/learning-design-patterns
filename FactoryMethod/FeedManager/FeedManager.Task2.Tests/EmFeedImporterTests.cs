// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using FeedManager.Task2.Feeds;
using FeedManager.Task2.Importers;
using FeedManager.Task2.Matchers;
using FeedManager.Task2.Tests.Database;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace FeedManager.Task2.Tests
{
    [TestClass]
    public class EmFeedImporterTests
    {
        private FakeDatabaseRepository repository;
        private EmFeedImporter feedImporter;

        public EmFeedImporterTests()
        {
            repository = new FakeDatabaseRepository();
            feedImporter = new EmFeedImporter(repository);
        }

        [TestMethod]
        public void Should_save_error_for_invalid_feed()
        {
            var feed = GetInvalidFeed();
            feedImporter.Import(new[] { feed });

            var errors = repository.GetErrors(feed.StagingId);
            errors.Should().NotBeEmpty();
        }

        [TestMethod]
        public void Should_save_valid_feed()
        {
            var feed = CreateValidFeed();
            feedImporter.Import(new[] { feed });

            var savedFeeds = repository.LoadFeeds<EmFeed>();

            savedFeeds.Should().NotBeEmpty();
            savedFeeds.Count.Should().Be(1);
            savedFeeds.First().Should().BeEquivalentTo(feed);
        }

        [TestMethod]
        public void Should_not_save_duplicated_feed()
        {
            var feed = CreateValidFeed();
            feedImporter.Import(new[] { feed });

            var copy = GetDuplicateFeed(feed);
            feedImporter.Import(new[] { copy });

            var savedFeeds = repository.LoadFeeds<EmFeed>();

            savedFeeds.Should().NotBeEmpty();
            savedFeeds.Count.Should().Be(1);
            savedFeeds.First().Should().BeEquivalentTo(feed);
        }

        [TestMethod]
        public void Should_save_not_duplicated_feed()
        {
            var feed = CreateValidFeed();
            feedImporter.Import(new[] { feed });

            var copy = GetDifferentFeed(feed);
            feedImporter.Import(new[] { copy });

            var savedFeeds = repository.LoadFeeds<EmFeed>();

            savedFeeds.Should().NotBeEmpty();
            savedFeeds.Count.Should().Be(2);
            savedFeeds.Should().BeEquivalentTo(new[] { feed, copy });
        }

        [TestCleanup()]
        public void Cleanup()
        {
            repository.Clean();
        }

        private EmFeed GetDuplicateFeed(EmFeed feed)
        {
            var newFeed = CreateValidFeed();

            newFeed.SourceAccountId = feed.SourceAccountId;
            newFeed.StagingId = feed.StagingId;
            newFeed.CurrentPrice = 45M;

            return newFeed;
        }

        private EmFeed GetDifferentFeed(EmFeed feed)
        {
            var newFeed = CreateValidFeed();

            newFeed.SourceAccountId = feed.SourceAccountId + 1;
            newFeed.StagingId = feed.StagingId + 1;

            return newFeed;
        }
        
        private EmFeed GetInvalidFeed()
        {
            var feed = CreateValidFeed();
            feed.CounterpartyId = -1;
            return feed;
        }

        private EmFeed CreateValidFeed()
        {
            return new EmFeed
            {
                CounterpartyId = 10,
                SourceAccountId = 11,
                StagingId = 12,
                PrincipalId = 13,
                CurrentPrice = 12.34M,
                Sedol = 50M,
                AssetValue = 10M,
                SourceTradeRef = "ref",
                ValuationDate = DateTime.Now
            };
        }
    }
}
