using System;
//using static System.Console;

namespace CS_HelloWorld
{
	class Program
	{
		static void Main()//(string[] args)
		{
			// System.Console.WriteLine("Hello, World!");
			// System.Console.WriteLine("Program Completed. Press any key to exit...");
			// System.Console.ReadKey();
			
			//Console.WriteLine("Hello, World!");
			//Console.WriteLine("Hello, {0}!", args[0]);
			//Console.WriteLine($"Hello, {args[0]}!");
			//Console.WriteLine("Program Completed. Press any key to exit...");
			//Console.ReadKey();
			
			
			
			// WriteLine("Hello, World!");
			// WriteLine("Program Completed. Press any key to exit...");
			// ReadKey();
			
			string name=string.Empty;
			Console.Write("Enter your name: ");
			name = Console.ReadLine();
			Console.WriteLine("Hello, {0}!", name);
			Console.Write("Program Completed. Press any key to exit...");
			Console.ReadKey();
		}
	}
}