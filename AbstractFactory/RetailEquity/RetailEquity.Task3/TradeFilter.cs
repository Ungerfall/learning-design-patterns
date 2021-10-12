// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using RetailEquity.Model;
using RetailEquity.Task3;
using System.Collections.Generic;

namespace RetailEquity
{
    public class TradeFilter
    {
        private readonly IBankFactoryFinder _factoryFinder;

        public TradeFilter(IBankFactoryFinder factoryFinder = null)
        {
            _factoryFinder = factoryFinder ?? new BankFactoryFinder();
        }

        public IEnumerable<Trade> FilterForBank(IEnumerable<Trade> trades, Bank bank, Country country)
        {
            var factory = _factoryFinder.Find(bank, country);
            var filter = factory.CreateTradeFilter();

            return filter.Match(trades);
        }
    }
}