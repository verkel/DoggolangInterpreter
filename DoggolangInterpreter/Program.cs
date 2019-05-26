using System;

namespace DoggolangInterpreter {
	public class Program {
		public static void Main(string[] args) {
			new Program().Run(args[0]);
		}

		private void Run(string filePath) {
			Interpreter.Eval(filePath);
		}
	}
}