// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using RetailEquity.Filters;

namespace RetailEquity
{
    public class BarclaysBankFactory : IBankFactory
    {
        public IFilter CreateTradeFilter()
        {
            return new BarclaysBankFilter();
        }
    }
}