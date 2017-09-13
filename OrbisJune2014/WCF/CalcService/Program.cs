using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Calculator;

namespace CalcService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Calculator));

//            host.AddServiceEndpoint(typeof (ICalculator),
//                new WSHttpBinding(),
//                "http://localhost:9000");

            host.Description.Endpoints.ToList().ForEach(ep => Console.WriteLine("{0}", ep.Address));

            host.Open();

            Console.WriteLine("Running...");
            Console.ReadLine();
        }
    }

    public class Calculator : ICalculator
    {
        private int total;
        public void Accumulate(int value)
        {
            total += value;
            Console.WriteLine(total);
        }
    }
}
