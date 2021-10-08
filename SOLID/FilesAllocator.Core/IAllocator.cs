using System;
using System.Collections.Generic;

namespace FilesAllocator.Core
{
    public interface IAllocator
    {
        [Obsolete]
        int Copy(string inputDirectory,
            string outputDirectory,
            bool useSubFolders,
            bool creationDateTimePrefixName = false,
            bool groupByCreationDateHandler = false,
            string[] filteredExtensions = null);
        int Copy(Configuration configuration);
        IEnumerable<string> GetFilesByDirectory(string path, bool useSubDirectories = false);
    }
}