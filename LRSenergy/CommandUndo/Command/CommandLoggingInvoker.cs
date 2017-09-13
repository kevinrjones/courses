using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DM
{
    public class CommandLoggingInvoker
    {
        string fileName;

        public CommandLoggingInvoker(string fileName)
        {
            this.fileName = fileName;
        }

        public void Execute(Command cmd)
        {
            SaveCommand(cmd);
            cmd.Execute();
        }

        private void SaveCommand(Command cmd)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = File.Open(fileName, FileMode.Append))
            {
                formatter.Serialize(fs, cmd);
            }
        }

        public void Purge()
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        public void Replay()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = File.Open(fileName, FileMode.Open))
            {
                while (fs.Position < fs.Length)
                {
                    Command cmd = (Command)formatter.Deserialize(fs);
                    cmd.Execute();
                }
            }
        }
    }
}
