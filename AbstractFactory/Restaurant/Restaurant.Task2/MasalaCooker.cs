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

        public void CookMasala(DateTime currentDate, Country country)
        {
            var cfg = (country, isSummer: IsSummerDate(currentDate));
            ICookbook cookbook = cfg switch
            {
                (Country.India, false) => new IndianBasicCookbook(),
                (Country.India, true) => new IndianSummerCookbook(),
                (Country.Ukraine, false) => new UkrainianCookbook(),
                (Country.Ukraine, true) => new UkrainianSummerCookbook(),
                (Country.England, false) => new EnglishCookbook(),
                (Country.England, true) => new EnglishSummerCookbook(),
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

        private bool IsSummerDate(DateTime currentDate)
        {
            return currentDate.Month >= 6 && currentDate.Month <= 8;
        }
    }
}
