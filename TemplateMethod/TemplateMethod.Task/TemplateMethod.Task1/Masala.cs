// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿namespace TemplateMethod.Task1
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