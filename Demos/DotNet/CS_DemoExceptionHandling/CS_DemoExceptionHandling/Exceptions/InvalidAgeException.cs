using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoExceptionHandling.Exceptions
{
    public class InvalidAgeException : ApplicationException
    {
        public InvalidAgeException(string message): base(message)
        {
            // Common logging code goes here
            Console.WriteLine($"Error: {message}");
        }
    }
}
