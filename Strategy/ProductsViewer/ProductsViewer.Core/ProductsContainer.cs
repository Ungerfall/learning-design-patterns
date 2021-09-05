using System.Collections.Generic;
using System.Text;

namespace ProductsViewer.Core
{
    public class ProductsContainer
    {
        private readonly IList<Product> _products = new List<Product>();
        private readonly IProductsFormatter _formatter;

        internal ProductsContainer(IProductsFormatter formatter)
        {
            _formatter = formatter ?? new DefaultProductFormatter();
        }

        public int Size => _products.Count;

        public ProductsContainer Add(int id, string name)
        {
            _products.Add(new Product()
            {
                Id = id,
                Name = name
            });

            return this;
        }

        public string Show()
        {
            var stringBuilder = new StringBuilder();

            _formatter.Format(stringBuilder, _products);

            return stringBuilder.ToString();
        }
    }
}