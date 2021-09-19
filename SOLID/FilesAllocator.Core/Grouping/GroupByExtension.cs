using System.Collections.Generic;

namespace FilesAllocator.Core.Grouping
{
    internal class GroupByExtension : IGroupingStrategy
    {
        private readonly Dictionary<string, string> extensionToFolder = new Dictionary<string, string>
        {
            [".jpg"] = "Photo",
            [".txt"] = "Documents"
        };

        public string GetGroupingFolderName(File file)
        {
            var extension = file.FileInfo.Extension;
            return extensionToFolder.TryGetValue(extension, out var folder)
                ? folder
                : string.Empty;
        }
    }
}