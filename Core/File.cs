using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class File : ICloneable {
		public string FileName { get; set; }
		public string Path { get; set; }
		public int Size { get; protected set; }

		public File(string fileName, string path, int size) {
			FileName = fileName;
			Path = path;
			Size = size;
		}

		public object Clone() {
			string newFileFileName = FileName + " (1)";
			string pathToNewFile = Path;
			return new File(newFileFileName, pathToNewFile, Size);
		}

		public override bool Equals(object obj) {
			File file = obj as File;

			if (file == null) {
				return false;
			} else {
				return GetHashCode().Equals(file.GetHashCode());
			}
		}
		public override int GetHashCode() {
			int hashCode = 1249530698;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FileName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Path);
			return hashCode;
		}
	}
}