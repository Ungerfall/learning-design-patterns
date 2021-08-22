using RetailEquity.Model;
using System.Collections.Generic;
using System.Linq;

namespace RetailEquity.Filters
{
    public class BofaBankFilter : IFilter
    {
        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            const int amountMin = 70;
            return trades.Where(x => x.Amount > amountMin);
        }
    }
}