// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System;

namespace TemplateMethod.Task1
{
    public class MasalaCooker
    {
        private ICooker cooker;

        public MasalaCooker(ICooker cooker)
        {
            this.cooker = cooker;
        }

        public void CookMasala(Country country)
        {
            IMasala masala = country switch
            {
                Country.Ukraine => new UkrainianMasala(),
                Country.India => new IndianMasala(),
                _ => throw new ArgumentOutOfRangeException(nameof(country), country, null)
            };
            masala.PrepareRecipe(cooker);
        }
    }
}