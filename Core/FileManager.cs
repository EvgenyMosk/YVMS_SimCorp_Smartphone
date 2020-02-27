using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;

namespace Core {
	public class FileManager : Software, IFileManager {
		public List<File> Files { get; set; }
		public IMemory Storage { get; set; }

		public FileManager(IEnumerable<File> files, IMemory storage) {
			Storage = storage;
			Files = new List<File>();

			foreach (File file in files) {
				AddFileToStorage(file);
			}
		}
		protected void AddFileToStorage(File file) {
			Files.Add(file);
			Storage.UsedSpace += file.Size;
		}
		protected void RemoveFileFromStorage(File file) {
			File fileToBeRemoved = FindFile(file);
			Files.Remove(fileToBeRemoved);
			Storage.UsedSpace -= fileToBeRemoved.Size;
		}
		protected void RemoveFileFromStorage(string fileName, string path) {
			File file = new File(fileName, path, 0);
			RemoveFileFromStorage(file);
		}
		protected bool CreatingFileExceedAvailableSpace(File file) {
			int availableSpace = Storage.Capacity - Storage.UsedSpace;

			if (file.Size > availableSpace) {
				return true;
			}

			return false;
		}
		protected File FindFile(File file) {
			foreach (File fileItem in Files) {
				if (fileItem.Equals(file)) {
					return file;
				}
			}
			return null;
		}
		protected bool FileExist(File file) {
			File foundFile = FindFile(file);
			if (foundFile == null) {
				return false;
			} else {
				return true;
			}
		}
		public OperationResult CopyFile(string fileName, string path, string newPath) {
			File searchCriteria = new File(fileName, path, 0);

			if (!FileExist(searchCriteria)) {
				return OperationResult.FileNotFound;
			}
			if (CreatingFileExceedAvailableSpace(searchCriteria)) {
				return OperationResult.NotEnoughSpaceOnDisk;
			}

			File foundFile = FindFile(searchCriteria);

			File newFile = foundFile.Clone() as File;
			CorrectFileNameAndPath(path, newPath, newFile);
			AddFileToStorage(newFile);

			return OperationResult.Success;
		}

		protected void CorrectFileNameAndPath(string path, string newPath, File newFile) {
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
			return CutFileEndingAfterCloning(file.FileName);
		}
		public OperationResult CopyFile(File file, string newPath) {
			return CopyFile(file.FileName, file.Path, newPath);
		}

		public OperationResult CreateFile(string fileName, string path, int size) {
			File newFile = new File(fileName, path, size);

			if (FileExist(newFile)) {
				return OperationResult.FileAlreadyExist;
			}
			if (CreatingFileExceedAvailableSpace(newFile)) {
				return OperationResult.ExceedingAvailableSpace;
			}

			AddFileToStorage(newFile);
			return OperationResult.Success;
		}

		public OperationResult DeleteFile(string fileName, string path) {
			File fileToBeDeleted = new File(fileName, path, 0);

			if (!FileExist(fileToBeDeleted)) {
				return OperationResult.FileNotFound;
			}

			File foundFile = FindFile(fileToBeDeleted);

			RemoveFileFromStorage(foundFile);
			return OperationResult.Success;
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
