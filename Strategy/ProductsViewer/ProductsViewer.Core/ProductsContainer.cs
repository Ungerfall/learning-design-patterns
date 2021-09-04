using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsViewer.Core
{
	public class ProductsContainer
	{
		#region Consts

		private const string SPACE_STR = " ";

		#endregion

		#region Fields

		private readonly IList<Product> _products = new List<Product>();

		#endregion

		#region Properties

		public int Size => _products.Count;

		#endregion

		#region Public

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

			foreach (var product in _products)
			{
				stringBuilder.Append("(");
				stringBuilder.Append($"ID={product.Id};");
				stringBuilder.Append(SPACE_STR);
				stringBuilder.Append($"Name='{product.Name}';");
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}

		#endregion
  }
}
