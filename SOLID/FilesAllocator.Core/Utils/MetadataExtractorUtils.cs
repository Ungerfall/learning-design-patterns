using System;
using System.Linq;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace FilesAllocator.Core.Utils
{
    internal static class MetadataExtractorUtils
    {
        internal static DateTime? GetMetadataDateTime(this File file)
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

            return dateTaken;
        }
    }
}