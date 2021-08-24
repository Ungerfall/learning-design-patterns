namespace AbstartFactory
{
    public class UkrainianMasala : IMasalaRecipe
    {
        public int RiceAmount => 500;
        public Level RiceFryLevel => Level.Strong;
        public Level? RiceSaltLevel => Level.Strong;
        public Level? RicePepperLevel => Level.Low;
        public int ChickenAmount => 300;
        public Level ChickenFryLevel => Level.Medium;
        public Level? ChickenSaltLevel => Level.Medium;
        public Level? ChickenPepperLevel => Level.Low;
    }
}