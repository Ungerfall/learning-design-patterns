// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System.Collections.Generic;
using FilesAllocator.Core.Utils;

namespace FilesAllocator.Core.FileCopierDecorators
{
    internal class FileCopierWithCreationDatePrefixFilename : IFileCopier
    {
        private readonly IFileCopier @base;

        public FileCopierWithCreationDatePrefixFilename(IFileCopier @base)
        {
            this.@base = @base;
        }

        public int Copy(ICollection<File> files)
        {
            AddCreationDatePrefixForFilename(files);
            return @base.Copy(files);
        }

        private static void AddCreationDatePrefixForFilename(ICollection<File> files)
        {
            foreach (var file in files)
            {
                var dateTaken = file.GetMetadataDateTime();

                var createDateTime = dateTaken ?? file.FileInfo.CreationTime;
                var createDate = createDateTime.ToString("yyyyMMdd");
                var createTime = createDateTime.ToString("HHmmss");
                file.Name = $"{createDate}-{createTime}_{file.Name}";
            }
        }
    }
}