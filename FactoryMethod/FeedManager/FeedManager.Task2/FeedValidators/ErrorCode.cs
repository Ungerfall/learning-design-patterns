// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿namespace FeedManager.Task2.FeedValidators
{
    public class ErrorCode
    {
        public static string IdIsNotValidMessage { get; } = "Identifier should be bigger than 1";

        public static string PriceIsNotValid { get; } = "Should be positive and 2 digits after decimal point";

        public static string NotValidIsin { get; } = "Should be valid Isin";

        public static string NotValidMaturityDate { get; } = "Maturity date should be bigger than valuation date";

        public static string PropertyRangeError(string name, decimal minVal, decimal maxVal)
        {
            return $"{name} should be between {minVal} and {maxVal}";
        }
    }
}