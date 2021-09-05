using System.Collections.Generic;
using System.Text;

namespace ProductsViewer.Core
{
    internal class CoolerProductFormatter : IProductsFormatter
    {
        public void Format(StringBuilder buffer, IEnumerable<Product> products)
        {
            buffer.Append("PRODUCTS");
            foreach (var product in products)
            {
                buffer.AppendFormat("_#{0}:'{1}'", product.Id, product.Name);
            }

            buffer.Append(";");
        }
    }
}