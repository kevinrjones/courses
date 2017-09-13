using System;
using System.Collections.Generic;
using System.Text;
using StockDataLibrary;

namespace FundReport
{
    class Program
    {
        static void Main(string[] args)
        {
            LiveService service = new LiveService();

            Console.WriteLine("value is", service.GetQuote("MSFT"));
        }
    }
}
