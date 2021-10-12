// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using RetailEquity.Model;
using System.Collections.Generic;
using System.Linq;

namespace RetailEquity.Filters
{
    public class ConnacordBankFilter : IFilter
    {
        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            const int amountMin = 10;
            const int amountMax = 40;
            return trades.Where(x => x.Type == TradeType.Future && x.Amount > amountMin && x.Amount < amountMax);
        }
    }
}