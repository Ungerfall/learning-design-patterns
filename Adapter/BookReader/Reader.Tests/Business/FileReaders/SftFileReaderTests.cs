// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using NUnit.Framework;
using Reader.Business.Exceptions;
using Reader.Business.FileReaders;
using Reader.Interfaces;
using System.IO;
using System.Xml.Linq;

namespace Reader.Tests.Business.FileReaders
{
    public class SftFileReaderTests
    {
        protected string _test3PageFileName;
        protected string _testWrongFormatFileName;

        private string _firstPageText = "_firstPageText";
        private string _middlePageText = "_middlePageText";
        private string _lastPageText = "_lastPageText";

        [SetUp]
        public void SetUpTestsData()
        {
            _test3PageFileName = Create3PagesTestFile();
            _testWrongFormatFileName = CreateWrongFormatTestFile();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_test3PageFileName);
            File.Delete(_testWrongFormatFileName);
        }

        [Test]
        public void IsFirstPageCheck()
        {
            var sftReader = GetFileReader();
            sftReader.LoadFile(_test3PageFileName);

            Assert.IsTrue(sftReader.IsFirstPage);
        }

        [Test]
        public void IsLastPageCheck()
        {
            var sftReader = GetFileReader();
            sftReader.LoadFile(_test3PageFileName);
            var page = sftReader.NextPage;
            page = sftReader.NextPage;

            Assert.IsTrue(sftReader.IsLastPage);
        }

        [Test]
        public void FirstPageCheck()
        {
            var sftReader = GetFileReader();
            sftReader.LoadFile(_test3PageFileName);

            var page = sftReader.NextPage;
            var fisrtPage = sftReader.FirstPage;

            Assert.AreEqual(_firstPageText, fisrtPage);
        }

        [Test]
        public void LastPageCheck()
        {
            var sftReader = GetFileReader();
            sftReader.LoadFile(_test3PageFileName);
            var lastPage = sftReader.LastPage;

            Assert.AreEqual(_lastPageText, lastPage);
        }        

        #region protectedMethods

        protected virtual IFileReader GetFileReader()
        {
            return new SftFileReader();
        }

        protected string Create3PagesTestFile()
        {
            var fileText = new XElement("book", 
                new XElement("pages", 
                    new XElement("page", _firstPageText),
                    new XElement("page", _middlePageText),
                    new XElement("page", _lastPageText))).ToString();

            var filePath = GenerateTempFileName();

            File.WriteAllText(filePath, fileText);

            return filePath;
        }

        protected string CreateWrongFormatTestFile()
        {
            var filePath = GenerateTempFileName();

            File.WriteAllText(filePath, "wront format");

            return filePath;
        }

        protected string GenerateTempFileName()
        {
            return Path.GetTempFileName();
        }

        #endregion
    }
}
