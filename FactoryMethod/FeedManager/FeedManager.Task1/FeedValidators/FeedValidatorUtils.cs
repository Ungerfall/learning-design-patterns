// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System;

namespace FeedManager.Task1.FeedValidators
{
    public static class FeedValidatorUtils
    {
        public static int GetNumberOfDecimalPlaces(decimal value)
        {
            // https://stackoverflow.com/questions/13477689/find-number-of-decimal-places-in-decimal-value-regardless-of-culture
            return BitConverter.GetBytes(decimal.GetBits(value)[3])[2];
        }
    }
}