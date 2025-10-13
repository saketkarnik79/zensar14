using System;
namespace CS_Demo2DimensionArrays
{
	class Program
	{
		static void Main()
		{
			int[] numbers = { 5, 3, 8, 1, 9 };
			Array.Sort(numbers);
			Console.WriteLine("Sorted: {0}", string.Join(", ", numbers));
			
			Array.Reverse(numbers);
			Console.WriteLine("Reversed: {0}", string.Join(", ", numbers));
			
			int index = Array.IndexOf(numbers, 8);
			Console.WriteLine("Index of 8: {0}", index);
			
			Array.Clear(numbers, 1, 2);
			Console.WriteLine("After Clear: {0}", string.Join(", ", numbers));
			
			Console.WriteLine("\n\nProgram completed. Press any key to exit...");
			Console.ReadKey();
		}
	}
}