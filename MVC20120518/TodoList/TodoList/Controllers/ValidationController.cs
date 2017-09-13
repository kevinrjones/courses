using System.Web.Mvc;

namespace TodoList.Controllers
{
    public class ValidationController : Controller
    {
        public ActionResult ValidateAge(int age)
        {
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}