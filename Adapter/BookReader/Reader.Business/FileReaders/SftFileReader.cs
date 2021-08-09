using Reader.Interfaces;
using System.Xml;

namespace Reader.Business.FileReaders
{
    public class SftFileReader : IFileReader
    {
        private string[] _pages;
        private int _currentPageIndex;

        public void LoadFile(string path)
        {
            var doc = new XmlDocument();
            doc.Load(path);

            var docPages = doc.DocumentElement.SelectNodes("//page");
            _pages = new string[docPages.Count];

            for (int i = 0; i < _pages.Length; i++)
            {
                _pages[i] = docPages.Item(i).InnerText;
            }
        }

        public string NextPage => _pages[++_currentPageIndex];

        public string PreviousPage => _pages[--_currentPageIndex];

        public string FirstPage
        {
            get
            {
                _currentPageIndex = 0;
                return _pages[_currentPageIndex];
            }
        }

        public string LastPage
        {
            get 
            {
                _currentPageIndex = _pages.Length - 1;
                return _pages[_currentPageIndex]; 
            } 
        }

        public bool IsLastPage => _currentPageIndex == (_pages.Length - 1);

        public bool IsFirstPage => _currentPageIndex == 0;
    }
}
