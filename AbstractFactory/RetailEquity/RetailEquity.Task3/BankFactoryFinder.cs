// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System;
using RetailEquity.Task3;

namespace RetailEquity
{
    public class BankFactoryFinder : IBankFactoryFinder
    {
        public IBankFactory Find(Bank bank, Country country)
        {
            var tuple = (bank, country);

            return tuple switch
            {
                (Bank.Bofa, _) => new BofaBankFactory(),
                (Bank.Connacord, _) => new ConnacordBankFactory(),
                (Bank.Barclays, Country.England) => new BarclaysEnglandBankFactory(),
                (Bank.Barclays, Country.USA) => new BarclaysUsaBankFactory(),
                (Bank.DeutscheBank, _) => new DeutscheBankFactory(),
                _ => throw new ArgumentOutOfRangeException(nameof(bank), bank, null)
            };
        }
    }
}