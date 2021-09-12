using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilesAllocator.Core
{
    public class Allocator : IAllocator
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
            var inputFiles = GetFilesByDirectory(inputDirectory, useSubFolders);
            var files = inputFiles.Select(f => new File(f)).ToList();

            if (creationDateTimePrefixName)
            {
                AddCreationDatePrefixForFilename(files);
            }

            if (groupByCreationDateHandler)
            {
                GroupByCreationDate(files);
            }

            if (filteredExtensions?.Length > 0)
            {
                FilteredExtensions(files, filteredExtensions);
            }

            RenameDuplicateFiles(files);

            var result = 0;
            foreach (var file in files)
            {
                var newFullName = Path.Combine(outputDirectory, file.EndpointFullName);

                try
                {
                    CopyFile(file.InitFullName, newFullName);
                    result++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }

        /// <summary>
        /// Get file list by path
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="useSubDirectories">Find files in sub-directories</param>
        /// <returns>List of files</returns>
        public IEnumerable<string> GetFilesByDirectory(string path, bool useSubDirectories = false)
        {
            var files = System.IO.Directory.GetFiles(path).ToList();

            if (useSubDirectories)
            {
                foreach (var dir in System.IO.Directory.GetDirectories(path))
                {
                    files.AddRange(GetFilesByDirectory(dir, true));
                }
            }

            return files;
        }

        /// <summary>
        /// Copy file from source to destination
        /// </summary>
        /// <param name="sourceFileName">Source filename</param>
        /// <param name="destFileName">Destination filename</param>
        public void CopyFile(string sourceFileName, string destFileName)
        {
            var destDirectory = Path.GetDirectoryName(destFileName);

            if (destDirectory == null)
            {
                throw new NullReferenceException("Cannot get destination directory.");
            }

            if (!System.IO.Directory.Exists(destDirectory))
            {
                System.IO.Directory.CreateDirectory(destDirectory);
            }

            System.IO.File.Copy(sourceFileName, destFileName, true);
        }

        /// <summary>
        /// Add GUID as postfix of filename for duplicated files
        /// </summary>
        /// <param name="files"></param>
        private void RenameDuplicateFiles(ICollection<File> files)
        {
            foreach (var file in files)
            {
                var hasDuplicate = files.Count(f => f.EndpointFullName.Equals(file.EndpointFullName)) > 1;
                if (!hasDuplicate) continue;

                var fileName = file.Name;
                var uniqueString = $"_{Guid.NewGuid():N}";
                var uniqueFileName = fileName.Insert(fileName.Length - file.FileInfo.Extension.Length, uniqueString);
                file.Name = uniqueFileName;
            }
        }

        /// <summary>
        /// Add the creation date of file as prefix for filename
        /// </summary>
        /// <param name="files"></param>
        private void AddCreationDatePrefixForFilename(ICollection<File> files)
        {
            foreach (var file in files)
            {
                DateTime? dateTaken;
                try
                {
                    var directories = ImageMetadataReader.ReadMetadata(file.FileInfo.FullName);
                    var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
                    dateTaken = subIfdDirectory?.GetDateTime(ExifDirectoryBase.TagDateTimeOriginal);
                }
                catch (ImageProcessingException)
                {
                    dateTaken = null;
                }

                var createDateTime = dateTaken ?? file.FileInfo.CreationTime;
                var createDate = createDateTime.ToString("yyyyMMdd");
                var createTime = createDateTime.ToString("HHmmss");
                file.Name = $"{createDate}-{createTime}_{file.Name}";
            }
        }

        /// <summary>
        /// Group files into directories by the creation date
        /// </summary>
        private void GroupByCreationDate(ICollection<File> files)
        {
            foreach (var file in files)
            {
                DateTime? dateTaken;
                try
                {
                    var directories = ImageMetadataReader.ReadMetadata(file.FileInfo.FullName);
                    var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
                    dateTaken = subIfdDirectory?.GetDateTime(ExifDirectoryBase.TagDateTimeOriginal);
                }
                catch (ImageProcessingException)
                {
                    dateTaken = null;
                }

                var createDateTime = dateTaken ?? file.FileInfo.CreationTime;
                var newFilePath = createDateTime.ToString("yyyy-MM-dd");

                file.EndpointDirectory = Path.Combine(
                    file.EndpointDirectory ?? string.Empty,
                    newFilePath);
            }
        }

        /// <summary>
        /// Filter files by extensions
        /// </summary>
        /// <param name="files"></param>
        /// <param name="extensions"></param>
        private void FilteredExtensions(ICollection<File> files, string[] extensions)
        {
            var removingFiles = files
                .Where(f =>
                {
                    var fileExtension = f.FileInfo.Extension.Replace(".", string.Empty);
                    return !extensions.Any(e => e.ToUpper().Equals(fileExtension.ToUpper()));
                })
                .ToArray();

            foreach (var file in removingFiles)
            {
                files.Remove(file);
            }
        }
    }
}