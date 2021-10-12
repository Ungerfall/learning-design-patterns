// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System;
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