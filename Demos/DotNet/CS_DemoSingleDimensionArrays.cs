using System;
namespace CS_DemoSingleDimensionArrays
{
	class Program
	{
		static void Main()
		{
			// int[] numbers = new int[5];
			// numbers[0] = 10;
			// numbers[1] = 20;
			// int[] numbers = new int[5] 
			// {
				// 10,
				// 20,
				// 30,
				// 40,
				// 50
			// };
			int[] numbers = {10, 20, 30, 40, 50};
			Console.WriteLine("Single-Dimesion Array:");
			for(int i = 0; i < numbers.Length; i++)
			{
				Console.WriteLine("Element at index {0}: {1}", i, numbers[i]);
			}
			
			Console.WriteLine("\n\nProgram completed. Press any ket to exit...");
			Console.ReadKey();
		}
	}
}