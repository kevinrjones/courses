using System;
using System.Collections.Generic;
using System.IO;

namespace strattemplate
{
    public class FileTemplate : ReportTemplate
    {
        private readonly string _dir;

        public FileTemplate(string dir, IOutputStrategy strategy) : base(strategy)
        {
            _dir = dir;
        }

        protected override IEnumerable<object[]> GetRows()
        {
            
            foreach (FileInfo file in new DirectoryInfo(_dir).GetFiles())
            {
                object[] row = new object[] { file.Name, file.Length, file.LastAccessTime };
                yield return row;
            }
            
        }

        protected override IEnumerable<string> GetColumnNames()
        {
            return new [] {"Filename", "Size", "Last Modified"};
        }

        protected override string GetTitle()
        {
            return string.Format("Report on Directory {0}", _dir);            
        }
    }
}