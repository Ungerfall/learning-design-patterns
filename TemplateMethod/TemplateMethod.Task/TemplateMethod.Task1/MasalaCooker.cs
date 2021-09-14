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
            masala.PrepareRecipe(cooker);
        }
    }
}