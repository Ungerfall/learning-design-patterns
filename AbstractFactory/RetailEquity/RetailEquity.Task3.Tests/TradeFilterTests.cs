// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RetailEquity.Model;
using RetailEquity.Task3;
using System.Collections.Generic;
using System.Linq;

namespace RetailEquity.Tests
{
    [TestClass]
    public class TradeFilterTests
    {
        private TradeFilter tradeFilter;

        public TradeFilterTests()
        {
            this.tradeFilter = new TradeFilter();
        }

        [TestMethod]
        public void Should_filter_for_Bofa_bank()
        {
            var filteredTrades = this.tradeFilter.FilterForBank(AllTrades, Bank.Bofa, Country.USA);
            var expectedIds = new int[] { 9, 10, 11, 12, 13 };

            filteredTrades.Select(t => t.Id).ToArray().Should().BeEquivalentTo(expectedIds);
        }

        [TestMethod]
        public void Should_filter_for_Connacord_bank()
        {
            var filteredTrades = this.tradeFilter.FilterForBank(AllTrades, Bank.Connacord, Country.USA);
            var expectedIds = new int[] { 5, 6 };

            filteredTrades.Select(t => t.Id).ToArray().Should().BeEquivalentTo(expectedIds);
        }

        [TestMethod]
        public void Should_filter_for_Barclays_bank_in_the_USA()
        {
            var filteredTrades = this.tradeFilter.FilterForBank(AllTrades, Bank.Barclays, Country.USA);
            var expectedIds = new int[] { 12 };

            filteredTrades.Select(t => t.Id).ToArray().Should().BeEquivalentTo(expectedIds);
        }

        [TestMethod]
        public void Should_filter_for_DeutscheBank_bank()
        {
            var filteredTrades = this.tradeFilter.FilterForBank(AllTrades, Bank.DeutscheBank, Country.USA);
            var expectedIds = new int[] { 11 };

            filteredTrades.Select(t => t.Id).ToArray().Should().BeEquivalentTo(expectedIds);
        }

        [TestMethod]
        public void Should_filter_for_Barclays_bank_in_England()
        {
            var filteredTrades = this.tradeFilter.FilterForBank(AllTrades, Bank.Barclays, Country.England);
            var expectedIds = new int[] { 13 };

            filteredTrades.Select(t => t.Id).ToArray().Should().BeEquivalentTo(expectedIds);
        }

        private IEnumerable<Trade> AllTrades 
        {
            get 
            {
                return new List<Trade>
                {
                    new Trade
                    {
                        Id = 1,
                        Amount = 10,
                        Type = TradeType.Future,
                        SubType = TradeSubType.NewOption
                    },
                    new Trade
                    {
                        Id = 2,
                        Amount = 15,
                        Type = TradeType.Option,
                        SubType = TradeSubType.NewOption
                    },
                    new Trade
                    {
                        Id = 3,
                        Amount = 10,
                        Type = TradeType.Future,
                        SubType = TradeSubType.NyOption
                    },
                    new Trade
                    {
                        Id = 4,
                        Amount = 15,
                        Type = TradeType.Option,
                        SubType = TradeSubType.NyOption
                    },
                    new Trade
                    {
                        Id = 5,
                        Amount = 30,
                        Type = TradeType.Future,
                        SubType = TradeSubType.NewOption
                    },
                    new Trade
                    {
                        Id = 6,
                        Amount = 30,
                        Type = TradeType.Future,
                        SubType = TradeSubType.NyOption
                    },
                    new Trade
                    {
                        Id = 7,
                        Amount = 30,
                        Type = TradeType.Option,
                        SubType = TradeSubType.NewOption
                    },
                    new Trade
                    {
                        Id = 8,
                        Amount = 30,
                        Type = TradeType.Option,
                        SubType = TradeSubType.NyOption
                    },
                    new Trade
                    {
                        Id = 9,
                        Amount = 90,
                        Type = TradeType.Future,
                        SubType = TradeSubType.NewOption
                    },
                    new Trade
                    {
                        Id = 10,
                        Amount = 90,
                        Type = TradeType.Future,
                        SubType = TradeSubType.NyOption
                    },
                    new Trade
                    {
                        Id = 11,
                        Amount = 95,
                        Type = TradeType.Option,
                        SubType = TradeSubType.NewOption
                    },
                    new Trade
                    {
                        Id = 12,
                        Amount = 90,
                        Type = TradeType.Option,
                        SubType = TradeSubType.NyOption
                    },
                    new Trade
                    {
                        Id = 13,
                        Amount = 105,
                        Type = TradeType.Future,
                        SubType = TradeSubType.NyOption
                    }
                };
            }
        }
    }
}
