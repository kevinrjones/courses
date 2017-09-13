using System.Collections.Specialized;
using System.Web;

namespace TaskListTests.Helpers
{
    public class FakeRequest : HttpRequestBase
    {
        private readonly NameValueCollection _values = new NameValueCollection();
        public override string this[string key]
        {
            get { return _values[key]; }
        }
    }
}