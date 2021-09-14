namespace TemplateMethod.Task1
{
    public class IndianMasala : Masala
    {
        protected override int ChickenAmount => 100;
        protected override Level ChickenFryLevel => Level.Strong;
        protected override int RiceAmount => 200;
        protected override Level RiceFryLevel => Level.Strong;
        protected override int TeaAmount => 15;
        protected override TeaKind TeaKind => TeaKind.Green;
        protected override int TeaHoneyAmount => 12;

        protected override void AddSeasoning(ICooker cooker)
        {
            cooker.SaltChicken(Level.Strong);
            cooker.PepperChicken(Level.Strong);
            cooker.SaltRice(Level.Strong);
            cooker.PepperRice(Level.Strong);
        }
    }
}