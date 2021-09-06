namespace TemplateMethod.Task1
{
    public class UkrainianMasala : Masala
    {
        protected override (int amount, Level fry, Level? salt, Level? pepper) PrepareChicken()
        {
            return (300, Level.Medium, Level.Medium, Level.Low);
        }

        protected override (int amount, Level fry, Level? salt, Level? pepper) PrepareRice()
        {
            return (500, Level.Strong, Level.Strong, Level.Low);
        }

        protected override (int amount, TeaKind kind, int honey) PrepareTea()
        {
            return (10, TeaKind.Black, 10);
        }
    }
}