// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using Reader.Business.Exceptions;
using Reader.Interfaces;
using System.IO;

namespace Reader.Business.FileReaders
{
    public class SftFileReaderExceptionHandler : IFileReader
    {
        private IFileReader _fileReader;
        private bool _fileIsLoad = false;

        public SftFileReaderExceptionHandler(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public string NextPage 
        {
            get
            {
                CheckFileIsLoad();

                try
                {
                    return _fileReader.NextPage;
                }
                catch
                {
                    throw new PageOutOfRangeException();
                }
            }
        }

        public string PreviousPage
        {
            get
            {
                CheckFileIsLoad();

                try
                {
                    return _fileReader.PreviousPage;
                }
                catch
                {
                    throw new PageOutOfRangeException();
                }
            }
        }

        public string FirstPage
        {
            get
            {
                CheckFileIsLoad();

                try
                {
                    return _fileReader.FirstPage;
                }
                catch
                {
                    throw new PageOutOfRangeException();
                }
            }
        }

        public string LastPage
        {
            get
            {
                CheckFileIsLoad();

                try
                {
                    return _fileReader.LastPage;
                }
                catch
                {
                    throw new PageOutOfRangeException();
                }
            }
        }

        public bool IsLastPage
        {
            get
            {
                CheckFileIsLoad();

                return _fileReader.IsLastPage;
            }
        }

        public bool IsFirstPage 
        {
            get
            {
                CheckFileIsLoad();

                return _fileReader.IsFirstPage;
            }
        }

        public void LoadFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotExistException();
            }

            try
            {
                _fileIsLoad = false;
                _fileReader.LoadFile(path);
                _fileIsLoad = true;
            }
            catch
            {
                throw new WrongFileFormatException();
            }
        }

        private void CheckFileIsLoad()
        {
            if (!_fileIsLoad)
                throw new FileNotLoadException();
        }
    }
}
