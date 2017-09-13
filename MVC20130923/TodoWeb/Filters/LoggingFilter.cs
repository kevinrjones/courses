using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logging;

namespace TodoWeb.Filters
{
    public class LoggingFilter : ActionFilterAttribute
    {
        public ILogger Logger { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Logger.Info(filterContext.ActionDescriptor.ActionName + " was called");
        }

    }

}