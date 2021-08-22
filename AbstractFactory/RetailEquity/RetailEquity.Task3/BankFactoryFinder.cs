using System;
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