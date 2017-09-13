using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calc
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Divide(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("denominator");
            }
            return numerator/denominator;
        }
    }
}
