using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace Shoes.Filters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private Logger logger = LogManager.GetLogger("MyLogger");

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            logger.Debug("Some Message");
        }
    }
}