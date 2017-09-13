using System.Web.Mvc;
using TodoList.Helpers;

namespace TodoList.Controllers
{
    [LogFilter]
    [MyAuthorize(Users = "kevin", Roles = "foo")]
    [MyAuthorize(Roles = "bar")]
    public class BaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            // log
            base.HandleUnknownAction(actionName);
        }
    }
}