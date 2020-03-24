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

			IMemory storage = new Memory("fake_model", "fake_manufacturer", 9999, "v.1.2.3.4", 8192);

			fakeFileManager = new FileManager("fake_model", "fake_manufacturer", 9999, "v.1.2.3.4", 1, files, storage);
		}
		[TestMethod]
		public void CutFileEndingAfterCloning_FileNameWithParentheses_ExpectCorrect() {
			string fileName = "Some File with some name after cloning (1)";
			string actualFileName;
			string expectedFileName = "Some File with some name after cloning";

			actualFileName = fakeFileManager.CutFileNameEndingAfterCloning(fileName);

			Assert.AreEqual(expectedFileName, actualFileName);
		}
		[TestMethod]
		public void CutFileEndingAfterCloning_FileNameWithoutParentheses_ExpectCorrect() {
			string fileName = "Some File with some name after cloning";
			string actualFileName;
			string expectedFileName = "Some File with some name after cloning";

			actualFileName = fakeFileManager.CutFileNameEndingAfterCloning(fileName);

			Assert.AreEqual(expectedFileName, actualFileName);
		}
		[TestMethod]
		public void CopyFile_FileExist_ExpectNotEnoughSpaceOnDisk() {
			string fileName = "Another file";
			string path = @"D:\Pictures";
			string newPath = @"D:\Pictures";
			int expectedFilesCount = 2;
			int expectedSpaceUsed = 3072;
			OperationResult expectedResult = OperationResult.NotEnoughSpaceOnDisk;
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
		public void CopyFile_FileNotExist_ExpectSuccess() {
			string fileName = "SomeFile";
			string path = @"D:\Documents";
			string newPath = @"D:\Games";
			int expectedFilesCount = 3;
			int expectedSpaceUsed = 4096;
			OperationResult expectedResult = OperationResult.Success;

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
		public void CreateFile_ExistingFile_ExpectNoFileCreated() {
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
		[TestMethod]
		public void CreateFile_NewFile_ExpectNotEnoughSpaceOnDisk() {
			string fileName = "MS Word Document";
			string path = @"D:\Documents";
			int size = 6144;
			int expectedFilesCount = 2;
			int expectedUsedSpace = 3072;
			OperationResult expectedResult = OperationResult.NotEnoughSpaceOnDisk;
			OperationResult actualResult;

			actualResult = fakeFileManager.CreateFile(fileName, path, size);

			Assert.AreEqual(expectedResult, actualResult);
			Assert.AreEqual(expectedFilesCount, fakeFileManager.Files.Count);
			Assert.AreEqual(expectedUsedSpace, fakeFileManager.Storage.UsedSpace);
		}
		[TestMethod]
		public void RenameFile_NewValidFileName_ExpectFileWasRenamed() {
			string fileName = "SomeFile";
			string path = @"D:\Documents";
			string newFileName = "RenamedFile";
			int expectedUsedSpace = 3072;
			List<string> expectedFileNames = new List<string> {
				"RenamedFile",
				"Another file"
			};
			int expectedFilesCount = expectedFileNames.Count;
			OperationResult expectedResult = OperationResult.Success;
			OperationResult actualResult;

			actualResult = fakeFileManager.RenameFile(fileName, path, newFileName);

			Assert.AreEqual(expectedResult, actualResult);
			Assert.AreEqual(expectedFilesCount, fakeFileManager.Files.Count); // Check against expectedFileNames which serves as "expectedFilesCount" in another Test Cases
			Assert.AreEqual(expectedUsedSpace, fakeFileManager.Storage.UsedSpace);
			for (int i = 0; i < expectedFileNames.Count; i++) {
				Assert.AreEqual(expectedFileNames[i], fakeFileManager.Files[i].FileName);
			}
		}
		[TestMethod]
		public void RenameFile_ExistingFileName_ExpectFileWasNotRenamed() {
			string fileName = "SomeFile";
			string path = @"D:\Documents";
			string newFileName = "SomeFile";
			int expectedUsedSpace = 3072;
			List<string> expectedFileNames = new List<string> {
				"SomeFile",
				"Another file"
			};
			int expectedFilesCount = expectedFileNames.Count;
			OperationResult expectedResult = OperationResult.FileWithSuchNameAlreadyExist;
			OperationResult actualResult;

			actualResult = fakeFileManager.RenameFile(fileName, path, newFileName);

			Assert.AreEqual(expectedResult, actualResult);
			Assert.AreEqual(expectedFilesCount, fakeFileManager.Files.Count);
			Assert.AreEqual(expectedUsedSpace, fakeFileManager.Storage.UsedSpace);
			for (int i = 0; i < expectedFileNames.Count; i++) {
				Assert.AreEqual(expectedFileNames[i], fakeFileManager.Files[i].FileName);
			}
		}
		[TestMethod]
		public void RenameFile_FileNotExist_ExpectFileNotFound() {
			string fileName = "Very interesting filename";
			string path = @"D:\Documents";
			string newFileName = "Even more interesting filename";
			int expectedUsedSpace = 3072;
			List<string> expectedFileNames = new List<string> {
				"SomeFile",
				"Another file"
			};
			int expectedFilesCount = expectedFileNames.Count;
			OperationResult expectedResult = OperationResult.FileNotFound;
			OperationResult actualResult;

			actualResult = fakeFileManager.RenameFile(fileName, path, newFileName);

			Assert.AreEqual(expectedResult, actualResult);
			Assert.AreEqual(expectedFilesCount, fakeFileManager.Files.Count);
			Assert.AreEqual(expectedUsedSpace, fakeFileManager.Storage.UsedSpace);
			for (int i = 0; i < expectedFileNames.Count; i++) {
				Assert.AreEqual(expectedFileNames[i], fakeFileManager.Files[i].FileName);
			}
		}
	}
}