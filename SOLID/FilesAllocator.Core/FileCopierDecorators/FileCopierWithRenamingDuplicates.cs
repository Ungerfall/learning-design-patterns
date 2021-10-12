// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FilesAllocator.Core.FileCopierDecorators
{
    internal class FileCopierWithRenamingDuplicates : IFileCopier
    {
        private readonly IFileCopier @base;

        public FileCopierWithRenamingDuplicates(IFileCopier @base)
        {
            this.@base = @base;
        }

        public int Copy(ICollection<File> files)
        {
            RenameDuplicateFiles(files);
            return @base.Copy(files);
        }

        /// <summary>
        /// Add GUID as postfix of filename for duplicated files
        /// </summary>
        /// <param name="files"></param>
        private static void RenameDuplicateFiles(ICollection<File> files)
        {
            foreach (var file in files)
            {
                var hasDuplicate = files.Count(f => f.EndpointFullName.Equals(file.EndpointFullName)) > 1;
                if (!hasDuplicate) continue;

                var fileName = file.Name;
                var uniqueString = $"_{Guid.NewGuid():N}";
                var uniqueFileName = fileName.Insert(fileName.Length - file.FileInfo.Extension.Length, uniqueString);
                file.Name = uniqueFileName;
            }
        }
    }
}