using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CalcClient.CalcService;
using Calculator;

namespace CalcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcService.ICalculator proxy = new CalculatorClient("WSHttpBinding_ICalculator");
            for (int i = 0; i < 10; i++)
            {
                proxy.Accumulate(i);
            }

            // WSHttpBinding binding = new WSHttpBinding();
            
            //            EndpointAddress address = new EndpointAddress("http://localhost:9000");
            //
            //            ChannelFactory<ICalculator> factory = new ChannelFactory<ICalculator>(binding, address);
            //
            //            var proxy = factory.CreateChannel();
            //
            //            for (int i = 0; i < 10; i++)
            //            {
            //                proxy.Accumulate(i);
            //            }
        }
    }
}
