using System;

namespace CS_DemoIsAsOperators
{
	class Program
	{
		static void Main()
		{
			object obj = 10;
			Console.WriteLine("Value of obj is: {0}", obj);
			
			if(obj is string)
			{
				Console.WriteLine("obj is a string.");
			}
			
			string str = (string)obj;
			if(str != null)
			{
				Console.WriteLine("Casted String: {0}", str);
			}
			else
			{
				Console.WriteLine("Cast failed.");
			}
		}			
	}
}