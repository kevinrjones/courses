using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Checkpointing
{
    [Serializable]
    public class SpreadSheet
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int nCols = 100;
        private int nRows = 100;
        private int[,] cells = null;


        private static SpreadSheet current;

        public SpreadSheet(string name)
        {
            cells = new int[nCols, nRows];

            this.name = name;

            SpreadSheetRegistry.GetInstance().RegisterSheet(name, this);
        }

       

        public int NumberOfColumns { get { return nCols; } }
        public int NumberOfRows { get { return nRows; } }


        public int GetValue(int nCol, int nRow)
        {
            return cells[nCol, nRow];
        }

        public void SetValue(int nCol, int nRow, int value)
        {
            cells[nCol, nRow] = value;
        }


        public void Save(string filename)
        {
            using (FileStream stream = File.OpenWrite(filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, this);
            }
        }

        public static SpreadSheet Load(string filename)
        {
            SpreadSheet sheet;

            using (FileStream stream = File.OpenRead(filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                sheet = (SpreadSheet)formatter.Deserialize(stream);

                SpreadSheetRegistry.GetInstance().RegisterSheet(sheet.name, sheet);
            }

            return sheet;
        }
    }
}
