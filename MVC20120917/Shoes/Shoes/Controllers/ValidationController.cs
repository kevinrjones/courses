using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shoes.Controllers
{
    public class ValidationController : Controller
    {
        public ActionResult IsEmailValid()
        {
            return Json(false);
        }

    }
}
