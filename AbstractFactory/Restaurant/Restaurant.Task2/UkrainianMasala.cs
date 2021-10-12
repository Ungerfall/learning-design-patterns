// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿namespace AbstartFactory
{
    public class UkrainianMasala : IMasalaRecipe
    {
        public int RiceAmount => 500;
        public Level RiceFryLevel => Level.Strong;
        public Level? RiceSaltLevel => Level.Strong;
        public Level? RicePepperLevel => Level.Low;
        public int ChickenAmount => 300;
        public Level ChickenFryLevel => Level.Medium;
        public Level? ChickenSaltLevel => Level.Medium;
        public Level? ChickenPepperLevel => Level.Low;
    }
}