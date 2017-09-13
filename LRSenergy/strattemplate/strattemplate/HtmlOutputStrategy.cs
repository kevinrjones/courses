using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace strattemplate
{
    public class HtmlOutputStrategy : IOutputStrategy
    {
        private XmlWriter writer;

        public HtmlOutputStrategy(string filename)
        {
            writer = new XmlTextWriter(filename, Encoding.UTF8);
            writer.WriteStartElement("HTML");
            writer.WriteStartElement("BODY");
        }

        public void OutputTitle(string title)
        {
            writer.WriteElementString("H2", title);
        }

        public void OutputHeader(IEnumerable<string> headers)
        {
            writer.WriteStartElement("table");
            writer.WriteStartElement("tr");

            foreach (var header in headers)
            {
                writer.WriteElementString("th", header);
            }

            writer.WriteEndElement();
        }

        public void OutputRows(IEnumerable<object[]> rows)
        {
            foreach (var row in rows)
            {
                writer.WriteStartElement("tr");

                foreach (var item in row)
                {
                    writer.WriteElementString("td", item.ToString());
                }

                writer.WriteEndElement();
                
            }
            writer.WriteEndElement();
        }

        public void OutputFooter(string footer)
        {
            writer.WriteElementString("FOOTER", footer);
            writer.Close();
        }
    }
}