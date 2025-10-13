using System;
namespace CS_Demo2DimensionArrays
{
	class Program
	{
		static void Main()
		{
			// int[,] numbers = new int[3,3];
			// numbers[0, 0] = 10;
			// numbers[0, 1] = 20;
			// numbers[0, 2] = 30;
			// numbers[1, 0] = 40;
			// numbers[1, 1] = 50;
			// numbers[1, 2] = 60;
			// numbers[2, 0] = 70;
			// numbers[2, 1] = 80;
			// numbers[2, 2] = 90;
			
			// int[,] numbers = new int[3, 3] 
			// {
				// { 10, 20, 30 },
				// { 40, 50, 60 },
				// { 70, 80, 90 }
			// };
			
			int[,] numbers = {
				{ 10, 20, 30 },
				{ 40, 50, 60 },
				{ 70, 80, 90 }
			};
			Console.WriteLine("Multi-Dimesion Array:");
			for(int i = 0; i < numbers.GetLength(0); i++)
			{
				for(int j = 0; j < numbers.GetLength(1); j++)
				{
					//Console.Write("Element at index {0}, {1}: {2}, ", i, j, numbers[i, j]);
					Console.Write("{0}, ", numbers[i, j]);
				}
				Console.WriteLine();
			}
			
			Console.WriteLine("\n\nProgram completed. Press any ket to exit...");
			Console.ReadKey();
		}
	}
}