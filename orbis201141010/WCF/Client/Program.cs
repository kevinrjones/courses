using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Calc;
using Client.CalcReference;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //BasicHttpBinding binding = new BasicHttpBinding();
            //EndpointAddress ea = new EndpointAddress(new Uri("http://localhost:9000"));
            //var binding = new WSHttpBinding();
            //var ea = new EndpointAddress(new Uri("http://localhost:9001"));
            //var binding = new NetTcpBinding();
            //var ea = new EndpointAddress(new Uri("net.tcp://localhost:9002"));

            //var factory = new ChannelFactory<ICalculator>(binding, ea);

            //ICalculator calc = factory.CreateChannel();

            var calc = new CalculatorClient("basic");

            for (int i = 0; i < 10; i++)
            {
                calc.Accumulate(10);
            }
        }
    }
}
