using System;
using static System.Console;
using CS_DemoExceptionHandling.Exceptions;

namespace CS_DemoExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    Write("Enter a number to divide 100: ");
            //    int number = int.Parse(ReadLine());
            //    int result = 100 / number;
            //    WriteLine($"Result: {result}");
            //}
            //catch (DivideByZeroException ex)
            //{
            //    WriteLine("Error: You can't divide by zero.");
            //}
            //catch (FormatException ex)
            //{
            //    WriteLine("Error: Please enter a valid number.");
            //}
            //catch (OverflowException ex)
            //{
            //    WriteLine(ex.Message);
            //}
            //catch (Exception ex) 
            //{
            //    WriteLine($"Unexpected error: {ex.Message}");
            //}
            //finally
            //{
            //    WriteLine("Execution completed.");
            //}

            try
            {
                Write("Enter your age: ");
                int age = int.Parse(ReadLine());
                ValidateAge(age);
                WriteLine("Age is valid. Access Granted.");
            }
            catch (InvalidAgeException ex)
            {
                //Local logging code goes here, if required.
            }
            catch (FormatException ex)
            {
                WriteLine("Error: Please enter a valid number for age.");
            }
            catch (Exception ex)
            {
                WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                WriteLine("Execution completed.");
            }
            int n1 = 20;
            int n2 = 20;
            int result = Add(n1, n2);

            WriteLine("Program completed. Press any key to exit...");
            ReadKey();
        }

        private static int Add(int n1, int n2)
        {
            //HACK: Add the logic for logging parameters

            return n1 + n2;
        }

        static void ValidateAge(int age)
        {
            if(age<18)
            {
                throw new InvalidAgeException("Age must be 18 or older.");
            }
        }
        
    }
}
