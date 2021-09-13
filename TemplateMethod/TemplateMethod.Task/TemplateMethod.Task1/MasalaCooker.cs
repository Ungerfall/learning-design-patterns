using System;

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
            var recipe = masala.PrepareRecipe();

            // TODO Все, что ниже, должно быть описано в рецепте масалы. Это не логика повара
            cooker.FryChicken(recipe.ChickenAmount, recipe.ChickenFryLevel);
            if (recipe.ChickenSaltLevel != null)
            {
                cooker.SaltChicken(recipe.ChickenSaltLevel.Value);
            }

            if (recipe.ChickenPepperLevel != null)
            {
                cooker.PepperChicken(recipe.ChickenPepperLevel.Value);
            }

            cooker.FryRice(recipe.RiceAmount, recipe.RiceFryLevel);
            if (recipe.RiceSaltLevel != null)
            {
                cooker.SaltRice(recipe.RiceSaltLevel.Value);
            }

            if (recipe.RicePepperLevel != null)
            {
                cooker.PepperRice(recipe.RicePepperLevel.Value);
            }

            cooker.PrepareTea(recipe.TeaAmount, recipe.TeaKind, recipe.TeaHoneyAmount);
        }
    }
}