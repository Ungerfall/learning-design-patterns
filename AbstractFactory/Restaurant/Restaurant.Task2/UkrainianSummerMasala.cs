// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿namespace AbstartFactory
{
    public class UkrainianSummerMasala : IMasalaRecipe
    {
        public int RiceAmount => 150;
        public Level RiceFryLevel => Level.Medium;
        public Level? RiceSaltLevel => Level.Low;
        public Level? RicePepperLevel => null;
        public int ChickenAmount => 200;
        public Level ChickenFryLevel => Level.Medium;
        public Level? ChickenSaltLevel => Level.Low;
        public Level? ChickenPepperLevel => null;
    }
}