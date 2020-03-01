using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;

namespace Core {
	public interface IFileManager {
		IList<File> Files { get; set; }
		OperationResult CreateFile(string fileName, string path, int size);
		OperationResult CopyFile(string fileName, string path, string newPath);
		OperationResult CopyFile(File file, string newPath);
		OperationResult DeleteFile(string fileName, string path);
		string GetFileProperties(string fileName, string path);
		string GetFileProperties(File file);
		OperationResult RenameFile(string fileName, string path, string newFileName);
		OperationResult RenameFile(File file, string newFileName);
		IEnumerable<File> SearchFiles(string fileName);
	}
}
