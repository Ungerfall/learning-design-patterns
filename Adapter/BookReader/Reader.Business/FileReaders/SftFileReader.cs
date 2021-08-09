// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using Reader.Interfaces;
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
