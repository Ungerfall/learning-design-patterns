namespace AbstartFactory
{
    public class EnglishCookbook : ICookbook
    {
        public IMasalaRecipe GetMasalaRecipe()
        {
            return new EnglishMasala();
        }
    }
}