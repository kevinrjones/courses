using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace TodoList.Helpers
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _logger.Debug("Called: {0}", filterContext.ActionDescriptor.ActionName);
        }
    }
}