using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DM
{
    [Serializable]
    public abstract class Command
    {
        public abstract void Execute();
        public virtual void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
