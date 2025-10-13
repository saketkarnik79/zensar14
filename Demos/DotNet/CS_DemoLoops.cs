using System;

namespace CS_DemoLoops
{
	class Program
	{
		static void Main()
		{
			// for ( int i = 1; i <= 10; i++)
			// {
				// Console.WriteLine("Iteration: {0}", i);
			// }
			
			// char proceed= 'y';
			// int i = 1;
			// while(char.Parse(proceed.ToString().ToLower()) == 'y')
			// {
				// Console.WriteLine("Iteration: {0}", i++);
				// Console.Write("Do you want to proceed further?<y/n>: ");
				// proceed = char.Parse(Console.ReadLine());
			// }
			
			char proceed;
			int i = 1;
			
			do
			{
				Console.WriteLine("Iteration: {0}", i++);
				Console.Write("Do you want to proceed further?<y/n>: ");
				proceed = char.Parse(Console.ReadLine());
			}while(char.Parse(proceed.ToString().ToLower()) == 'y');
			
			Console.WriteLine("Program Completed. Press any key to exit...");
			Console.ReadKey();
		}
	}
}