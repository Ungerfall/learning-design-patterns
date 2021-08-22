using RetailEquity.Task3;

namespace RetailEquity
{
    public interface IBankFactoryFinder
    {
        IBankFactory Find(Bank bank, Country country);
    }
}