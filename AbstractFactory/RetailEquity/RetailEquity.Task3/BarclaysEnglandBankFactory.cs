using RetailEquity.Filters;

namespace RetailEquity
{
    public class BarclaysEnglandBankFactory : IBankFactory
    {
        public IFilter CreateTradeFilter()
        {
            return new BarclaysEnglandBankFilter();
        }
    }
}