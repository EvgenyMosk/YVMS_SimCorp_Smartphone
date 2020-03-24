using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;

namespace Core {
	public class FileManager : Software, IFileManager {
		public IList<File> Files { get; set; }
		public IMemory Storage { get; set; }

		public FileManager(string model, string manufacturer, int? yearOfProduction, string version, int size,
			IList<File> files, IMemory storage)
			: base(model, manufacturer, yearOfProduction, version, size) {
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
			File fileToBeRemoved = FindFileInStorage(file);
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
		protected File FindFileInStorage(File file) {
			foreach (File fileItem in Files) {
				if (fileItem.Equals(file)) {
					return fileItem;
				}
			}
			return null;
		}
		protected bool FileExistInStorage(File file) {
			File foundFile = FindFileInStorage(file);
			if (foundFile == null) {
				return false;
			} else {
				return true;
			}
		}
		public OperationResult CopyFile(string fileName, string path, string newPath) {
			File searchCriteria = new File(fileName, path, 0);

			if (!FileExistInStorage(searchCriteria)) {
				return OperationResult.FileNotFound;
			}

			File foundFile = FindFileInStorage(searchCriteria);

			if (CreatingFileExceedAvailableSpace(foundFile)) {
				return OperationResult.NotEnoughSpaceOnDisk;
			}

			File newFile = foundFile.Clone() as File;
			CorrectFileNameAndPath(path, newPath, newFile);
			AddFileToStorage(newFile);

			return OperationResult.Success;
		}
		public OperationResult CopyFile(File fileToCopy, string newPath) {
			return CopyFile(fileToCopy.FileName, fileToCopy.Path, newPath);
		}
		protected void CorrectFileNameAndPath(string path, string newPath, File newFile) {
			newFile.Path = newPath;
			if (!path.Equals(newPath)) {
				newFile.FileName = CutFileNameEndingAfterCloning(newFile);
			}
		}
		public string CutFileNameEndingAfterCloning(string fileName) {
			string endingToBeRemoved = " (1)";

			if (fileName.EndsWith(endingToBeRemoved)) {
				int startIndexOfEnding = fileName.Length - endingToBeRemoved.Length;
				fileName = fileName.Remove(startIndexOfEnding);
			}
			return fileName;
		}
		public string CutFileNameEndingAfterCloning(File file) {
			return CutFileNameEndingAfterCloning(file.FileName);
		}

		public OperationResult CreateFile(string fileName, string path, int size) {
			File newFile = new File(fileName, path, size);

			if (FileExistInStorage(newFile)) {
				return OperationResult.FileAlreadyExist;
			}
			if (CreatingFileExceedAvailableSpace(newFile)) {
				return OperationResult.NotEnoughSpaceOnDisk;
			}

			AddFileToStorage(newFile);
			return OperationResult.Success;
		}

		public OperationResult DeleteFile(string fileName, string path) {
			File fileToBeDeleted = new File(fileName, path, 0);

			if (!FileExistInStorage(fileToBeDeleted)) {
				return OperationResult.FileNotFound;
			}

			File foundFile = FindFileInStorage(fileToBeDeleted);

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
			File fileToRename = new File(fileName, path, 0);
			return RenameFile(fileToRename, newFileName);
		}
		public OperationResult RenameFile(File fileToRename, string newFileName) {
			if (fileToRename.FileName.Equals(newFileName)) {
				return OperationResult.FileWithSuchNameAlreadyExist;
			}

			if (!FileExistInStorage(fileToRename)) {
				return OperationResult.FileNotFound;
			}

			for (int i = 0; i < Files.Count; i++) {
				if (Files[i].FileName.Equals(newFileName)) {
					return OperationResult.FileWithSuchNameAlreadyExist;
				}
			}

			File fileToRenameInStorage = FindFileInStorage(fileToRename);
			fileToRenameInStorage.FileName = newFileName;
			return OperationResult.Success;
		}

		public IEnumerable<File> SearchFiles(string fileName) {
			IEnumerable<File> foundFiles = Files.Where(x => x.FileName.ToLower().Equals(fileName.ToLower()));
			return foundFiles;
		}
	}
}