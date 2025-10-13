using System;

namespace CS_DemoSwitchCase
{
	class Program
	{
		static void Main()
		{
			int n1;
			int n2;
			float result = 0.0f;
			string op;
			
			Console.Write("Enter the first number: ");
			n1 = int.Parse(Console.ReadLine());
			Console.Write("Enter the second number: ");
			n2 = int.Parse(Console.ReadLine());
			Console.Write("Enter the operator (+, -, *, /, %, +/-): ");
			op = Console.ReadLine();
			
			switch(op)
			{
				case "+":
					result = n1 + n2;
					break;
				case "-":
					result = n1 - n2;
					break;
				case "*":
					result = n1 * n2;
					break;
				case "/":
					result = (float)n1 / n2;
					break;
				case "%":
					result = n1 % n2;
					break;
				case "+/-":
					result = -n1;
					break;
				default:
					Console.WriteLine("Invalid Operator!");
					return;
			}
			Console.WriteLine("Result: {0}", result);
			Console.WriteLine("Program Completed. Press any key to exit...");
			Console.ReadKey();
		}
	}
}