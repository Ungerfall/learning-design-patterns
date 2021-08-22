using RetailEquity.Filters;

namespace RetailEquity
{
    public class BofaBankFactory : IBankFactory
    {
        public IFilter CreateTradeFilter()
        {
            return new BofaBankFilter();
        }
    }
}