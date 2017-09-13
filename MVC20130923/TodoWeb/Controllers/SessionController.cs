using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TodoWeb.Controllers
{
    public class SessionViewModel
    {
        public string ReturnUrl { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class SessionController : BaseController
    {
        [AllowAnonymous]
        public ActionResult New(string returnUrl)
        {
            return View(new SessionViewModel{ReturnUrl = returnUrl});
        }

        [AllowAnonymous]
        public ActionResult Create(SessionViewModel model)
        {
            // are you authentic
            if (model.Name == model.Password)
            {
                FormsAuthentication.SetAuthCookie(model.Name, false);
                return Redirect(model.ReturnUrl);
            }
            return View("New", model);
        }
    }
}
