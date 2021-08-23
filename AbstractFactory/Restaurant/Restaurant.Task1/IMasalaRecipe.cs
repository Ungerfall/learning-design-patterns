namespace AbstartFactory
{
    public interface IMasalaRecipe
    {
        int RiceAmount { get; }
        Level RiceFryLevel { get; }
        Level? RiceSaltLevel { get; }
        Level? RicePepperLevel { get; }
        int ChickenAmount { get; }
        Level ChickenFryLevel { get; }
        Level? ChickenSaltLevel { get; }
        Level? ChickenPepperLevel { get; }
    }
}