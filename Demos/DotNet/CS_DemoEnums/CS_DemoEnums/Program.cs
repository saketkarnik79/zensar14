namespace CS_DemoEnums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DayOfWeek today = DayOfWeek.Tuesday;
            Console.WriteLine($"Today is: {today}");
            Console.WriteLine($"Numeric value of today is: {(int)today}");

            Console.WriteLine("Program completed. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
