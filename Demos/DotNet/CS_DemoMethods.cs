using System;

namespace CS_DemoMethods
{
	static class CalcUtil
	{
		public static int Add(int a, int b)
		{
			return a + b;
		}
		
		public static int Subtract(int a, int b)
		{
			return a - b;
		}
		
		public static int Multiply(int a, int b)
		{
			return a * b;
		}
		
		public static float Divide(float a, float b)
		{
			return a / b;
		}
		
		public static int Mod(int a, int b)
		{
			return a % b;
		}
		
		public static int Negate(int a)
		{
			return -a;
		}
	}
	
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
					result = CalcUtil.Add(n1, n2);
					break;
				case "-":
					result = CalcUtil.Subtract(n1, n2);
					break;
				case "*":
					result = CalcUtil.Multiply(n1, n2);
					break;
				case "/":
					result = CalcUtil.Divide(n1, n2);
					break;
				case "%":
					result = CalcUtil.Mod(n1, n2);
					break;
				case "+/-":
					result = CalcUtil.Negate(n1);
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