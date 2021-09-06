namespace TemplateMethod.Task1
{
    public abstract class Masala : IMasala
    {
        public MasalaRecipe PrepareRecipe()
        {
            var (chicken, chickenFry, chickenSalt, chickenPepper) = PrepareChicken();
            var (rice, riceFry, riceSalt, ricePepper) = PrepareRice();
            var (tea, teaKind, honey) = PrepareTea();

            return new MasalaRecipe
            {
                ChickenAmount = chicken,
                ChickenFryLevel = chickenFry,
                ChickenSaltLevel = chickenSalt,
                ChickenPepperLevel = chickenPepper,
                RiceAmount = rice,
                RiceFryLevel = riceFry,
                RiceSaltLevel = riceSalt,
                RicePepperLevel = ricePepper,
                TeaAmount = tea,
                TeaKind = teaKind,
                TeaHoneyAmount = honey
            };
        }

        protected abstract (int amount, Level fry, Level? salt, Level? pepper) PrepareChicken();
        protected abstract (int amount, Level fry, Level? salt, Level? pepper) PrepareRice();
        protected abstract (int amount, TeaKind kind, int honey) PrepareTea();
    }
}