using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TodoList.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login()
        {
            FormsAuthentication.SetAuthCookie("kevin", false);
            return RedirectToAction("index", "user");
        }

    }
}
