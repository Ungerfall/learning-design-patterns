using System.Collections.Generic;
using System.IO;
using FilesAllocator.Core.Utils;

namespace FilesAllocator.Core.FileCopierDecorators
{
    internal class FileCopierWithGroupingByCreationDate : IFileCopier
    {
        private readonly IFileCopier @base;

        public FileCopierWithGroupingByCreationDate(IFileCopier @base)
        {
            this.@base = @base;
        }

        public int Copy(ICollection<File> files)
        {
            GroupByCreationDate(files);
            return @base.Copy(files);
        }

        /// <summary>
        /// Group files into directories by the creation date
        /// </summary>
        private static void GroupByCreationDate(ICollection<File> files)
        {
            foreach (var file in files)
            {
                var dateTaken = file.GetMetadataDateTime();

                var createDateTime = dateTaken ?? file.FileInfo.CreationTime;
                var newFilePath = createDateTime.ToString("yyyy-MM-dd");

                file.EndpointDirectory = Path.Combine(
                    file.EndpointDirectory ?? string.Empty,
                    newFilePath);
            }
        }
    }
}