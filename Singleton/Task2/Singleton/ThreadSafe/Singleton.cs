namespace Singleton.ThreadSafe
{
    // https://csharpindepth.com/articles/singleton
    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padLock = new object();

        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                lock (padLock)
                {
                    if (instance == null)
                        instance = new Singleton();

                    return instance;
                }
            }
        }
    }
}