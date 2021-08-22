using RetailEquity.Filters;

namespace RetailEquity
{
    public class ConnacordBankFactory : IBankFactory
    {
        public IFilter CreateTradeFilter()
        {
            return new ConnacordBankFilter();
        }
    }
}