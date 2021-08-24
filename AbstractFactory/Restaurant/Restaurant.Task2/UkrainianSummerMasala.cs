namespace AbstartFactory
{
    public class UkrainianSummerMasala : IMasalaRecipe
    {
        public int RiceAmount => 150;
        public Level RiceFryLevel => Level.Medium;
        public Level? RiceSaltLevel => Level.Low;
        public Level? RicePepperLevel => null;
        public int ChickenAmount => 200;
        public Level ChickenFryLevel => Level.Medium;
        public Level? ChickenSaltLevel => Level.Low;
        public Level? ChickenPepperLevel => null;
    }
}