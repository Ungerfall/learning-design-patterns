namespace AbstartFactory
{
    public class EnglishSummerCookbook : ICookbook
    {
        public IMasalaRecipe GetMasalaRecipe()
        {
            return new EnglishSummerMasala();
        }
    }
}