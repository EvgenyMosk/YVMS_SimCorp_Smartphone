using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YVMS_SC.ConsoleApp {
	public class Program {
		private static void Main(string[] args) {
			List<File> files = new List<File> {
				new File("CV.docx", @"D:\Documents\", 512),
				new File("Some book.pdf", @"D:\Documents\", 512)
			};

			File file1 = new File("CV.docx", @"D:\Documents\", 0);
			File file2 = new File("CV.doc", @"D:\Documents\", 0);

			string fileName = "Some File Name (1)";
			string endingToBeRemoved = " (1)";

			if (fileName.EndsWith(endingToBeRemoved)) {
				int startIndexOfEnding = fileName.Length - endingToBeRemoved.Length;
				fileName = fileName.Remove(startIndexOfEnding);
			}

			Console.WriteLine(fileName);
			Console.ReadLine();
		}
	}
}