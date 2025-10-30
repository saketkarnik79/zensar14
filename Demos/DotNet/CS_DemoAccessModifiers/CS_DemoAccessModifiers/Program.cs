using DemoLib;

namespace CS_DemoAccessModifiers
{
    class MyClass : DemoClass
    {
        public void AccessProtectedMembers()
        {
            Console.WriteLine(this.publicField); // Accessible
            // Console.WriteLine(this.privateField); // Not Accessible
             Console.WriteLine(this.protectedField); // Accessible
            Console.WriteLine(this.protectedInternalField); // Accessible
            // Console.WriteLine(this.privateProtectedField); // Not Accessible
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DemoClass demo = new DemoClass();
            demo.ShowFields();

            // Accessing fields from outside the class
            Console.WriteLine(demo.publicField); // Accessible
            // Console.WriteLine(demo.privateField); // Not Accessible
            // Console.WriteLine(demo.protectedField); // Not Accessible
            // Console.WriteLine(demo.internalField); // Not Accessible
            // Console.WriteLine(demo.protectedInternalField); // Accessible from Derived class
            // Console.WriteLine(demo.privateProtectedField); // Not Accessible

            Console.WriteLine("Program completed.");
            Console.ReadKey();
        }
    }
}
