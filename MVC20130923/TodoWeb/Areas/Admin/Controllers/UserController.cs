using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TodoWeb.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /Admin/User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return RedirectToAction("Index", "Todo", new { area = ""});
        }
        

    }
}
