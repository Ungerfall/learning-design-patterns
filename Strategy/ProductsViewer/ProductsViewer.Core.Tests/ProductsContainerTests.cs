// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System;
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

            var productsContainer = new ProductsContainer(new DefaultProductFormatter());

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

			var productsContainer = new ProductsContainer(new DefaultProductFormatter())
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

        [Test]
        public void Show_Cooler()
        {
			#region Arrange

			var productsContainer = new ProductsContainer(new CoolerProductFormatter())
				.Add(1, "Product 1")
				.Add(2, "Product 2");

			#endregion

			#region Act

			var result = productsContainer.Show();

			#endregion

			#region Assert

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.Not.Empty);
			Assert.That(result, Is.EqualTo("PRODUCTS_#1:'Product 1'_#2:'Product 2';"));

			#endregion

        }

		#endregion
	}
}
