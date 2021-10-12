// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿namespace TemplateMethod.Task1
{
    public class MasalaRecipe
    {
        public int ChickenAmount { get; init; }
        public Level ChickenFryLevel { get; init; }
        public Level? ChickenSaltLevel { get; init; }
        public Level? ChickenPepperLevel { get; init; }
        public int RiceAmount { get; init; }
        public Level RiceFryLevel { get; init; }
        public Level? RiceSaltLevel { get; init; }
        public Level? RicePepperLevel { get; init; }
        public int TeaAmount { get; init; }
        public TeaKind TeaKind { get; init; }
        public int TeaHoneyAmount { get; init; }
    }
}