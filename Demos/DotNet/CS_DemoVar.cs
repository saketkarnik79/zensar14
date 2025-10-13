using System;
namespace CS_DemoVar
{
	class Program
	{
		static void Main()
		{
			var number = 10;       //inferred as int
			var name = "James";    //inferred as string
			var price = 99.99;     //inferred as double
			var isAvailable = true;//inferred as bool
			
			Console.WriteLine("{0}: {1}", number.GetType(), number);
			Console.WriteLine("{0}: {1}", name.GetType(), name);
			Console.WriteLine("{0}: {1}", price.GetType(), price);
			Console.WriteLine("{0}: {1}", isAvailable.GetType(), isAvailable);
			
			dynamic name2 = "James";
			Console.WriteLine(name2.ToUpper());
			
			name2 = 10;
			Console.WriteLine(name2.ToUpper());
			
		}
	}
}