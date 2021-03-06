// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilesAllocator.Core
{

    public class Configuration
    {
        public string InputDirectory { get; set; }
        public string OutputDirectory { get; set; }
        public bool UseSubFolders { get; set; }

        public SortedList<int, IAllocatorInstruction> Instructions { get; set; } = new SortedList<int, IAllocatorInstruction>(); // TODO Где и как заполняется этот список?

        public static Configuration ParseJsonConfig()
        {
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .AddJsonFile("allocator.json", optional: false)
                    .Build();
                var input = configuration["inputDirectory"];
                var output = configuration["outputDirectory"];
                var useSubFolders = Convert.ToBoolean(configuration["useSubFolders"]);
                var creationDateTimePrefixName = Convert.ToBoolean(configuration["creationDateTimePrefixName"]);
                var groupByCreationDate = Convert.ToBoolean(configuration["groupByExtension"]);
                var groupByExtension = Convert.ToBoolean(configuration["groupByExtension"]);
                var filteredExtensions = configuration
                    .GetSection("filteredExtensions")
                    .GetChildren()
                    .Select(x => x.Value)
                    .ToArray();

                return new Configuration
                {
                    InputDirectory = input,
                    OutputDirectory = output,
                    UseSubFolders = useSubFolders
                };
            }
            catch (Exception e)
            {
                throw new Exception("Cannot parse configuration allocator.json", e);
            }
        }
    }

    public interface IAllocatorInstruction
    {
    }

    public sealed class CreationDateTimePrefixName : IAllocatorInstruction { }
    public sealed class GroupByCreationDateInstruction : IAllocatorInstruction { }
    public sealed class GroupByExtensionInstruction : IAllocatorInstruction
    {
        public GroupByExtensionInstruction(Dictionary<string, string> extensionToFolder)
        {
            ExtensionToFolder = extensionToFolder;
        }
        public  Dictionary<string, string> ExtensionToFolder { get; }
    }

    public sealed class FilteredExtensionsInstruction : IAllocatorInstruction
    {
        public FilteredExtensionsInstruction(string[] filteredExtensions)
        {
            FilteredExtensions = filteredExtensions;
        }

        public string[] FilteredExtensions { get; }
    }
}