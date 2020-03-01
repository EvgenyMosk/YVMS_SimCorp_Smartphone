using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;
using Core.Enums;

namespace YVMS_SC.ConsoleApp {
	public class Program {
		private static void Main(string[] args) {
			File file1 = new File("SomeFile", @"D:\Documents", 1024);
			File file2 = new File("Another file", @"D:\Pictures", 2048);

			List<File> files = new List<File> {
				file1,
				file2
			};

			IMemory storage = new Storage {
				Capacity = 4096
			};

			FileManager fileManager = new FileManager(files, storage);

			string fileName = "Another file";
			string path = @"D:\Pictures";

			File file = new File(fileName, path, 0);

			OperationResult opRes = fileManager.CopyFile(file, @"D:\Videos");


			Console.ReadLine();
		}
	}
}