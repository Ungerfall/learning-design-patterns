using System;
using NUnit.Framework;

namespace ProductsViewer.Core.Tests
{
	[TestFixture]
	public class ProductsContainerTests
	{
		#region Tests

		[Test]
		public void Add_Successful()
		{
			#region Arrange

			var productsContainer = new ProductsContainer();

			#endregion

			#region Act

			productsContainer
				.Add(1, "Product 1")
				.Add(2, "Product 2")
				.Add(3, "Product 3");

			var result = productsContainer.Size;

			#endregion

			#region Assert

			Assert.That(result, Is.EqualTo(3));

			#endregion
		}

		[Test]
		public void Show_Default()
		{
			#region Arrange

			var productsContainer = new ProductsContainer()
				.Add(1, "Product 1")
				.Add(2, "Product 2");

			#endregion

			#region Act

			var result = productsContainer.Show();

			#endregion

			#region Assert

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.Not.Empty);
			Assert.That(result, Is.EqualTo("(ID=1; Name='Product 1';)(ID=2; Name='Product 2';)"));

			#endregion
		}

		#endregion
	}
}
