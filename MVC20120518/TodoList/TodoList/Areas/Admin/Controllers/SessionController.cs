using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoList.Areas.Admin.Controllers
{
    public class SessionController : Controller
    {
        //
        // GET: /Admin/Session/

        public ActionResult Index()
        {
            return View();
        }

    }
}
