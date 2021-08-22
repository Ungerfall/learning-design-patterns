using System;

namespace RetailEquity
{
    public class BankFactoryFinder : IBankFactoryFinder
    {
        public IBankFactory Find(Bank bank)
        {
            return bank switch
            {
                Bank.Bofa => new BofaBankFactory(),
                Bank.Connacord => new ConnacordBankFactory(),
                Bank.Barclays => new BarclaysBankFactory(),
                Bank.DeutscheBank => new DeutscheBankFactory(),
                _ => throw new ArgumentOutOfRangeException(nameof(bank), bank, null)
            };
        }
    }
}