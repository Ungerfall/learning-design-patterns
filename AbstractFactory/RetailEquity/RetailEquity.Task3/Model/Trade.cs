// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿namespace RetailEquity.Model
{
    public class Trade
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public TradeType Type { get; set; }

        public TradeSubType SubType { get; set; }
    }
}
