// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System.Collections.Generic;
using System.IO;
using FilesAllocator.Core.Grouping;

namespace FilesAllocator.Core.FileCopierDecorators
{
    internal class FileCopierWithGrouping : IFileCopier
    {
        private readonly IFileCopier @base;
        private readonly SortedList<int, IGroupingStrategy> groupingStrategies;

        public FileCopierWithGrouping(IFileCopier @base, SortedList<int, IGroupingStrategy> groupingStrategies)
        {
            this.@base = @base;
            this.groupingStrategies = groupingStrategies;
        }

        public int Copy(ICollection<File> files)
        {
            GroupByCreationDate(files);
            return @base.Copy(files);
        }

        /// <summary>
        /// Group files into directories by the creation date
        /// </summary>
        private void GroupByCreationDate(ICollection<File> files)
        {
            foreach (var file in files)
            {
                foreach (var groupingStrategy in groupingStrategies.Values)
                {
                    var groupingFolder = groupingStrategy.GetGroupingFolderName(file);
                    file.EndpointDirectory = Path.Combine(
                        file.EndpointDirectory ?? string.Empty,
                        groupingFolder);
                }
            }
        }
    }
}