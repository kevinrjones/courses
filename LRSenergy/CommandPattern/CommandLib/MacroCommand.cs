using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLib
{
    public class MacroCommand : Command
    {
        private readonly Command[] _commands;

        public MacroCommand(params Command[] commands)
        {
            _commands = commands;
        }

        public override void Execute()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }
    }
}
