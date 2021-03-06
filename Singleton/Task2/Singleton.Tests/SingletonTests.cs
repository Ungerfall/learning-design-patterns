// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Singleton.Tests
{
    [TestClass]
    public class SingletonTests
    {
        [TestMethod]
        public void Should_create_only_one_instance()
        {
            var instance1 = ThreadSafe.Singleton.Instance;
            var instance2 = ThreadSafe.Singleton.Instance;
            var instance3 = ThreadSafe.Singleton.Instance;

            Assert.AreEqual(instance1, instance2);
            Assert.AreEqual(instance2, instance3);
        }
    }
}
