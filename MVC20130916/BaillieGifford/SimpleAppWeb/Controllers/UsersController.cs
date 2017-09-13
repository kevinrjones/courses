using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SimpleAppWeb.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/

        public ActionResult Get()
        {
            Thread.Sleep(2000);
            return Json(new {Name = "Alice"}, JsonRequestBehavior.AllowGet);
        }

    }

}
