namespace AbstartFactory
{
    public class IndianBasicCookbook : ICookbook
    {
        public IMasalaRecipe GetMasalaRecipe()
        {
            return new IndianMasala();
        }
    }
}