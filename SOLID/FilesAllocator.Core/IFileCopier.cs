using System;
using System.IO;

namespace FilesAllocator.Core
{
    internal interface IFileCopier
    {
        void CopyFile(string sourceFileName, string destFileName);
    }

    internal class FileCopier : IFileCopier
    {
        public void CopyFile(string sourceFileName, string destFileName)
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

            System.IO.File.Copy(sourceFileName, destFileName, true);
        }
    }
}