// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿namespace Singleton.ThreadSafe
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