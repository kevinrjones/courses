using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TaskList.Models;

namespace TaskList.Controllers
{
    public class SessionController : Controller
    {
        //
        // GET: /Session/

        public ActionResult New(User user)
        {
            return View(user);
        }

        public ActionResult Create(User user)
        {
            FormsAuthentication.SetAuthCookie(user.Name, false);
            return RedirectToAction("Index", "List");
        }

    }
}
