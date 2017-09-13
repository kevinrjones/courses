using System;

namespace Observer
{
    public interface IWorkerObserver
    {
        void WorkStarted();
        void Working();
        void WorkFinished();
    }

    public class Manager : IWorkerObserver
    {
        public void WorkStarted()
        {
            Console.WriteLine("About time too");
        }

        public void Working()
        {
            Console.WriteLine("Work harder");
        }

        public void WorkFinished()
        {
            Console.WriteLine("Get on to the next task");
        }
    }
}