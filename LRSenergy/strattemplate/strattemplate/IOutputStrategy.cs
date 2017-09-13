using System.Collections.Generic;

namespace strattemplate
{
    public interface IOutputStrategy
    {
        void OutputTitle(string title);
        void OutputHeader(IEnumerable<string> header);
        void OutputRows(IEnumerable<object[]> rows);
        void OutputFooter(string footer);
    }
}