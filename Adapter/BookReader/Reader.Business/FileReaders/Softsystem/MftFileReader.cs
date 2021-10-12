// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using Reader.Interfaces;
using Softsystem.Book;

namespace Reader.Business.FileReaders.Softsystem
{
    public class MftFileReader : IFileReader
    {
        private MftBook book;
        private int _currentPageIndex = 0;

        public void LoadFile(string path)
        {
            book = new MftBook(path);
            _currentPageIndex = 0;
        }

        public string NextPage => book.GetPage(++_currentPageIndex);

        public string PreviousPage => book.GetPage(--_currentPageIndex);

        public string FirstPage
        {
            get
            {
                _currentPageIndex = 0;
                return book.GetPage(_currentPageIndex);
            }
        }

        public string LastPage
        {
            get
            {
                _currentPageIndex = book.PageCount - 1;
                return book.GetPage(_currentPageIndex);
            }
        }

        public bool IsLastPage => _currentPageIndex == book.PageCount - 1;

        public bool IsFirstPage => _currentPageIndex == 0;
    }
}