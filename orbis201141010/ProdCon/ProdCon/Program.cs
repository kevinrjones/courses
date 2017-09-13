using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProdCon
{
    class Program
    {
        private static bool bDone = false;
        static void Main(string[] args)
        {
            var queue = new ConcurrentQueue<int>();
            var collection = new BlockingCollection<int>(queue);

            Task t = new Task(Producer, collection);
            t.Start();
            Task.Factory.StartNew(Consumer, collection);

            Console.WriteLine("Press any key to stop producer");
            Console.ReadLine();
            bDone = true;
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static void Consumer(object obj)
        {
            var collection = (BlockingCollection<int>)obj;
           
            foreach (int result in collection.GetConsumingEnumerable())
            {
                Console.WriteLine(result);
            }
            Console.WriteLine("Consumer done");
        }

        private static void Producer(object obj)
        {
            var collection = (BlockingCollection<int>)obj;
            Random r  = new Random();
            while (!bDone)
            {
                collection.Add(r.Next(100));
                Thread.Sleep(500);
            }
            collection.CompleteAdding();
            Console.WriteLine("producer done");
        }
    }
}
