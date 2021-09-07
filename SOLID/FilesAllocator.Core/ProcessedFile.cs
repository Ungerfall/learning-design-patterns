using System.IO;

namespace FilesAllocator.Core
{
	public class ProcessedFile
	{
		#region Constructors

		public ProcessedFile(string filePath)
		{
			FileInfo = new FileInfo(filePath);
			InitFullName = FileInfo.FullName;
			Name = FileInfo.Name;
			EndpointDirectory = string.Empty;
		}

		#endregion

		#region Public properties

		public FileInfo FileInfo { get; }

		public string InitFullName { get; }

		public string Name { get; set; }

		public string EndpointDirectory { get; set; }

		public string EndpointFullName =>
			Path.Combine(
				EndpointDirectory ?? string.Empty,
				Name);

		#endregion
	}
}