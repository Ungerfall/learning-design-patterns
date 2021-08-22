using RetailEquity.Filters;

namespace RetailEquity
{
    public class BarclaysUsaBankFactory : IBankFactory
    {
        public IFilter CreateTradeFilter()
        {
            return new BarclaysUsaBankFilter();
        }
    }
}