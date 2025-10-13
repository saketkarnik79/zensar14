using System;
namespace CS_DemoRefOut
{
	class Program
	{
		static void Square(ref int a)
		{
			a *= a; 
		}
		
		static void AssignOut(out int number)
		{
			number = 89;
		}
		
		static void Main()
		{
			int n1 = 5;
			Console.Write("Square of {0} is: ", n1);
			Square(ref n1);
			Console.WriteLine(n1);
			
			int value=10;
			
			AssignOut(out value);
			Console.WriteLine("Value after out: {0}", value);
			
			Console.WriteLine("Program Completed. Press any key to exit...");
			Console.ReadKey();
		}
	}
}