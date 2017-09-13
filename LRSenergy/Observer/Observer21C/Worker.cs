using System.Threading;


namespace Observer21C
{

    public delegate void WorkStarted();
    public delegate void Working(int percentage);
    public delegate void WorkFinished();

    public class Worker
    {
        public event WorkStarted WorkStarted;
        public event Working Working;
        public event WorkFinished WorkFinished;

        public Worker()
        {
            WorkStarted += NullWorkStarted;
            WorkFinished += () => { };
            Working += n => { };
        }

        public void DoWork()
        {
            WorkStarted();

            for (int i = 0; i < 10; i++)
            {
                Working((i + 1) * 10);
                //Console.WriteLine("Working");
                Thread.Sleep(200);
            }
            
            WorkFinished();
        }

        public void NullWorkStarted()
        {
        }
    }
}