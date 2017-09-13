using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleAppWeb.Helpers
{
    public static class SimpleHelper
    {
        public static MvcHtmlString MyHelper(this HtmlHelper helper, object attrs)
        {
            return new MvcHtmlString("<h2>Goodbye cruel world, I'm leaving you today, goodbye, goodbye, goodbye</h2>");
        }
    }
}