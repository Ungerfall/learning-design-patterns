namespace AbstartFactory
{
    public class UkrainianSummerCookbook : ICookbook
    {
        public IMasalaRecipe GetMasalaRecipe()
        {
            return new UkrainianSummerMasala();
        }
    }
}