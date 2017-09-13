using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logging;

namespace SimpleAppWeb.Filters
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        public ILogger Logger { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Logger.Debug(filterContext.ActionDescriptor.ActionName);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}