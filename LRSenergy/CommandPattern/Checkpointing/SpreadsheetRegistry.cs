using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpointing
{
    class SpreadSheetRegistry
    {
        private Dictionary<string, SpreadSheet> sheets = new Dictionary<string, SpreadSheet>();

        private static object _initLock = new object();

        private static SpreadSheetRegistry _instance;

        public static SpreadSheetRegistry GetInstance()
        {
            if (_instance == null)
            {
                CreateInstance();
            }
            return _instance;
        }

        public SpreadSheet GetSheetByName(string name)
        {
            return sheets[name];
        }

        public void RegisterSheet(string name, SpreadSheet sheet)
        {
            sheets[name] = sheet;
        }

        public void UnRegisterSheet(string name)
        {
            sheets[name] = null;
        }

        private static void CreateInstance()
        {
            lock (_initLock)
            {
                if (_instance == null)
                {
                    _instance = new SpreadSheetRegistry();
                }
            }
        }

        private SpreadSheetRegistry()
        {
        }
    }

}
