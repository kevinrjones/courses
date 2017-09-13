using System.Collections.Generic;
using System.IO;

namespace strattemplate
{
    public class DirectoryTemplate : ReportTemplate
    {
        private readonly string _dir;

        public DirectoryTemplate(string dir, IOutputStrategy strategy)
            : base(strategy)

        {
            _dir = dir;
        }

        protected override IEnumerable<object[]> GetRows()
        {

            foreach (DirectoryInfo file in new DirectoryInfo(_dir).GetDirectories())
            {
                object[] row = new object[] { file.Name, file.LastAccessTime };
                yield return row;
            }

        }

        protected override IEnumerable<string> GetColumnNames()
        {
            return new[] { "Filename", "Last Modified" };
        }

        protected override string GetTitle()
        {
            return string.Format("Report on Directory {0}", _dir);
        }
    }
}