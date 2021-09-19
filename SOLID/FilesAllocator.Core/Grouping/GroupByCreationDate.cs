using FilesAllocator.Core.Utils;

namespace FilesAllocator.Core.Grouping
{
    internal class GroupByCreationDate : IGroupingStrategy
    {
        public string GetGroupingFolderName(File file)
        {
            var dateTaken = file.GetMetadataDateTime();

            var createDateTime = dateTaken ?? file.FileInfo.CreationTime;
            return createDateTime.ToString("yyyy-MM-dd");
        }
    }
}