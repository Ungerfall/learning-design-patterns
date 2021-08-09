using Reader.Business.Enums;
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
