using System;
namespace CS_Demo2DimensionArrays
{
	class Program
	{
		static void Main()
		{
			int[][] jaggedArray = new int[3][];
			jaggedArray[0] = new int[] {1, 2}; 
			jaggedArray[1] = new int[] {3, 4, 5}; 
			jaggedArray[2] = new int[] {6}; 
			
			Console.WriteLine("Jagged Array:");
			for(int i = 0; i < jaggedArray.Length; i++)
			{
				Console.Write("Row {0}: ", i);
				for(int j = 0; j< jaggedArray[i].Length; j++)
				{
					Console.Write("{0} ", jaggedArray[i][j]);
				}
				Console.WriteLine();
			}
			
			Console.WriteLine("\n\nProgram completed. Press any ket to exit...");
			Console.ReadKey();
		}
	}
}