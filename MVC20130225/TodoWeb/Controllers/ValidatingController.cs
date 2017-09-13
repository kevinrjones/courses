using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoWeb.Controllers
{
    public class ValidatingController : Controller
    {
        //
        // GET: /Validating/

        public ActionResult IsValid(string who)
        {
            if (who == "kevin")
                return Json(true);
            return Json(false);
        }

    }
}
