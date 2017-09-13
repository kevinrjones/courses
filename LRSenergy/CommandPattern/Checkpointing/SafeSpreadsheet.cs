using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CommandLib;

namespace Checkpointing
{

    public class SafeSpreadSheet
    {

        private int nCols = 100;
        private int nRows = 100;
        private int[,] cells = null;


        private SpreadSheet sheet;
        private LoggingCommandInvoker invoker;

        public SafeSpreadSheet(string name)
        {
            sheet = new SpreadSheet(name);
            invoker = new LoggingCommandInvoker(string.Format("{0}.log", sheet.Name));
        }

        public SafeSpreadSheet(SpreadSheet sheet)
        {
            this.sheet = sheet;
            invoker = new LoggingCommandInvoker(string.Format("{0}.log", sheet.Name));
            if (File.Exists(string.Format("{0}.log", sheet.Name)))
            {
                invoker.Replay();
            }
        }
       

        public int NumberOfColumns { get { return nCols; } }
        public int NumberOfRows { get { return nRows; } }


        public int GetValue(int nCol, int nRow)
        {
            return sheet.GetValue(nCol, nRow);
        }

        public void SetValue(int nCol, int nRow, int value)
        {
            SetValueCommand command = new SetValueCommand(nCol, nRow, value, sheet);
            invoker.Execute(command);
        }


        public void Save(string filename)
        {
            sheet.Save(filename);
            invoker.Purge();
        }

        public static SafeSpreadSheet Load(string filename)
        {
            SpreadSheet sheet;

            if (File.Exists(filename))
            {
                sheet = SpreadSheet.Load(filename);
            }
            else
            {
                sheet = new SpreadSheet(filename);
            }
            return new SafeSpreadSheet(sheet);

        }
    }

    [Serializable]
    public class SetValueCommand : Command
    {
        private readonly int _nCol;
        private readonly int _nRow;
        private readonly int _value;
        private readonly string _sheetName;

        public SetValueCommand(int nCol, int nRow, int value, SpreadSheet sheet)
        {
            _nCol = nCol;
            _nRow = nRow;
            _value = value;
            _sheetName = sheet.Name;
        }

        public override void Execute()
        {
            SpreadSheetRegistry.GetInstance().GetSheetByName(_sheetName).SetValue(_nCol, _nRow, _value);
        }
    }
}
