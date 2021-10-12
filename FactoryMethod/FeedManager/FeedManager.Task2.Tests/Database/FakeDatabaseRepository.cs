// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using FeedManager.Task2.Database;
using FeedManager.Task2.Feeds;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FeedManager.Task2.Tests.Database
{
    public class FakeDatabaseRepository : IDatabaseRepository
    {
        private Dictionary<Type, List<TradeFeed>> feeds;
        private Dictionary<int, List<string>> errors;

        public FakeDatabaseRepository()
        {
            this.feeds = new Dictionary<Type, List<TradeFeed>>();
            this.errors = new Dictionary<int, List<string>>();
        }

        public List<T> LoadFeeds<T>()
            where T : TradeFeed
        {
            if (!feeds.ContainsKey(typeof(T)))
            {
                return new List<T>();
            }

            return feeds[typeof(T)].Cast<T>().ToList();
        }

        public void SaveFeed<T>(T feed)
            where T : TradeFeed
        {
            if (!feeds.ContainsKey(typeof(T)))
            {
                feeds.Add(typeof(T), new List<TradeFeed>());
            }

            feeds[typeof(T)].Add(feed);
        }

        public void SaveErrors(int feedStagingId, List<String> messages)
        {
            if (!errors.ContainsKey(feedStagingId))
            {
                errors.Add(feedStagingId, new List<String>());
            }

            errors[feedStagingId].AddRange(messages);
        }

        public List<string> GetErrors(int feedStagingId)
        {
            if (!errors.ContainsKey(feedStagingId))
            {
                return new List<string>();
            }

            return errors[feedStagingId];
        }

        public void Clean()
        {
            feeds.Clear();
            errors.Clear();
        }
    }
}
