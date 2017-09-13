using System;
using System.Collections.Generic;
using System.Threading;

namespace Observer
{
    public class Worker
    {
        private readonly List<IWorkerObserver> _observers = new List<IWorkerObserver>();

        public void Register(IWorkerObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unregister(IWorkerObserver observer)
        {
            _observers.Remove(observer);
        }

        public void DoWork()
        {
            foreach (var observer in _observers)
            {
                observer.WorkStarted();
            }

            for (int i = 0; i < 10; i++)
            {
                foreach (var observer in _observers)
                {
                    observer.Working();
                    //Console.WriteLine("Working");
                    Thread.Sleep(200);
                }
            }
            foreach (var observer in _observers)
            {
                observer.WorkFinished();
            }
        }
    }
}