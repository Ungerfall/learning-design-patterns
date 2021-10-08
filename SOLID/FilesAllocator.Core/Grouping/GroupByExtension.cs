using System.Collections.Generic;

namespace FilesAllocator.Core.Grouping
{
    internal class GroupByExtension : IGroupingStrategy
    {
        private readonly Dictionary<string, string> extensionToFolder;

        public GroupByExtension(Dictionary<string, string> extensionToFolder)
        {
            this.extensionToFolder = extensionToFolder;
        }

        public string GetGroupingFolderName(File file)
        {
            var extension = file.FileInfo.Extension;
            return extensionToFolder.TryGetValue(extension, out var folder)
                ? folder
                : string.Empty;
        }
    }
}