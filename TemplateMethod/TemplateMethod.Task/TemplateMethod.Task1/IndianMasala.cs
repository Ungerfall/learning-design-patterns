// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿namespace TemplateMethod.Task1
{
    public class IndianMasala : Masala
    {
        protected override int ChickenAmount => 100;
        protected override Level ChickenFryLevel => Level.Strong;
        protected override int RiceAmount => 200;
        protected override Level RiceFryLevel => Level.Strong;
        protected override int TeaAmount => 15;
        protected override TeaKind TeaKind => TeaKind.Green;
        protected override int TeaHoneyAmount => 12;

        protected override void AddSeasoning(ICooker cooker)
        {
            cooker.SaltChicken(Level.Strong);
            cooker.PepperChicken(Level.Strong);
            cooker.SaltRice(Level.Strong);
            cooker.PepperRice(Level.Strong);
        }
    }
}