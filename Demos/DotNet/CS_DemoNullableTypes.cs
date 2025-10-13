using System;
	
namespace CS_DemoNullableTypes
{
	class Program
	{
		static void Main()
		{
			int? age = null;
			if(age.HasValue)
			{
				Console.WriteLine("Age is: {0}", age.Value);
			}
			else
			{
				Console.WriteLine("Age is not available.");
			}
			//Assign a value later
			age = 30;
			Console.WriteLine("Updated Age: {0}", age.Value);
		}
	}
}