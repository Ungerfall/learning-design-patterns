using System.Collections.Generic;
using System.Text;

namespace ProductsViewer.Core
{
    internal class DefaultProductFormatter : IProductsFormatter
    {
        private const string SPACE_STR = " ";

        public void Format(StringBuilder buffer, IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                buffer.Append("(");
                buffer.Append($"ID={product.Id};");
                buffer.Append(SPACE_STR);
                buffer.Append($"Name='{product.Name}';");
                buffer.Append(")");
            }
        }
    }
}