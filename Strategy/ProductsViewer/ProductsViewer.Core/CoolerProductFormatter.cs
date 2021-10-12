// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System.Collections.Generic;
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