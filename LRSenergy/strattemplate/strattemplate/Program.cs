using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strattemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileReport report = new FileReport("c:/windows");
            //report.ProduceReport();

            FileTemplate report = new FileTemplate("c:/windows", new HtmlOutputStrategy("c:/temp/senergy.html"));
            report.ProduceReport();
            Console.WriteLine();

            DirectoryTemplate dirreport = new DirectoryTemplate("c:/windows", new ConsoleOutputStrategy());
            dirreport.ProduceReport();
        }
    }
}
