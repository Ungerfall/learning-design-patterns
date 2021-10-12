// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System;

namespace AbstartFactory
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
            ICookbook cookbook = country switch
            {
                Country.India => new IndianCookbook(),
                Country.Ukraine => new UkrainianCookbook(),
                Country.England => new EnglishCookbook(),
                _ => throw new Exception()
            };

            var recipe = cookbook.GetMasalaRecipe();

            cooker.FryRice(recipe.RiceAmount, recipe.RiceFryLevel);
            cooker.FryChicken(recipe.ChickenAmount, recipe.ChickenFryLevel);
            if (recipe.RiceSaltLevel != null)
            {
                cooker.SaltRice(recipe.RiceSaltLevel.Value);
            }

            if (recipe.RicePepperLevel != null)
            {
                cooker.PepperRice(recipe.RicePepperLevel.Value);
            }

            if (recipe.ChickenSaltLevel != null)
            {
                cooker.SaltChicken(recipe.ChickenSaltLevel.Value);
            }

            if (recipe.ChickenPepperLevel != null)
            {
                cooker.PepperChicken(recipe.ChickenPepperLevel.Value);
            }
        }
    }
}
