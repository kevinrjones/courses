using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {

            //SimpleTask();            

            //Waiting();

            //Cancellation();

            //ChildTasks();

            //Task<int> t = Task<int>.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("First task started");
            //    Thread.Sleep(1000);
            //    Console.WriteLine("First task ended");
            //    return 42;
            //});

            //t.ContinueWith(t1 =>
            //{
            //    Console.WriteLine( "continuation");
            //    Console.WriteLine(t1.Result);
            //});

            //Console.WriteLine("Thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            //AsyncAwait();

            Console.WriteLine("Press any key to start");
            Console.ReadLine();

            ThrowExceptions();

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static async void AsyncAwait()
        {
            Console.WriteLine("AsyncAwait:Thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("First call");
            var result = await DoWork();

            Console.WriteLine("AsyncAwait: Thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(result);

            Thread.Sleep(1000);
            Console.WriteLine("Second call");
            await DoWork();
            Console.WriteLine("AsyncAwait: Thread id: {0}", Thread.CurrentThread.ManagedThreadId);

        }

        private static Task<int> DoWork()
        {
            Console.WriteLine("DoWork: Thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            var t = Task<int>.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Hello");
                return 42;
            });
            return t;
        }

        private static void ChildTasks()
        {
            Task t = Task.Factory.StartNew(() =>
            {
                Task t2 = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("Child completed");
                }, TaskCreationOptions.AttachedToParent);
            });

            t.Wait();
            Console.WriteLine("Parent completed");
        }

        private static void Cancellation()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            Task t = new Task(() =>
            {
                while (true)
                {
                    Console.Write(".");
                    Thread.Sleep(1000);

                    token.ThrowIfCancellationRequested();
                }
            }, token);


            t.Start();
            Thread.Sleep(1000);
            tokenSource.Cancel();

            t.Wait();
        }

        class GCMe
        {
            int[] data = new int[10000];
        }

        private static void ThrowExceptions()
        {
            Task t = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Throw an exception");
                throw new Exception();
            });

            Exceptions();

            //try
            //{
            //    t.Wait();
            //}
            //catch (AggregateException ae)
            //{
            //    foreach (var e in ae.Flatten().InnerExceptions)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //}


        }
        private static void Exceptions()
        {
            int count = 0;
            while (true)
            {
                count++;
                new GCMe();
                if (count % 100000 == 0)
                {
                    Console.Write(".");
                }
            }
        }

        private static void Waiting()
        {
            Task<int> t = Task<int>.Factory.StartNew(() =>
            {
                Console.WriteLine("Hello World");
                Thread.Sleep(2000);
                return 42;
            });

            Console.WriteLine("Waiting");
            if (t.Wait(3000))
            {
                Console.WriteLine(t.Status);
                Console.WriteLine("Waited");
                Console.WriteLine(t.Result);
            }
            else
            {
                Console.WriteLine(t.Status);
                Console.WriteLine("Timed out");
            }
        }

        private static void SimpleTask()
        {
            string greeting = "Hello World";
            Task t = Task.Factory.StartNew(() => { Console.WriteLine(greeting); }, TaskCreationOptions.LongRunning);
        }
    }
}
