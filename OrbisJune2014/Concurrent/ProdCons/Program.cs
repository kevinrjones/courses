using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProdCons
{
    class Program
    {
        private static bool done = false;
        static void Main(string[] args)
        {
            ConcurrentQueue<int> ints = new ConcurrentQueue<int>();
            BlockingCollection<int> bc = new BlockingCollection<int>(ints); 

            Task consumer = new Task(Consumer, bc);
            Task producer = new Task(Producer, bc);
            Task sproducer = new Task(SpinningProducer, ints);

            producer.Start();
            sproducer.Start();
            consumer.Start();

            Console.WriteLine("Hit enter to finish");
            Console.ReadLine();
            done = true;
            Task.WaitAll(sproducer, consumer);
            //SpinningProducerConsumer();
        }

        private static void Consumer(object o)
        {
            BlockingCollection<int> bc = (BlockingCollection<int>)o;

            while (!done)
            {
                foreach (var item in bc.GetConsumingEnumerable())
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void Producer(object o)
        {
            BlockingCollection<int> bc = (BlockingCollection<int>) o;
            Random rnd = new Random();
            while (!done)
            {
                bc.Add(rnd.Next(100) * -1);
                Thread.Sleep(100);
            }
            bc.CompleteAdding();
        }

        static void SpinningProducerConsumer()
        {
            ConcurrentQueue<int> ints  = new ConcurrentQueue<int>();

            Task consumer = new Task(SpinningConsumer, ints);
            Task producer = new Task(SpinningProducer, ints);

            producer.Start();
            consumer.Start();

            Console.WriteLine("Hit enter to finish");
            Console.ReadLine();
            done = true;
            Task.WaitAll(producer, consumer);
        }

        private static void SpinningProducer(object o)
        {
            ConcurrentQueue<int> queue = (ConcurrentQueue<int>) o;
            Random rnd = new Random();
            while (!done)
            {
                queue.Enqueue(rnd.Next(100));
                Thread.Sleep(100);
            }
        }

        private static void SpinningConsumer(object o)
        {
            ConcurrentQueue<int> queue = (ConcurrentQueue<int>)o;

            while (!done)
            {
                int result;
                if (queue.TryDequeue(out result))
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}
