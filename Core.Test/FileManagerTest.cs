using System;
using System.Collections.Generic;

using Core.Enums;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test {
	[TestClass]
	public class FileManagerTest {
		private FileManager fakeFileManager;

		[TestInitialize]
		public void SetUp() {
			File file1 = new File("SomeFile", @"D:\Documents", 1024);
			File file2 = new File("Another file", @"D:\Pictures", 2048);

			List<File> files = new List<File> {
				file1,
				file2
			};

			IMemory storage = new Storage {
				Capacity = 8192
			};

			fakeFileManager = new FileManager(files, storage);
		}
		[TestMethod]
		public void CutFileEndingAfterCloningTest_FileNameWithParentheses_ExpectCorrect() {
			string fileName = "Some File with some name after cloning (1)";
			string actualFileName;
			string expectedFileName = "Some File with some name after cloning";

			actualFileName = fakeFileManager.CutFileEndingAfterCloning(fileName);

			Assert.AreEqual(expectedFileName, actualFileName);
		}
		[TestMethod]
		public void CutFileEndingAfterCloningTest_FileNameWithoutParentheses_ExpectCorrect() {
			string fileName = "Some File with some name after cloning";
			string actualFileName;
			string expectedFileName = "Some File with some name after cloning";

			actualFileName = fakeFileManager.CutFileEndingAfterCloning(fileName);

			Assert.AreEqual(expectedFileName, actualFileName);
		}
		[TestMethod]
		public void CopyFile_FileExist_ExpectExceedingAvailableSpace() {
			string fileName = "Another file";
			string path = @"D:\Pictures";
			string newPath = @"D:\Pictures";
			int expectedFilesCount = 2;
			int expectedSpaceUsed = 3072;
			OperationResult expectedResult = OperationResult.ExceedingAvailableSpace;
			fakeFileManager.Storage.Capacity = 4096;

			OperationResult actualResult = fakeFileManager.CopyFile(fileName, path, newPath);

			Assert.AreEqual(expectedResult, actualResult);
			Assert.AreEqual(expectedFilesCount, fakeFileManager.Files.Count);
			Assert.AreEqual(expectedSpaceUsed, fakeFileManager.Storage.UsedSpace);
		}
		[TestMethod]
		public void CopyFile_FileNotExist_ExpectFileNotFound() {
			string fileName = "Non-existing file";
			string path = @"D:\Pictures";
			string newPath = @"D:\Pictures";
			int expectedFilesCount = 2;
			int expectedSpaceUsed = 3072;
			OperationResult expectedResult = OperationResult.FileNotFound;

			OperationResult actualResult = fakeFileManager.CopyFile(fileName, path, newPath);

			Assert.AreEqual(expectedResult, actualResult);
			Assert.AreEqual(expectedFilesCount, fakeFileManager.Files.Count);
			Assert.AreEqual(expectedSpaceUsed, fakeFileManager.Storage.UsedSpace);
		}
		[TestMethod]
		public void CreateFile_NewFile_ExpectNewFileCreated() {
			string fileName = "New File";
			string path = @"D:\Videos\31.08.2016";
			int size = 1024;
			int expectedFilesCount = 3;
			int expectedUsedSpace = 4096;
			OperationResult expectedResult = OperationResult.Success;
			OperationResult actualResult;

			actualResult = fakeFileManager.CreateFile(fileName, path, size);

			Assert.AreEqual(expectedResult, actualResult);
			Assert.AreEqual(expectedFilesCount, fakeFileManager.Files.Count);
			Assert.AreEqual(expectedUsedSpace, fakeFileManager.Storage.UsedSpace);
		}
		[TestMethod]
		public void CreateFile_NewFile_ExpectNoFileCreated() {
			string fileName = "SomeFile";
			string path = @"D:\Documents";
			int size = 1024;
			int expectedFilesCount = 2;
			int expectedUsedSpace = 3072;
			OperationResult expectedResult = OperationResult.FileAlreadyExist;
			OperationResult actualResult;

			actualResult = fakeFileManager.CreateFile(fileName, path, size);

			Assert.AreEqual(expectedResult, actualResult);
			Assert.AreEqual(expectedFilesCount, fakeFileManager.Files.Count);
			Assert.AreEqual(expectedUsedSpace, fakeFileManager.Storage.UsedSpace);
		}
	}
}
