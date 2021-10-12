// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System.Collections.Generic;
using System.Linq;
using RetailEquity.Model;

namespace RetailEquity.Filters
{
    public class DeutscheBankFilter : IFilter
    {
        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            const int amountMin = 90;
            const int amountMax = 120;
            return trades.Where(x =>
                x.Type == TradeType.Option
                && x.SubType == TradeSubType.NewOption
                && x.Amount > amountMin
                && x.Amount < amountMax);
        }
    }
}