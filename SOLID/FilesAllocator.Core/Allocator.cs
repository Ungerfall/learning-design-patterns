using FilesAllocator.Core.FileCopierDecorators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilesAllocator.Core
{
    public sealed class Allocator : IAllocator
    {
        /// <summary>
        /// Copying files from inputDirectory to outputDirectory
        /// </summary>
        /// <param name="inputDirectory">Input directory</param>
        /// <param name="outputDirectory">Output directory</param>
        /// <param name="useSubFolders">Copying files from sub-directories</param>
        /// <param name="creationDateTimePrefixName">TRUE - if you need to add the creation date of file as prefix for filename</param>
        /// <param name="groupByCreationDateHandler">TRUE - if you need to group files into directories by the creation date</param>
        /// <param name="filteredExtensions">Array of type extensions which should be copying</param>
        /// <returns>Count of copied files</returns>
        public int Copy(string inputDirectory,
            string outputDirectory,
            bool useSubFolders,
            bool creationDateTimePrefixName = false,
            bool groupByCreationDateHandler = false,
            string[] filteredExtensions = null)
        {
            try
            {
                IFileCopier fileCopier = new FileCopier();

                var inputFiles = DirectoryUtils.GetFilesByDirectory(inputDirectory, useSubFolders);
                var files = inputFiles.Select(f => new File(f, outputDirectory)).ToList();

                if (creationDateTimePrefixName)
                {
                    fileCopier = new FileCopierWithCreationDatePrefixFilename(fileCopier);
                }

                if (groupByCreationDateHandler)
                {
                    fileCopier = new FileCopierWithGroupingByCreationDate(fileCopier);
                }

                if (filteredExtensions?.Length > 0)
                {
                    fileCopier = new FileCopierWithExtensionsFilter(fileCopier, filteredExtensions);
                }

                fileCopier = new FileCopierWithRenamingDuplicates(fileCopier);

                return fileCopier.Copy(files);
            }
            catch (Exception e)
            {
                throw new AllocatorException("See inner exception for details", e);
            }
        }

        /// <summary>
        /// Get file list by path
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="useSubDirectories">Find files in sub-directories</param>
        /// <returns>List of files</returns>
        public IEnumerable<string> GetFilesByDirectory(string path, bool useSubDirectories = false)
        {
            try
            {
                return DirectoryUtils.GetFilesByDirectory(path, useSubDirectories);
            }
            catch (Exception e)
            {
                throw new AllocatorException("See inner exception for details", e);
            }
        }
    }
}