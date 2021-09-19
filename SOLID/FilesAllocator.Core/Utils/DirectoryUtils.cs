using System.Collections.Generic;
using System.Linq;

namespace FilesAllocator.Core.Utils
{
    internal class DirectoryUtils
    {
        public static IEnumerable<string> GetFilesByDirectory(string path, bool useSubDirectories = false)
        {
            var files = System.IO.Directory.GetFiles(path).ToList();

            if (useSubDirectories)
            {
                foreach (var dir in System.IO.Directory.GetDirectories(path))
                {
                    files.AddRange(GetFilesByDirectory(dir, true));
                }
            }

            return files;
        }
    }
}