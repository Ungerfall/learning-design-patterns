using RetailEquity.Filters;

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