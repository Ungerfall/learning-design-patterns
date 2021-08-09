using NUnit.Framework;
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
            return new SftFileReaderExceptionHandler(base.GetFileReader());
        }

        #endregion
    }
}
