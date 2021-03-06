// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System.Collections.Generic;
using System.Linq;

namespace TemplateMethod.Task1.Tests
{
    public class FakeCooker : ICooker
    {
        public List<Ingredient> Rices { get; } = new List<Ingredient>();

        public List<Ingredient> Chickens { get; } = new List<Ingredient>();

        public List<TeaIngredient> Teas { get; } = new List<TeaIngredient>();

        public void FryChicken(int amount, Level level)
        {
            Chickens.Add(new Ingredient
            {
                Amount = amount,
                FryLevel = level
            });
        }

        public void FryRice(int amount, Level level)
        {
            Rices.Add(new Ingredient
            {
                Amount = amount,
                FryLevel = level
            });
        }

        public void PepperChicken(Level level)
        {
            Chickens.Last().PepperLevel = level;
        }

        public void PepperRice(Level level)
        {
            Rices.Last().PepperLevel = level;
        }

        public void SaltChicken(Level level)
        {
            Chickens.Last().SaltLevel = level;
        }

        public void SaltRice(Level level)
        {
            Rices.Last().SaltLevel = level;
        }

        public void PrepareTea(int teaGram, TeaKind teaType, int honeyGram)
        {
            Teas.Add(new TeaIngredient
            {
                TeaGram = teaGram,
                HoneyGram = honeyGram,
                TeaType = teaType
            });
        }
    }
}
