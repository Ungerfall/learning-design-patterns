using System.Collections.Generic;

namespace FilesAllocator.Core
{
    internal interface IFileCopier
    {
        int Copy(ICollection<File> files);
    }
}