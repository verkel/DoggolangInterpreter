using System;
using System.IO;
using Antlr4.Runtime;

// Without this we have warnings when building the generated Antlr code
// https://github.com/tunnelvisionlabs/antlr4cs/issues/247
[assembly:CLSCompliant(false)]

namespace DoggolangInterpreter {
	public class Program {
		public static void Main(string[] args) {
			new Program().Run(args[0]);
		}

		private void Run(string filePath) {
			var input = new AntlrInputStream(new FileStream(filePath, FileMode.Open)); 
			var returnValue = Interpreter.Eval(input);
			Console.WriteLine(returnValue);
		}
	}
}