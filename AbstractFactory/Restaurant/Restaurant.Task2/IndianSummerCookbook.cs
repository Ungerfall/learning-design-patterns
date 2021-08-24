namespace AbstartFactory
{
    public class IndianSummerCookbook : ICookbook
    {
        public IMasalaRecipe GetMasalaRecipe()
        {
            return new IndianSummerMasala();
        }
    }
}