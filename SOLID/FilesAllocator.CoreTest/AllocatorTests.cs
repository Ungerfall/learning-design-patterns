using System;
using System.IO;
using System.Linq;
using FilesAllocator.Core;
using NUnit.Framework;

namespace FilesAllocator.CoreTest
{
	[TestFixture]
	public class AllocatorTests
	{
		#region Fields

		private readonly string _inputFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFolder", "Input");

		private readonly string _outputFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFolder", "Output");

		private readonly Allocator _allocator = new Allocator();

		#endregion

		#region SetUp & TearDown

		[SetUp]
		public void SetUp()
		{
			DeleteOutputFolder();
		}

		[TearDown]
		public void TearDown()
		{
			DeleteOutputFolder();
		}

		#endregion

		#region Tests

		[Test]
		public void GetFilesByDirectory_WithoutSubDirectories_CheckFilesCount()
		{
			#region Arragne

			var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFolder", "Input");

			#endregion

			#region Act

			var files = _allocator.GetFilesByDirectory(directory, false);

			#endregion

			#region Assert


			Assert.That(files.Count(), Is.EqualTo(2));

			#endregion
		}

		[Test]
		public void GetFilesByDirectory_WithSubDirectories_CheckFilesCount()
		{
			#region Arragne

			var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFolder", "Input");

			#endregion

			#region Act

			var files = _allocator.GetFilesByDirectory(directory, true);

			#endregion

			#region Assert


			Assert.That(files.Count(), Is.EqualTo(6));

			#endregion
		}


		[Test]
		public void Copy_WithoutSubfolders_CopiedFilesCount()
		{
			#region Act

			var copiedFilesCount = _allocator.Copy(
				_inputFolder,
				_outputFolder, 
				false);

			#endregion

			#region Asserts

			Assert.That(copiedFilesCount, Is.EqualTo(2));

			#endregion
		}

		[Test]
		public void Copy_WithSubfolders_CopiedFilesCount()
		{
			#region Act

			var copiedFilesCount = _allocator.Copy(
				_inputFolder,
				_outputFolder,
				true);

			#endregion

			#region Asserts

			Assert.That(copiedFilesCount, Is.EqualTo(6));

			#endregion
		}

		[Test]
		public void Copy_WithoutAlgorithm_CheckOutput()
		{
			#region Act

			_allocator.Copy(
				_inputFolder, 
				_outputFolder, 
				true);

			#endregion

			#region Assert

			Assert.That(Directory.GetFiles(_outputFolder).Length, Is.EqualTo(6));

			#endregion
		}

		[Test]
		public void Copy_SeveralAlgorithms_CheckOutput()
		{
			#region Arrange

			#endregion

			#region Act

			_allocator.Copy(_inputFolder, _outputFolder, true, true, true, new string[] { "jpg" });

			#endregion

			#region Assert

			/*
			 * Check next folder tree
			 * -- OutputFolder
			 * ---- 2015-10-02
			 * ------ (1 file)
			 * ---- 2017-11-17
			 * ------ (1 file)
			 */

			Assert.That(Directory.Exists(Path.Combine(_outputFolder, "2015-10-02")), Is.True);
			Assert.That(Directory.GetFiles(Path.Combine(_outputFolder, "2015-10-02")).Length, Is.EqualTo(1));

			Assert.That(Directory.Exists(Path.Combine(_outputFolder, "2020-11-17")), Is.True);
			Assert.That(Directory.GetFiles(Path.Combine(_outputFolder, "2020-11-17")).Length, Is.EqualTo(1));

			Assert.That(Directory.GetDirectories(_outputFolder).Length, Is.EqualTo(2));

			#endregion
		}

		[Test]
		public void CopyNew_WithoutSubfolders_CopiedFilesCount()
		{
			#region Act

            var copiedFilesCount = _allocator.Copy(
                new Configuration
                {
                    InputDirectory = _inputFolder,
                    OutputDirectory = _outputFolder,
                    UseSubFolders = false
                });

			#endregion

			#region Asserts

			Assert.That(copiedFilesCount, Is.EqualTo(2));

			#endregion
		}

		[Test]
		public void CopyNew_WithSubfolders_CopiedFilesCount()
		{
			#region Act

			var copiedFilesCount = _allocator.Copy(
                new Configuration
                {
                    InputDirectory = _inputFolder,
                    OutputDirectory = _outputFolder,
                    UseSubFolders = true
                });

			#endregion

			#region Asserts

			Assert.That(copiedFilesCount, Is.EqualTo(6));

			#endregion
		}

		[Test]
		public void CopyNew_WithoutAlgorithm_CheckOutput()
		{
			#region Act

			_allocator.Copy(
                new Configuration
                {
                    InputDirectory = _inputFolder,
                    OutputDirectory = _outputFolder,
                    UseSubFolders = true
                });

			#endregion

			#region Assert

			Assert.That(Directory.GetFiles(_outputFolder).Length, Is.EqualTo(6));

			#endregion
		}

		#endregion

		#region Helper methods

		private void DeleteOutputFolder()
		{
			if (Directory.Exists(_outputFolder))
			{
				Directory.Delete(_outputFolder, true);
			}
		}

		#endregion
	}
}