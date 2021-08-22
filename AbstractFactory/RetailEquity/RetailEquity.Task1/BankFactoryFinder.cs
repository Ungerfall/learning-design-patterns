using RetailEquity.Task1;
using System;

namespace RetailEquity
{
    public class BankFactoryFinder : IBankFactoryFinder
    {
        public IBankFactory Find(Bank bank)
        {
            switch (bank)
            {
                case Bank.Bofa:
                    return new BofaBankFactory();

                case Bank.Connacord:
                    return new ConnacordBankFactory();

                case Bank.Barclays:
                    return new BarclaysBankFactory();

                default:
                    throw new ArgumentOutOfRangeException(nameof(bank), bank, null);
            }
        }
    }
}