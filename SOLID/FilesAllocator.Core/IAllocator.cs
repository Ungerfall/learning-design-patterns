using System.Collections.Generic;

namespace FilesAllocator.Core
{
    public interface IAllocator
    {
        int Copy(string inputDirectory,
            string outputDirectory,
            bool useSubFolders,
            bool creationDateTimePrefixName = false,
            bool groupByCreationDateHandler = false,
            string[] filteredExtensions = null);

        void CopyFile(string sourceFileName, string destFileName);

        IEnumerable<string> GetFilesByDirectory(string path, bool useSubDirectories = false);
    }
}