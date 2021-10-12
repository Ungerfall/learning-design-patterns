// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System.IO;

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