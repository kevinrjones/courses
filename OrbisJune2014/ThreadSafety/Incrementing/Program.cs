using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafety
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to start");
            Console.ReadLine();

            Counter[] counters = new Counter[]
            {
                new Counter(),
                new InterlockedCounter(),
                new MutexCounter(), 
            };

            int nThreads = 2;
            //int nIterations = 50000000;
            int nIterations = 500000;

            foreach (Counter counter in counters)
            {
                var elapsed = ExerciseCounter(counter, nThreads, nIterations);

                Console.WriteLine("{2} Value = {0} Expected {1} in {3} ms",
                    counter.Value,
                    nThreads * nIterations,
                    counter.GetType().Name, 
                    elapsed);
            }
        }

        private static long ExerciseCounter(Counter counter, int nThreads, int nIncrements)
        {
            Task[] threads = new Task[nThreads];
            Stopwatch sw = Stopwatch.StartNew();
            for (int nThread = 0; nThread < threads.Length; nThread++)
            {
                threads[nThread] = Task.Factory.StartNew(() =>
                {
                    for (int nIteration = 0; nIteration < nIncrements; nIteration++)
                    {
                        counter.Increment();
                    }
                });
            }

            Task.WaitAll(threads);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

    }

    class Counter
    {
        protected int count;

        public virtual void Increment()
        {
            count++;
        }

        public int Value
        {
            get { return count; }
        }
    }

    class InterlockedCounter : Counter
    {
        public override void Increment()
        {
            Interlocked.Increment(ref count);
        }
    }

    class MutexCounter : Counter
    {
        Mutex mutex = new Mutex();
        public override void Increment()
        {
            mutex.WaitOne();
            base.Increment();
            mutex.ReleaseMutex();
        }
    }
}
