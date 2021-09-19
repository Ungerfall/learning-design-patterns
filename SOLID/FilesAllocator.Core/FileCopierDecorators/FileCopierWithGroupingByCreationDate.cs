using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                DateTime? dateTaken;
                try
                {
                    var directories = ImageMetadataReader.ReadMetadata(file.FileInfo.FullName);
                    var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
                    dateTaken = subIfdDirectory?.GetDateTime(ExifDirectoryBase.TagDateTimeOriginal);
                }
                catch (ImageProcessingException)
                {
                    dateTaken = null;
                }

                var createDateTime = dateTaken ?? file.FileInfo.CreationTime;
                var newFilePath = createDateTime.ToString("yyyy-MM-dd");

                file.EndpointDirectory = Path.Combine(
                    file.EndpointDirectory ?? string.Empty,
                    newFilePath);
            }
        }
    }
}