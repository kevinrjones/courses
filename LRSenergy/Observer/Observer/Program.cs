using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorkerObserver phb = new Manager();
            IWorkerObserver partner = new Partner();

            Worker dilbert = new Worker();

            dilbert.Register(phb);
            dilbert.Register(partner);

            dilbert.DoWork();

            Console.WriteLine();

            dilbert.Unregister(phb);
            dilbert.DoWork();
        }
    }
}
