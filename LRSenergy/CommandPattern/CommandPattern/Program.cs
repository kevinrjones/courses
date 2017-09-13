using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLib;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReminderService reminderService = new ReminderService(new MessageBoxReminder());
            CommandReminderService reminderService = new CommandReminderService(
                new MacroCommand(new SoundReminderCommand("c:/windows/media/tada.wav"), 
                    new ConsoleReminderCommand("ALERT!!")));

            while (true)
            {
                Console.Write("Enter time to remind {0}: ", DateTime.Now.ToLongTimeString());
                DateTime alarmTime = DateTime.Parse(Console.ReadLine());
                reminderService.AddReminder(alarmTime);
            }

        }
    }
}
