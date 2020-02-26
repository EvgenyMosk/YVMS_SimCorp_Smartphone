using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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

			fakeFileManager = new FileManager(files);
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
		public void CopyFile_FileExists_ExpectIncorrect() {
			File fileToCopy = new File("SomeFile", @"D:\Documents", 1024);
			string newFileName
		}
	}
}
