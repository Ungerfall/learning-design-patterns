// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System.Collections.Generic;
using System.Linq;

namespace FeedManager.Task1.FeedValidators
{
    public class ValidateResult
    {
        public bool IsValid { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public static ValidateResult Merge(ValidateResult one, ValidateResult another)
        {
            if (one.IsValid && another.IsValid)
                return new ValidateResult { IsValid = true };

            return new ValidateResult
            {
                IsValid = false,
                Errors = one.Errors.Concat(another.Errors).ToList()
            };
        }
    }
}