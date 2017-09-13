using System;
using System.Media;
using System.Windows.Forms;
using CommandLib;
using Timer = System.Threading.Timer;

namespace CommandPattern
{
    public class CommandReminderService
    {
        private readonly Command _command;

        public CommandReminderService(Command command)
        {
            _command = command;
        }

        public void AddReminder(DateTime alarmTime)
        {
            TimeSpan deltaTime = alarmTime - DateTime.Now;
            Timer reminderTimer = new Timer(delegate
            {
                _command.Execute();
            }, null, deltaTime, new TimeSpan(-1));
        }
    }

    public class ConsoleReminderCommand : Command
    {
        private readonly string _message;

        public ConsoleReminderCommand(string message)
        {
            _message = message;
        }

        public override void Execute()
        {
            Console.WriteLine(_message);
        }
    }

    public class MessageBoxReminderCommand : Command
    {
        private readonly string _message;

        public MessageBoxReminderCommand(string message)
        {
            _message = message;
        }

        public override void Execute()
        {
            MessageBox.Show(_message);
        }
    }

    public class SoundReminderCommand : Command
    {
        private readonly string _fileName;

        public SoundReminderCommand(string fileName)
        {
            _fileName = fileName;
        }

        public override void Execute()
        {
            SoundPlayer player = new SoundPlayer(_fileName);
            player.Play();
        }
    }

    
}