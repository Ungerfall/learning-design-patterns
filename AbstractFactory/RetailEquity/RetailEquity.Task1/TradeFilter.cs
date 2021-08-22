using RetailEquity.Model;
using RetailEquity.Task1;
using System.Collections.Generic;

namespace RetailEquity
{
    public class TradeFilter
    {
        private readonly IBankFactoryFinder _factoryFinder;

        public TradeFilter(IBankFactoryFinder factoryFinder = null)
        {
            _factoryFinder = factoryFinder ?? new BankFactoryFinder();
        }

        public IEnumerable<Trade> FilterForBank(IEnumerable<Trade> trades, Bank bank)
        {
            var factory = _factoryFinder.Find(bank);
            var filter = factory.CreateTradeFilter();

            return filter.Match(trades);
        }
    }
}