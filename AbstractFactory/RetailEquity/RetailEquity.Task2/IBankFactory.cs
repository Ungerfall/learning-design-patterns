using RetailEquity.Filters;

namespace RetailEquity
{
    public interface IBankFactory
    {
        IFilter CreateTradeFilter();
    }
}