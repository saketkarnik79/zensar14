namespace CS_DemoStruct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(20, 30);
            Point p2 = new Point() { X = 20, Y = 34 };
            Point p3 = new Point();
            p3.X = 34;
            p3.Y = -12;
            p1.Display();
            p2.Display();
            p3.Display();

            Console.WriteLine("Program completed. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
