using System;
using System.Threading;

namespace Deadlock
{
    class Program
    {
        static object _lock1 = new object();
        static object _lock2 = new object();

        static void Main(string[] args)
        {
            Thread t1 = new Thread(ThreadProc1);
            Thread t2 = new Thread(ThreadProc2);

            t1.Start();
            t2.Start();

            Console.WriteLine("Running...");
            Console.ReadLine();
        }

        static void ThreadProc1()
        {
            object l1 = _lock1;
            object l2 = _lock2;

            Thread.Sleep(100);
            Console.WriteLine("In thread 1");
            lock (l1)
            {
                Console.WriteLine("have lock 1");
                Thread.Sleep(100);
                lock (l2)
                {
                    Console.WriteLine("have lock 2");
                    Thread.Sleep(100);
                }
            }
        }


        static void ThreadProc2()
        {
            object l2 = _lock1;
            object l1 = _lock2;

            Thread.Sleep(100);
            Console.WriteLine("In thread 2");
            lock (l1)
            {
                Console.WriteLine("have lock 1");
                Thread.Sleep(100);
                lock (l2)
                {
                    Console.WriteLine("have lock 2");
                    Thread.Sleep(100);
                }
            }
        }
    }
}
