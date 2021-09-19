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
    }
}