using CS_DemoOOP.Demographics;
using CS_DemoOOP.Arithmetic;
using static CS_DemoOOP.Arithmetic.Calc;

namespace CS_DemoOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person p1 = new Person(101, "James", DateOnly.Parse("10-Sep-1999"));
            //Console.WriteLine(p1.GetData());

            //Calc calc = new Calc();

            //Console.WriteLine(calc.Add(20,10));
            //Console.WriteLine(calc.Add(20.23f,10.45f));
            //Console.WriteLine(calc.Add(200.234567d,10.4512345d));
            //Console.WriteLine(calc.Subtract(20,10));
            //Console.WriteLine(calc.Multiply(20,10));
            //Console.WriteLine(calc.Divide(20,3));
            //Console.WriteLine(calc.Modulus(20,3));

            //Console.WriteLine(Calc.Add(20, 10));
            //Console.WriteLine(Calc.Add(20.23f, 10.45f));
            //Console.WriteLine(Calc.Add(200.234567d, 10.4512345d));
            //Console.WriteLine(Calc.Subtract(20, 10));
            //Console.WriteLine(Calc.Multiply(20, 10));
            //Console.WriteLine(Calc.Divide(20, 3));
            //Console.WriteLine(Calc.Modulus(20, 3));

            //Console.WriteLine(Add(20, 10));
            //Console.WriteLine(Add(20.23f, 10.45f));
            //Console.WriteLine(Add(200.234567d, 10.4512345d));
            //Console.WriteLine(Subtract(20, 10));
            //Console.WriteLine(Multiply(20, 10));
            //Console.WriteLine(Divide(20, 3));
            //Console.WriteLine(Modulus(20, 3));

            Employee emp1 = new Employee(101, "James", DateOnly.Parse("10-Sep-1999"), 10, 1007, 100000);
            Console.WriteLine(emp1.GetData());

            Console.WriteLine("Program completed. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
