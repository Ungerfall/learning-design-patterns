﻿using Newtonsoft.Json;
using NUnit.Framework;
using Reader.Business.FileReaders.Softsystem;
using Reader.Interfaces;
using System.IO;
using System.Text;

namespace Reader.Tests.Business.FileReaders
{
    public class MftFileReaderTests
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
            return new MftFileReader();
        }

        protected string Create3PagesTestFile()
        {
            var sb = new StringBuilder();
            using var sw = new StringWriter(sb);
            using var jsonWriter = new JsonTextWriter(sw);

            jsonWriter.Formatting = Formatting.Indented;
            jsonWriter.WriteStartObject();
            jsonWriter.WritePropertyName("pages");
            jsonWriter.WriteStartArray();
            jsonWriter.WriteStartObject();
            jsonWriter.WritePropertyName("text");
            jsonWriter.WriteValue(_firstPageText);
            jsonWriter.WriteEndObject();
            jsonWriter.WriteStartObject();
            jsonWriter.WritePropertyName("text");
            jsonWriter.WriteValue(_middlePageText);
            jsonWriter.WriteEndObject();
            jsonWriter.WriteStartObject();
            jsonWriter.WritePropertyName("text");
            jsonWriter.WriteValue(_lastPageText);
            jsonWriter.WriteEndObject();
            jsonWriter.WriteEndArray();
            jsonWriter.WriteEndObject();

            var filePath = GenerateTempFileName();

            File.WriteAllText(filePath, sw.ToString());

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

        #endregion protectedMethods
    }
}