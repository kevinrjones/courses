using System;
using System.Collections.Generic;
using System.Text;
using StockDataLibrary;
using System.Diagnostics;

namespace StockTicker
{
    class Program
    {
        static void Main(string[] args)
        {
            StockServiceBase service = new CacheStockService(new LiveStockService());
            Stopwatch timer = Stopwatch.StartNew();

            ProduceFundReports(service);

            Console.WriteLine("Time taken {0}", timer.Elapsed);
        }

        private static void ProduceFundReports(StockServiceBase service)
        {
            Investment[][] funds = new Investment[][]
            {
                new Investment[] { new Investment("CSCO" , 1000)  , new Investment("MSF",500) , new Investment("ABC",9000) },
                new Investment[] { new Investment("MSF" , 1200)  , new Investment("DEL",5000) , new Investment("NRT",9000) },
                new Investment[] { new Investment("DEL" , 10000)  , new Investment("CSCO",1500) , new Investment("ABC",1000) },
                new Investment[] { new Investment("CSCO" , 900)  , new Investment("DEL",1700) , new Investment("MSF",90000) },
            };

            foreach (Investment[] fund in funds)
            {
                double fundTotal = 0;

                foreach (Investment investment in fund)
                {
                    fundTotal += service.GetQuote(investment.Symbol) * investment.Quantity;
                }

                Console.WriteLine("Fund total {0}", fundTotal.ToString("C"));
            }

        }
    }
}
