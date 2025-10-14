using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoStruct
{
    internal struct Point
    {
        //public int X;
        //public int Y;
        private int x; 
        private int y;

        public int X
        {
            get { return x; }
            set 
            {
                if (value >= 0)
                {
                    x = value;
                }
                else
                {
                    throw new ArgumentException("The value for X can't be negative.");
                }
            }
        }

        public int Y
        {
            get { return y; }
            set 
            {
                if (value >= 0)
                {
                    y = value;
                }
                else
                {
                    throw new ArgumentException("The value for Y can't be negative.");
                }
            }
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Display()
        {
            Console.WriteLine($"Point is at: {X}, {Y}");
        }
    }
}
