using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Arithmetic
{
    internal static class Calc
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static float Add(float x, float y)
        {
            return x + y;
        }

        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static int Subtract(int x, int y) 
        {
            return x - y; 
        }

        public static long Multiply(int x, int y)
        {
            return x * y;
        }

        public static float Divide(int x, int y)
        {
            return(float) x / y;
        }

        public static int Modulus(int x, int y)
        {
            return x % y;
        }
    }
}
