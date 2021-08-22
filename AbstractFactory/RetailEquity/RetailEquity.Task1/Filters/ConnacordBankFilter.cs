using RetailEquity.Model;
using System.Collections.Generic;
using System.Linq;

namespace RetailEquity.Filters
{
    public class ConnacordBankFilter : IFilter
    {
        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            const int amountMin = 10;
            const int amountMax = 40;
            return trades.Where(x => x.Type == TradeType.Future && x.Amount > amountMin && x.Amount < amountMax);
        }
    }
}