using System;

namespace CS_DemoNamedAndOptionalParameters
{
	class Program
	{
		static void Greet(string name = "Guest", int age = 0)
		{
			Console.WriteLine("Hello, {0}! You are {1} years old.", name, age);
		}
		
		static void Main()
		{
			//Using default values
			Greet();
			Greet("James");
			
			//Using named parameters
			Greet(age: 30, name: "James");
			
			//Mix of positional & named parameters
			Greet("James", age: 45);
			
			Console.WriteLine("Program Completed. Press any key to exit...");
			Console.ReadKey();
		}
	}
}