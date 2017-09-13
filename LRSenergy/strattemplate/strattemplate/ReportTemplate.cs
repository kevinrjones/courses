using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace strattemplate
{
    public abstract class ReportTemplate
    {
        private readonly IOutputStrategy _outputStrategy;

        public ReportTemplate(IOutputStrategy outputStrategy)
        {
            _outputStrategy = outputStrategy;
        }

        public void ProduceReport()
        {
            _outputStrategy.OutputTitle(GetTitle());
            

           _outputStrategy.OutputHeader(GetColumnNames());


            _outputStrategy.OutputRows(GetRows());

            _outputStrategy.OutputFooter(string.Format("Report Produced {0} by {1}",
                DateTime.Now,
                WindowsIdentity.GetCurrent().Name));
        }

        protected abstract IEnumerable<object[]> GetRows();

        protected abstract IEnumerable<string> GetColumnNames();

        protected abstract string GetTitle();
    }
}