using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TodoList.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString SimpleHelper(this HtmlHelper helper, string text)
        {
            return new MvcHtmlString(string.Format("<h2>{0}</h2>", text));
        }
    }
}