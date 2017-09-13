using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class SimpleCalc
    {
        public int Add(int first, int second)
        {
            return first + second;
        }

        public int Divide(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }
            return numerator/denominator;
        }

        public double Divide(double numerator, double denominator)
        {
            if (denominator == 0.0)
            {
                throw new DivideByZeroException();
            }
            return numerator / denominator;
        }

    }
}
