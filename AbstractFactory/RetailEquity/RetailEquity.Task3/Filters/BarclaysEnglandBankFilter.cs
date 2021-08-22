using RetailEquity.Model;
using System.Collections.Generic;
using System.Linq;

namespace RetailEquity.Filters
{
    public class BarclaysEnglandBankFilter : IFilter
    {
        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            const int amountMin = 100;
            return trades.Where(x => x.Type == TradeType.Future && x.Amount > amountMin);
        }
    }
}