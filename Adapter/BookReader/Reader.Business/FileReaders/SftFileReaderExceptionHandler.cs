using Reader.Business.Exceptions;
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
