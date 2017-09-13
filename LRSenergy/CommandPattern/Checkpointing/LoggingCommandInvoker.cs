using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CommandLib;

namespace Checkpointing
{
    public class LoggingCommandInvoker
    {
        private readonly string _logFileName;

        public LoggingCommandInvoker(string logFileName)
        {
            _logFileName = logFileName;
        }

        public void Execute(Command command)
        {
            command.Execute();
            SaveCommand(command);
        }

        private void SaveCommand(Command command)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(_logFileName, FileMode.OpenOrCreate))
            {
                stream.Seek(0, SeekOrigin.End);
                formatter.Serialize(stream, command);
            }
        }

        public void Replay()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(_logFileName, FileMode.Open))
            {
                while (stream.Position < stream.Length)
                {
                    Command cmd = (Command) formatter.Deserialize(stream);
                    cmd.Execute();
                }
            }
        }

        public void Purge()
        {
            if (File.Exists(_logFileName))
            {
                File.Delete(_logFileName);
            }
        }
    }
}
