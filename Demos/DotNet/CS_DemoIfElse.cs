using System;

namespace CS_DemoIfElse
{
	class Program
	{
		static void Main()
		{
			int n1;
			int n2;
			
			Console.Write("Enter first number: ");
			n1 = int.Parse(Console.ReadLine());
			Console.Write("Enter second number: ");
			n2 = int.Parse(Console.ReadLine());
			
			Console.WriteLine();
			
			if(n1 > n2)
			{
				Console.WriteLine("n1 is greater.");
			}
			else if(n2 > n1)
			{
				Console.WriteLine("n2 is greater.");
			}
			else
			{
				Console.WriteLine("n1 & n2 are equal.");
			}
			Console.Write("\n\nProgram Completed. Press any key to exit...");
			Console.ReadKey();
		}
	}
}