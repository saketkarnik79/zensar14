using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoDelegates
{
    internal delegate int MathOperation(int a, int b);

    internal class DataProcessor
    {
        public int ProcessData(int a, int b, MathOperation operation)
        {
            return operation?.Invoke(a, b) ?? 0;
        }
    }
}
