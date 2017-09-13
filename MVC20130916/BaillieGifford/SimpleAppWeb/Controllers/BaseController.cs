using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleAppWeb.Filters;

namespace SimpleAppWeb.Controllers
{
    [LoggingFilter]
    [RossFilter]
    public class BaseController : Controller
    {
    }
}
