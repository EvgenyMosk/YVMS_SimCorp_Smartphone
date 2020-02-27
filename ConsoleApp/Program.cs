using Core;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				Capacity = 8192
			};

			FileManager fileManager = new FileManager(files, storage);

			string fileName = "SomeFile";
			string path = @"D:\Documents\Lol";
			int size = 1024;
			OperationResult actualResult;

			File file = new File(fileName, path, 0);


			Console.ReadLine();
		}
	}
}