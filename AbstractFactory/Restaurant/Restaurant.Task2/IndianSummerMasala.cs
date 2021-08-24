namespace AbstartFactory
{
    public class IndianSummerMasala : IMasalaRecipe
    {
        public int RiceAmount => 100;
        public Level RiceFryLevel => Level.Low;
        public Level? RiceSaltLevel => null;
        public Level? RicePepperLevel => Level.Medium;
        public int ChickenAmount => 100;
        public Level ChickenFryLevel => Level.Low;
        public Level? ChickenSaltLevel => null;
        public Level? ChickenPepperLevel => Level.Medium;
    }
}