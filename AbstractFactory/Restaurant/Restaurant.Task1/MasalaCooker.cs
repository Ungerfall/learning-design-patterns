using System;

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
