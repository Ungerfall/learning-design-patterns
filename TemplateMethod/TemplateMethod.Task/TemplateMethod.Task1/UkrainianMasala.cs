namespace TemplateMethod.Task1
{
    public class UkrainianMasala : Masala
    {
        protected override int ChickenAmount => 300;
        protected override Level ChickenFryLevel => Level.Medium;
        protected override int RiceAmount => 500;
        protected override Level RiceFryLevel => Level.Strong;
        protected override int TeaAmount => 10;
        protected override TeaKind TeaKind => TeaKind.Black;
        protected override int TeaHoneyAmount => 10;

        protected override void AddSeasoning(ICooker cooker)
        {
            cooker.SaltChicken(Level.Medium);
            cooker.PepperChicken(Level.Low);
            cooker.SaltRice(Level.Strong);
            cooker.PepperRice(Level.Low);
        }
    }
}