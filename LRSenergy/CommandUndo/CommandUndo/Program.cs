using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandUndo
{
    class Program
    {
        static void Main(string[] args)
        {
            DivideService ds = new DivideService();

            ds.EnqueueRequest(6, 1);
            ds.EnqueueRequest("33000", 11);
            ds.EnqueueRequest(9, 3);

            while (ds.NumberOfRequestsPending > 0)
            {
                try
                {
                    ds.ProcessNextRequest();
                    Console.WriteLine(ds.GetNextResponse());
                }
                catch
                {
                    Console.WriteLine("Ouch!");
                }
            }
        }
    }
}
