using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {

            //Task t1 = Task.Factory.StartNew(() => Console.WriteLine("This is another task"), TaskCreationOptions.LongRunning);
            //Task.Factory.StartNew(s => Console.WriteLine("Hello " + s), "World");

            //string message = "Kevin";
            //Task.Factory.StartNew(() => Console.WriteLine("Hello " + message));

            //Task<int> t = Task<int>.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Return something");
            //    return 23;
            //});

            //Console.WriteLine(t.Result);

            //var t = Task.Factory.StartNew(() => Console.WriteLine("Wait for me"));
            //var t1 = Task.Factory.StartNew(() => Console.WriteLine("Wait for me"));

            //Console.WriteLine("About to wait");
            //Console.WriteLine(t.Status);
            //t.Wait();
            //Console.WriteLine(t.Status);

            //Task.WaitAll(t, t1);


            //Task t = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Started");
            //    Thread.Sleep(3000);
            //    Console.WriteLine("Ended");
            //});

            //if (!t.Wait(2000))
            //{
            //    Console.WriteLine("timed out");
            //    Console.WriteLine(t.Status);
            //}

            //Task t = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("About to throw exception");
            //    throw new Exception();
            //});

            //try
            //{
            //    t.Wait();
            //}
            //catch (AggregateException ae)
            //{
            //    Console.WriteLine(ae.Flatten());                
            //}



            //Console.WriteLine("Press any key to collect");
            //Console.ReadLine();

            //GC.Collect();


            //CancellationTokenSource source = new CancellationTokenSource();

            //Task t = Task.Factory.StartNew(() =>
            //{
            //    var token = source.Token;
            //    while (true)
            //    {
            //        Console.Write(".");
            //        Thread.Sleep(1000);
            //        token.ThrowIfCancellationRequested();
            //    }
            //}, source.Token);


            //Task t2 = new Task(() =>
            //{
            //    Console.WriteLine("Starting new task");
            //}, source.Token);

            //t2.Start();

            //source.Cancel();

            //Console.WriteLine("Press to cancel");
            //Console.ReadLine();

            //source.Cancel();
//            Console.WriteLine(t.Status);

            //Task t1 = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Started");
            //    Task.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Running child");
            //        Thread.Sleep(2000);
            //        Console.WriteLine("Child done");
            //    }, TaskCreationOptions.AttachedToParent);
            //});


            //Console.WriteLine("Waiting for parent");
            //t1.Wait();
            //Console.WriteLine("Waited for parent");

            Task<int> t1 = Task<int>.Factory.StartNew(() =>
            {
                Console.WriteLine("t1 started");
                throw new Exception();
                return 42;
            });

            //t1.ContinueWith(tPrev =>
            //{
            //    Console.WriteLine(tPrev.Status);
                
            //}, TaskContinuationOptions.OnlyOnRanToCompletion);


            t1.ContinueWith(tPrev =>
            {
                Console.WriteLine(tPrev.Status);
                var e = t1.Exception;                

            }, TaskContinuationOptions.OnlyOnFaulted);

            Console.WriteLine("Collect");
            Console.ReadLine();

            GC.Collect();
            GC.Collect();

            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
    }
}






















