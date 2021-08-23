namespace AbstartFactory
{
    public class EnglishMasala : IMasalaRecipe
    {
        public int RiceAmount => 100;
        public Level RiceFryLevel => Level.Low;
        public Level? RiceSaltLevel => null;
        public Level? RicePepperLevel => null;
        public int ChickenAmount => 100;
        public Level ChickenFryLevel => Level.Low;
        public Level? ChickenSaltLevel => null;
        public Level? ChickenPepperLevel => null;
    }
}