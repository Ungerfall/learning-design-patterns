using RetailEquity.Model;
using System.Collections.Generic;
using System.Linq;

namespace RetailEquity.Filters
{
    public class BarclaysBankFilter : IFilter
    {
        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            const int amountMin = 50;
            return trades.Where(x =>
                x.Type == TradeType.Option
                && x.SubType == TradeSubType.NyOption
                && x.Amount > amountMin);
        }
    }
}