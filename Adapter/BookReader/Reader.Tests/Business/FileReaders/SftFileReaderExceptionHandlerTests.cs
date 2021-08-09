// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using NUnit.Framework;
using Reader.Business.Exceptions;
using Reader.Business.FileReaders;

namespace Reader.Tests.Business.FileReaders
{
    public class SftFileReaderExceptionHandlerTests : SftFileReaderTests
    {
        [Test]
        public void NextAfterLastPageOutOfRangeExceptionCheck()
        {
            var sftReader = GetFileReader();
            sftReader.LoadFile(_test3PageFileName);
            var page = sftReader.LastPage;

            Assert.Throws<PageOutOfRangeException>(() => page = sftReader.NextPage);
        }

        [Test]
        public void PreviousBeforeFirstPageOutOfRangeExceptionCheck()
        {
            var sftReader = GetFileReader();
            sftReader.LoadFile(_test3PageFileName);
            var page = sftReader.FirstPage;

            Assert.Throws<PageOutOfRangeException>(() => page = sftReader.PreviousPage);
        }

        [Test]
        public void FileNotExistsExceptionCheck()
        {
            var notExistFileName = @"C:\temp\file.txt";
            var sftReader = GetFileReader();

            Assert.Throws<FileNotExistException>(() => sftReader.LoadFile(notExistFileName));
        }

        [Test]
        public void FileNotLoadExceptionCheck()
        {
            var sftReader = GetFileReader();

            Assert.Throws<FileNotLoadException>(() => { var page = sftReader.NextPage; });
        }

        [Test]
        public void WrongFormatExceptionCheck()
        {
            var sftReader = GetFileReader();

            Assert.Throws<WrongFileFormatException>(() => sftReader.LoadFile(_testWrongFormatFileName));
        }

        #region protected methods

        protected override Interfaces.IFileReader GetFileReader()
        {
            return new FileReaderExceptionHandler(base.GetFileReader());
        }

        #endregion
    }
}
