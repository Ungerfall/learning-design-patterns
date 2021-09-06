namespace TemplateMethod.Task1
{
    public class IndianMasala : Masala
    {
        protected override (int amount, Level fry, Level? salt, Level? pepper) PrepareChicken()
        {
            return (100, Level.Strong, Level.Strong, Level.Strong);
        }

        protected override (int amount, Level fry, Level? salt, Level? pepper) PrepareRice()
        {
            return (200, Level.Strong, Level.Strong, Level.Strong);
        }

        protected override (int amount, TeaKind kind, int honey) PrepareTea()
        {
            return (15, TeaKind.Green, 12);
        }
    }
}