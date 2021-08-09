using System;
using System.Collections.Generic;
using System.Text;

namespace Reader.Interfaces
{
    public interface IFileReader
    {
        void LoadFile(string path);
        string NextPage { get; }
        string PreviousPage { get; }
        string FirstPage { get; }
        string LastPage { get; }
        bool IsLastPage { get; }
        bool IsFirstPage { get; }
    }
}
