using System.Collections.Generic;
using System.Text;

namespace ProductsViewer.Core
{
    internal interface IProductsFormatter
    {
        void Format(StringBuilder buffer, IEnumerable<Product> products);
    }
}