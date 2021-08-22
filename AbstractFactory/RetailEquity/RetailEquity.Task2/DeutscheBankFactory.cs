using RetailEquity.Filters;

namespace RetailEquity
{
    public class DeutscheBankFactory : IBankFactory
    {
        public IFilter CreateTradeFilter()
        {
            return new DeutscheBankFilter();
        }
    }
}