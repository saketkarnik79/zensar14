namespace CS_DemoDelegates
{
    internal class Program
    {
        //static int Add(int x, int y) 
        //{
        //    return x + y;
        //}
        //static int Multiply(int x, int y) 
        //{
        //    return x * y;
        //}
        //static float Divide(int x, int y) 
        //{
        //    return (float)x / y;
        //}

        static void Main(string[] args)
        {
            DataProcessor processor = new DataProcessor();

            //int sum = processor.ProcessData(10, 5, new MathOperation(Add));
            //int product = processor.ProcessData(10, 5, new MathOperation(Multiply));
            //float quotient = processor.ProcessData(10, 5, new MathOperation(Divide));//Doesn't work because delegate signature doesn't match with Divide method

            //int sum = processor.ProcessData(10, 5, Add); //Simplified delegate instantiation using Type Inference
            //int product = processor.ProcessData(10, 5, Multiply);

            //int sum =processor.ProcessData(10, 5 , delegate(int x, int y) //Anonymous Method
            //{
            //    return x + y;
            //});
            //int product=processor.ProcessData(10, 5, delegate(int x, int y) //Anonymous Method
            //{
            //    return x * y;
            //});

            int sum = processor.ProcessData(10, 5, (x, y) => x + y); //Lambda Expressions
            int product = processor.ProcessData(10, 5, (x, y) => 
            { 
                return x * y; 
            });


            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Product: {product}");

            Console.WriteLine("Program has ended. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
