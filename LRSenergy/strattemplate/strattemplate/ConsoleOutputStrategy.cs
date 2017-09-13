using System;
using System.Collections.Generic;

namespace strattemplate
{
    public class ConsoleOutputStrategy : IOutputStrategy
    {
        public void OutputTitle(string title)
        {
            Console.WriteLine(title);
        }

        public void OutputHeader(IEnumerable<string> header)
        {
            bool first = true;
            foreach (string column in header)
            {
                if (first)
                {
                    Console.Write(column);
                    first = false;
                }
                else
                {
                    Console.Write(", " + column);
                }
            }
            Console.WriteLine();
        }

        public void OutputRows(IEnumerable<object[]> rows)
        {
            foreach (object[] row in rows)
            {
                bool first = true;
                foreach (var item in row)
                {
                    if (first)
                    {
                        Console.Write(item);
                        first = false;
                    }
                    else
                    {
                        Console.Write(", " + item);
                    }
                }
                Console.WriteLine();
            }
        }

        public void OutputFooter(string footer)
        {
            Console.WriteLine(footer);
        }
    }
}