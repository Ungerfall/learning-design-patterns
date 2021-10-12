// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System.Collections.Generic;
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