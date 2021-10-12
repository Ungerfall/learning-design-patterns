// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using FilesAllocator.Core.Utils;

namespace FilesAllocator.Core.Grouping
{
    internal class GroupByCreationDate : IGroupingStrategy
    {
        public string GetGroupingFolderName(File file)
        {
            var dateTaken = file.GetMetadataDateTime();

            var createDateTime = dateTaken ?? file.FileInfo.CreationTime;
            return createDateTime.ToString("yyyy-MM-dd");
        }
    }
}