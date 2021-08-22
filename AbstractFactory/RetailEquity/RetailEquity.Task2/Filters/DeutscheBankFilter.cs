using System.Collections.Generic;
using System.Linq;
using RetailEquity.Model;

namespace RetailEquity.Filters
{
    public class DeutscheBankFilter : IFilter
    {
        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            const int amountMin = 90;
            const int amountMax = 120;
            return trades.Where(x =>
                x.Type == TradeType.Option
                && x.SubType == TradeSubType.NewOption
                && x.Amount > amountMin
                && x.Amount < amountMax);
        }
    }
}