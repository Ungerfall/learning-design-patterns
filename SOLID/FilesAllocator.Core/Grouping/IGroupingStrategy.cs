namespace FilesAllocator.Core.Grouping
{
    internal interface IGroupingStrategy
    {
        string GetGroupingFolderName(File file);
    }
}