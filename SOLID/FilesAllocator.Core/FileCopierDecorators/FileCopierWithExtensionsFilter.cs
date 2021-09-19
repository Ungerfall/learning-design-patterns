using System.Collections.Generic;
using System.Linq;

namespace FilesAllocator.Core.FileCopierDecorators
{
    internal class FileCopierWithExtensionsFilter : IFileCopier
    {
        private readonly IFileCopier @base;
        private readonly string[] extensions;

        public FileCopierWithExtensionsFilter(IFileCopier @base, string[] extensions)
        {
            this.@base = @base;
            this.extensions = extensions;
        }

        public int Copy(ICollection<File> files)
        {
            FilteredExtensions(files);
            return @base.Copy(files);
        }

        /// <summary>
        /// Filter files by extensions
        /// </summary>
        /// <param name="files"></param>
        private void FilteredExtensions(ICollection<File> files)
        {
            var removingFiles = files
                .Where(f =>
                {
                    var fileExtension = f.FileInfo.Extension.Replace(".", string.Empty);
                    return !extensions.Any(e => e.ToUpper().Equals(fileExtension.ToUpper()));
                })
                .ToArray();

            foreach (var file in removingFiles)
            {
                files.Remove(file);
            }
        }
    }
}