namespace AbstartFactory
{
    public class IndianCookbook : ICookbook
    {
        public IMasalaRecipe GetMasalaRecipe()
        {
            return new IndianMasala();
        }
    }
}