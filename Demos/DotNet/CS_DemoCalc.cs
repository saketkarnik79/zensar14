using System;

namespace CS_DemoCalc
{
	class Program
	{
		static void Main()
		{
			int n1;
			int n2;
			int sum = 0;
			
			Console.Write("Enter First Number: ");
			n1 = int.Parse(Console.ReadLine());
			Console.Write("Enter Second Number: ");
			n2 = int.Parse(Console.ReadLine());
			
			sum = n1 + n2;
			Console.WriteLine("\n\nThe sum of {0} and {1} is {2}", n1, n2, sum);
			Console.Write("\n\nProgram completed. Press any key to exit...");
			Console.ReadKey();
		}
	}
}