using System.IO;

namespace FilesAllocator.Core
{
    internal class File
    {
        public File(string filePath) : this(filePath, endpointDirectory: string.Empty)
        {
        }

        public File(string filePath, string endpointDirectory)
        {
            FileInfo = new FileInfo(filePath);
            InitFullName = FileInfo.FullName;
            Name = FileInfo.Name;
            EndpointDirectory = endpointDirectory;
        }

        public FileInfo FileInfo { get; }

        public string InitFullName { get; }

        public string Name { get; set; }

        public string EndpointDirectory { get; set; }

        public string EndpointFullName =>
            Path.Combine(
                EndpointDirectory ?? string.Empty,
                Name);
    }
}