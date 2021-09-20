using FilesAllocator.Core.FileCopierDecorators;
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
            if (cfg.CreationDateTimePrefixName)
            {
                fileCopier = new FileCopierWithCreationDatePrefixFilename(fileCopier);
            }

            if (cfg.GroupByCreationDate || cfg.GroupByExtension)
            {
                var groupings = new SortedList<int, IGroupingStrategy>();
                if (cfg.GroupByCreationDate)
                {
                    groupings.Add(1, new GroupByCreationDate());
                }

                if (cfg.GroupByExtension)
                {
                    groupings.Add(2, new GroupByExtension());
                }

                fileCopier = new FileCopierWithGrouping(fileCopier, groupings);
            }

            if (cfg.FilteredExtensions?.Length > 0)
            {
                fileCopier = new FileCopierWithExtensionsFilter(fileCopier, cfg.FilteredExtensions);
            }

            fileCopier = new FileCopierWithRenamingDuplicates(fileCopier);

            return fileCopier;
        }
    }
}