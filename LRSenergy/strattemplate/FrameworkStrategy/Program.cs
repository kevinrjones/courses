using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkStrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = ints.FindAll(i => i < 9);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static bool Filter(int n)
        {
            return n < 7;
        }
    }
}
