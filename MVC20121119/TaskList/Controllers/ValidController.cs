using System.Web.Mvc;

namespace TaskList.Controllers
{
    public class ValidController : Controller
    {
        public ActionResult IsValid(string email)
        {
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}