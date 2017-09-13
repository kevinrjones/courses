using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DM
{
    public class CommandUndoInvoker
    {
        Stack<Command> commands = new Stack<Command>();
        public void Execute(Command cmd)
        {
            cmd.Execute();
            commands.Push(cmd);
        }

        public void Undo()
        {
            while (commands.Count > 0)
            {
                Command cmd = commands.Pop();
                cmd.Undo();
            }
        }
    }
}
