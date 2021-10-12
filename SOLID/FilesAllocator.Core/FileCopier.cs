// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using FilesAllocator.Core.FileCopierDecorators;
using FilesAllocator.Core.Grouping;
using System;
using System.Collections.Generic;
using System.IO;

namespace FilesAllocator.Core
{
    internal class FileCopier : IFileCopier
    {
        public int Copy(ICollection<File> files)
        {
            var result = 0;
            foreach (var file in files)
            {
                CopyFile(file.InitFullName, file.EndpointFullName);
                result++;
            }

            return result;
        }

        internal static void CopyFile(string sourceFileName, string destFileName)
        {
            var destDirectory = Path.GetDirectoryName(destFileName);

            if (destDirectory == null)
            {
                throw new NullReferenceException("Cannot get destination directory.");
            }

            if (!Directory.Exists(destDirectory))
            {
                Directory.CreateDirectory(destDirectory);
            }

            System.IO.File.Copy(sourceFileName, destFileName, overwrite: true);
        }

        internal static IFileCopier Create(Configuration cfg)
        {
            IFileCopier fileCopier = new FileCopier();
            foreach (var instruction in cfg.Instructions.Values)
            {
                if (instruction is CreationDateTimePrefixName)
                {
                    fileCopier = new FileCopierWithCreationDatePrefixFilename(fileCopier);
                }

                if (instruction is GroupByCreationDateInstruction)
                {
                    var groupings = new SortedList<int, IGroupingStrategy>();
                    groupings.Add(1, new GroupByCreationDate());
                    fileCopier = new FileCopierWithGrouping(fileCopier, groupings);
                }

                if (instruction is FilteredExtensionsInstruction extensionsInstruction)
                {
                    fileCopier = new FileCopierWithExtensionsFilter(fileCopier, extensionsInstruction.FilteredExtensions);
                }

            }

            fileCopier = new FileCopierWithRenamingDuplicates(fileCopier);

            return fileCopier;
        }
    }
}