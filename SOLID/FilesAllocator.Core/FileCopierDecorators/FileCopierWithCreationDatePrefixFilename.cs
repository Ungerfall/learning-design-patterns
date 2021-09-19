using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilesAllocator.Core.FileCopierDecorators
{
    internal class FileCopierWithCreationDatePrefixFilename : IFileCopier
    {
        private readonly IFileCopier @base;

        public FileCopierWithCreationDatePrefixFilename(IFileCopier @base)
        {
            this.@base = @base;
        }

        public int Copy(ICollection<File> files)
        {
            AddCreationDatePrefixForFilename(files);
            return @base.Copy(files);
        }

        private static void AddCreationDatePrefixForFilename(ICollection<File> files)
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
                var createDate = createDateTime.ToString("yyyyMMdd");
                var createTime = createDateTime.ToString("HHmmss");
                file.Name = $"{createDate}-{createTime}_{file.Name}";
            }
        }
    }
}