namespace TemplateMethod.Task1
{
    public abstract class Masala : IMasala
    {
        public void PrepareRecipe(ICooker cooker)
        {
            cooker.FryChicken(ChickenAmount, ChickenFryLevel);
            cooker.FryRice(RiceAmount, RiceFryLevel);
            cooker.PrepareTea(TeaAmount, TeaKind, TeaHoneyAmount);
            AddSeasoning(cooker);
        }

        protected abstract int ChickenAmount { get; }
        protected abstract Level ChickenFryLevel { get; }
        protected abstract int RiceAmount { get; }
        protected abstract Level RiceFryLevel { get; }
        protected abstract int TeaAmount { get; }
        protected abstract TeaKind TeaKind { get; }
        protected abstract int TeaHoneyAmount { get; }

        protected abstract void AddSeasoning(ICooker cooker);
    }
}