using System;

namespace Observer21C
{

    public class Manager 
    {
        public void WorkStarted()
        {
            Console.WriteLine("About time too");
        }

        public void Working(int percentage)
        {
            Console.WriteLine("Work harder");
        }

        public void WorkFinished()
        {
            Console.WriteLine("Get on to the next task");
        }
    }
}