using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person { Name = "Rich", Age = 48 };
            var t = new Thread(p =>
            {
                while (true)
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
            });
            t.IsBackground = true;
            t.Start(person);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }

    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
