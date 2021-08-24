namespace AbstartFactory
{
    public class IndianMasala : IMasalaRecipe
    {
        public int RiceAmount => 200;
        public Level RiceFryLevel => Level.Strong;
        public Level? RiceSaltLevel => Level.Strong;
        public Level? RicePepperLevel => Level.Strong;
        public int ChickenAmount => 100;
        public Level ChickenFryLevel => Level.Strong;
        public Level? ChickenSaltLevel => Level.Strong;
        public Level? ChickenPepperLevel => Level.Strong;
    }
}