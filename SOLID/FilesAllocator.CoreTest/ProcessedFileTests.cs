using FilesAllocator.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = FilesAllocator.Core.File;

namespace FilesAllocator.CoreTest
{
	[TestFixture]
	public class ProcessedFileTests
	{
		#region Tests

		[Test]
		public void Constructor_SuccessfulInitialization()
		{
			#region Arrange

			var fileName = "DSC00015.JPG";
			var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFolder", "Input", fileName);

			#endregion

			#region Act

			var file = new File(filePath);

			#endregion

			#region Assert

			Assert.That(file, Is.Not.Null);
			Assert.That(file.FileInfo, Is.Not.Null);
			Assert.That(file.InitFullName, Is.EqualTo(filePath));
			Assert.That(file.Name, Is.EqualTo(fileName));
			Assert.That(file.EndpointDirectory, Is.Empty);
			Assert.That(file.EndpointFullName, Is.EqualTo(fileName));

			#endregion
		}

		[Test]
		public void SetDirectoryAndName_CheckEndpointFullName()
		{
			#region Arrange

			var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFolder", "Input", "DSC00015.JPG");
			var file = new File(filePath);
			var endpointDirectory = "Test";
			var newName = "NewName.jpg";

			#endregion

			#region Act

			file.EndpointDirectory = endpointDirectory;
			file.Name = newName;

			#endregion

			#region Assert

			Assert.That(file.Name, Is.EqualTo(newName));
			Assert.That(file.EndpointDirectory, Is.EqualTo(endpointDirectory));
			Assert.That(file.EndpointFullName, Is.EqualTo($"{endpointDirectory}\\{newName}"));

			#endregion
		}

		#endregion
	}
}
