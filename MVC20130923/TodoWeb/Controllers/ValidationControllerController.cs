using System.Web.Mvc;

namespace TodoWeb.Controllers
{
    public class ValidationControllerController : Controller
    {
        public ActionResult ValidateColor(string shoecolor)
        {
            bool isValid = shoecolor == "maroon" || shoecolor == "black";
            return Json(isValid);
        }
    }
}