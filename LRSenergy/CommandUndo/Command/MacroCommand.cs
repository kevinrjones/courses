using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DM
{
    public class MacroCommand : Command
    {
        Command[] commands;

        public MacroCommand(Command[] commands)
        {
            this.commands = commands;
        }

        public override void Execute()
        {
            for (int i = 0; i < commands.Length; i++)
            {
                commands[i].Execute();
            }
        }
    }
}
