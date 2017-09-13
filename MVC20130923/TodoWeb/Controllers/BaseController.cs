using System.Web.Mvc;

namespace TodoWeb.Controllers
{
    [Authorize(Roles = "admin")]
    public class BaseController : Controller
    {
    }
}