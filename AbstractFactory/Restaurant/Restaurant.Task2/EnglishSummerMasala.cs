namespace AbstartFactory
{
    public class EnglishSummerMasala : IMasalaRecipe
    {
        public int RiceAmount => 50;
        public Level RiceFryLevel => Level.Low;
        public Level? RiceSaltLevel => null;
        public Level? RicePepperLevel => null;
        public int ChickenAmount => 50;
        public Level ChickenFryLevel => Level.Low;
        public Level? ChickenSaltLevel => null;
        public Level? ChickenPepperLevel => null;
    }
}