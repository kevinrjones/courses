using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Calc;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof (Calculator));

//            host.AddServiceEndpoint(typeof(ICalculator), new BasicHttpBinding(), new Uri("http://localhost:9000"));
//            host.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), new Uri("http://localhost:9001"));
//            host.AddServiceEndpoint(typeof(ICalculator), new NetTcpBinding(), new Uri("net.tcp://localhost:9002"));
            host.Description.Endpoints.ToList().ForEach(e => Console.WriteLine("{0}:{1}", e.Binding.GetType().Name, e.Address));

            host.Open();

            Console.WriteLine("Service started...");

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();

        }
    }

    class Calculator : ICalculator
    {
        private int total;
        public void Accumulate(int x)
        {
            total += x;
            Console.WriteLine(total);
        }
    }
}
