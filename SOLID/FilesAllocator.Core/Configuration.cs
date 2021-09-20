using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace FilesAllocator.Core
{
    internal class Configuration
    {
        public bool CreationDateTimePrefixName { get; set; }
        public bool GroupByCreationDate { get; set; }
        public bool GroupByExtension { get; set; }
        public string[] FilteredExtensions { get; set; }

        internal static Configuration ParseJsonConfig()
        {
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .AddJsonFile("allocator.json", optional: false)
                    .Build();
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
                    CreationDateTimePrefixName = creationDateTimePrefixName,
                    GroupByCreationDate = groupByCreationDate,
                    GroupByExtension = groupByExtension,
                    FilteredExtensions = filteredExtensions
                };
            }
            catch (Exception e)
            {
                throw new Exception("Cannot read configuration allocator.json", e);
            }
        }
    }
}