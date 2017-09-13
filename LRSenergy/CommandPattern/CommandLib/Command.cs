using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib
{
    [Serializable]
    public abstract class Command
    {
        public abstract void Execute();
    }
}
