using ClassLibrary1;

namespace ConsoleApp1
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            uint x = 20;
            uint y = 10;
            MyClass obj=new MyClass();
            Console.WriteLine(obj.Add(x, y));
            Console.ReadKey();
        }
    }
}
