using System;
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