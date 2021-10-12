// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Reader.Interfaces
{
    public interface IFileReader
    {
        void LoadFile(string path);
        string NextPage { get; }
        string PreviousPage { get; }
        string FirstPage { get; }
        string LastPage { get; }
        bool IsLastPage { get; }
        bool IsFirstPage { get; }
    }
}
