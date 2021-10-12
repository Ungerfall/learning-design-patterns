// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿namespace AbstartFactory
{
    public class EnglishMasala : IMasalaRecipe
    {
        public int RiceAmount => 100;
        public Level RiceFryLevel => Level.Low;
        public Level? RiceSaltLevel => null;
        public Level? RicePepperLevel => null;
        public int ChickenAmount => 100;
        public Level ChickenFryLevel => Level.Low;
        public Level? ChickenSaltLevel => null;
        public Level? ChickenPepperLevel => null;
    }
}