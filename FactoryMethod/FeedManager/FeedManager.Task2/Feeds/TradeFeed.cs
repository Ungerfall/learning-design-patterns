// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System;

namespace FeedManager.Task2.Feeds
{
    public class TradeFeed
    {
        public int StagingId { get; set; }

        public string SourceTradeRef { get; set; }

        public int CounterpartyId { get; set; }

        public int PrincipalId { get; set; }

        public DateTime ValuationDate { get; set; }
        
        public decimal CurrentPrice { get; set; }

        public int SourceAccountId { get; set; }
    }
}
