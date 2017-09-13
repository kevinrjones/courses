using System.Web.Mvc;

namespace SimpleAppWeb.Controllers
{
    public class ValidateControllerController : Controller
    {
        public ActionResult IsShoe(string shoes)
        {
            if (shoes == "Choo")
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}