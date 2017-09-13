using System;

namespace Observer
{
    public class Partner : IWorkerObserver
    {
        public void WorkStarted()
        {
        }

        public void Working()
        {
        }

        public void WorkFinished()
        {
            Console.WriteLine("Come home soon");
        }

    }
}