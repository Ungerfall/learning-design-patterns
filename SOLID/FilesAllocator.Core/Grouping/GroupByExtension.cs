// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System.Collections.Generic;

namespace FilesAllocator.Core.Grouping
{
    internal class GroupByExtension : IGroupingStrategy
    {
        private readonly Dictionary<string, string> extensionToFolder;

        public GroupByExtension(Dictionary<string, string> extensionToFolder)
        {
            this.extensionToFolder = extensionToFolder;
        }

        public string GetGroupingFolderName(File file)
        {
            var extension = file.FileInfo.Extension;
            return extensionToFolder.TryGetValue(extension, out var folder)
                ? folder
                : string.Empty;
        }
    }
}