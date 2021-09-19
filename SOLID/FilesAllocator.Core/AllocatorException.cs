using System;

namespace FilesAllocator.Core
{
    public class AllocatorException : Exception
    {
        public AllocatorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}