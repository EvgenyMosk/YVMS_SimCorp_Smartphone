using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class FileManager : Software, IFileManager {
		public List<File> Files { get; set; }

		public FileManager(IEnumerable<File> files) {
			Files = files.ToList();
		}

		public OperationResult CopyFile(string fileName, string path, string newPath) {
			File searchCriteria = new File(fileName, path, 0);
			File foundFile = Files.Where(x => x.Equals(searchCriteria)) as File;

			if (foundFile == null) {
				return OperationResult.FileNotFound;
			}

			File newFile = foundFile.Clone() as File;
			CorrectFileNameAndPath(path, newPath, newFile);

			Files.Add(newFile);
			return OperationResult.Success;
		}

		private void CorrectFileNameAndPath(string path, string newPath, File newFile) {
			newFile.Path = newPath;
			if (!path.Equals(newPath)) {
				newFile.FileName = CutFileEndingAfterCloning(newFile);
			}
		}

		public string CutFileEndingAfterCloning(string fileName) {
			string endingToBeRemoved = " (1)";

			if (fileName.EndsWith(endingToBeRemoved)) {
				int startIndexOfEnding = fileName.Length - endingToBeRemoved.Length;
				fileName = fileName.Remove(startIndexOfEnding);
			}
			return fileName;
		}
		public string CutFileEndingAfterCloning(File file) {
			string fileName = file.FileName;
			string endingToBeRemoved = " (1)";

			if (fileName.EndsWith(endingToBeRemoved)) {
				int startIndexOfEnding = fileName.Length - endingToBeRemoved.Length;
				fileName = fileName.Remove(startIndexOfEnding);
			}
			return fileName;
		}
		public OperationResult CopyFile(File file, string newPath) {
			CopyFile(file.FileName, file.Path, newPath);
			throw new NotImplementedException();
		}

		public OperationResult CreateFile(string fileName, string path, int size) {
			throw new NotImplementedException();
		}

		public OperationResult DeleteFile(string fileName, string path) {
			throw new NotImplementedException();
		}

		public string GetFileProperties(string fileName, string path) {
			throw new NotImplementedException();
		}

		public string GetFileProperties(File file) {
			GetFileProperties(file.FileName, file.Path);
			throw new NotImplementedException();
		}

		public OperationResult RenameFile(string fileName, string path, string newFileName) {
			throw new NotImplementedException();
		}

		public OperationResult RenameFile(File file, string newFileName) {
			RenameFile(file.FileName, file.Path, newFileName);
			throw new NotImplementedException();
		}

		public IEnumerable<File> SearchFiles(string fileName) {
			IEnumerable<File> foundFiles = Files.Where(x => x.FileName.ToLower().Equals(fileName.ToLower()));
			return foundFiles;
		}
	}
}
