using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Checkpointing
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SafeSpreadSheet sheet = new SafeSpreadSheet("Calc");
            sheet.Save("spreadsheet.bin");

            for (int nCol = 0; nCol < sheet.NumberOfColumns; nCol++)
            {
                for (int nRow = 0; nRow < sheet.NumberOfRows; nRow++)
                {
                    sheet.SetValue(nCol, nRow, 1);
                    //sheet.Save("spreadsheet.bin");
                }
                Console.Write(" {0} ", (double)nCol / (double)sheet.NumberOfColumns * 100.0);
            }

            //sheet.Save("spreadsheet.bin");

            sheet = null;
            sheet = SafeSpreadSheet.Load("spreadsheet.bin");

            for (int nCol = 0; nCol < sheet.NumberOfColumns; nCol++)
            {
                for (int nRow = 0; nRow < sheet.NumberOfRows; nRow++)
                {
                    Debug.Assert(sheet.GetValue(nCol, nRow) == 1, "Not the correct value");
                }
            }
        }
    }
}
