using System;

namespace Singleton.ThreadSafe
{
    // https://csharpindepth.com/articles/singleton
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton(), isThreadSafe: true);

        private Singleton()
        {
        }

        public static Singleton Instance => lazy.Value;
    }
}