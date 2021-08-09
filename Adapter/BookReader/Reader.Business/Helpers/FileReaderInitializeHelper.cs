// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using Reader.Business.Enums;
using Reader.Business.Exceptions;
using Reader.Business.FileReaders;
using Reader.Interfaces;
using System;
using System.IO;

namespace Reader.Business.Helpers
{
    public static class FileReaderInitializeHelper
    {
        public static IFileReader GetReader(string fileName)
        {
            var fileType = GetFileType(fileName);

            switch (fileType)
            {
                case EFileType.Sft:
                    {
                        var reader = new SftFileReader();
                        return new SftFileReaderExceptionHandler(reader);
                    }
                default: throw new UnknownFileFormat();
            }
        }
        
        private static EFileType GetFileType(string fileName)
        {
            var extension = Path.GetExtension(fileName).TrimStart('.');
            if (extension.Equals(EFileType.Sft.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return EFileType.Sft;
            }

            if (extension.Equals(EFileType.Mft.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return EFileType.Mft;
            }

            throw new UnknownFileFormat();
        }
    }
}
