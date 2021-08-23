namespace AbstartFactory
{
    public class UkrainianCookbook : ICookbook
    {
        public IMasalaRecipe GetMasalaRecipe()
        {
            return new UkrainianMasala();
        }
    }
}