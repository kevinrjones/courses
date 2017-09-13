using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParallelUtil;

namespace ParallelPi
{
    internal class Program
    {
        private const int PI_ITERATIONS = 200000000;

        private static void Main(string[] args)
        {
            Console.WriteLine(Math.PI);
            CalculatePi(SequentialPi);
            CalculatePi(SimpleParallelPi);
            CalculatePi(ParallelPi);
            CalculatePi(OptimizedParallelPi);
        }


        private static void CalculatePi(Func<double> calcMethod)
        {
            Stopwatch timer = Stopwatch.StartNew();
            double pi = calcMethod();
            timer.Stop();
            Console.WriteLine("{0} took {1} ms to calculate {2}",
                calcMethod.Method.Name,
                timer.ElapsedMilliseconds,
                pi);
        }


        // Pi = 4 * ( 1 - 1/3 + 1/5 - 1/7 + 1/9 - 1/11 ....  )
        private static double SequentialPi()
        {
            double pi = 1;
            double multiplier = -1;

            for (int i = 3; i < PI_ITERATIONS - 3; i += 2)
            {
                pi += multiplier * (1.0 / (double)i);
                multiplier = multiplier * -1;
            }

            pi = pi * 4.0;

            return pi;
        }

        private static double SimpleParallelPi()
        {
            double pi = 1;
            double multiplier = -1;

            Parallel.For(0, PI_ITERATIONS / 2, (i) =>
            {
                pi += multiplier * (1.0 / ((double)3 + i * 2.0));
                multiplier *= -1;    
            });

            pi = pi * 4.0;

            return pi;
        }

        private static double ParallelPi()
        {
            double pi = 1;
            object _lock = new object();
            Parallel.For(0, PI_ITERATIONS / 2, () => 0.0,(i, loopState, localPi) =>
            {
                double multiplier = i%2 == 0 ? -1 : 1;
                localPi += multiplier*(1.0/((double) 3 + i*2.0));
                return localPi;
            },
            localpi =>
            {
                lock (_lock)
                {
                    pi += localpi;
                }
            });

            pi = pi * 4.0;

            return pi;
        }

        private static double OptimizedParallelPi()
        {
            double pi = 1;
            object guard = new object();

            Range range = new Range() { Start = 3, End = PI_ITERATIONS };
            Parallel.ForEach(range.CreateSubRanges(Environment.ProcessorCount),
                () => 0.0,
                (loopRange, loopState, localpi) =>
                {
                    double multiplier = loopRange.Start % 2 == 0 ? 1 : -1;
                    for (int i = loopRange.Start; i < loopRange.End; i += 2)
                    {
                        localpi += multiplier * (1.0 / ((double)i));
                        multiplier *= -1;
                    }
                    return localpi;
                }, localpi =>
                {
                    lock (guard)
                    {
                        pi += localpi;
                    }
                });

            pi = pi * 4.0;

            return pi;
        }
    }
}
