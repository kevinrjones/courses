using System;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace CommandPattern
{
    public class ReminderService
    {
        private readonly IReminderStrategy _reminderStrategy;

        public ReminderService(IReminderStrategy reminderStrategy)
        {
            _reminderStrategy = reminderStrategy;
        }

        public void AddReminder(DateTime alarmTime)
        {
            TimeSpan deltaTime = alarmTime - DateTime.Now;
            Timer reminderTimer = new Timer(delegate
            {
                _reminderStrategy.Alert(string.Format("Your {0} Alarm Call", alarmTime));
            }, null, deltaTime, new TimeSpan(-1));
        }
    }

    public interface IReminderStrategy
    {
        void Alert(string message);
    }

    public class ConsoleReminder : IReminderStrategy
    {
        public void Alert(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class MessageBoxReminder : IReminderStrategy
    {
        public void Alert(string message)
        {
            MessageBox.Show(message);
        }
    }
}