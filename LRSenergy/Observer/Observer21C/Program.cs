using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer21C
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager phb = new Manager();
            Worker dilbert = new Worker();
            Partner p =new Partner();
            //dilbert.WorkStarted += phb.WorkStarted;
            //dilbert.Working += phb.Working;
            //dilbert.WorkFinished += phb.WorkFinished;
            //dilbert.WorkFinished += p.WorkFinished;

            dilbert.DoWork();

            //dilbert.WorkStarted();
        }
    }
}
