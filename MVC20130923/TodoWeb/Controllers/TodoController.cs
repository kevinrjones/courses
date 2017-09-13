using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Protocols;
using ServiceModels;
using TodoServices;
using TodoWeb.Filters;
using TodoWeb.Models;
using User = TodoWeb.Models.User;

namespace TodoWeb.Controllers
{
    [LoggingFilter]
    public class TodoController : BaseController
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        //[MyExceptionFilter]
        [OutputCache(CacheProfile = "NoStore")]
        public ActionResult Index()
        {
            //throw new Exception();
            var monster = Request.Cookies["monster"];
            
            if (monster == null)
            {
                Response.Cookies.Add(new HttpCookie("monster"){Value = "Cookies!!!"});
            }

            var state = Session["Shopping"] as ShoppingCartSession;

            if (state == null)
            {
                Session["Shopping"] = new ShoppingCartSession{Quantity = 5};
            }

            var user = _todoService.GetTodos(1);



            var model = new User
            {
                EMail = user.EMail,
                Todos =
                    user.Todos.Select(
                        todo =>
                            new TodoViewModel {Id = todo.Id, Description = todo.Description, FinishBy = todo.FinishBy})
                        .ToList()
            };

            return View(model);
        }

        public ActionResult Show(int id)
        {
            var user = _todoService.GetTodos(1);
            var model = new User
            {
                EMail = user.EMail,
                Todos =
                    user.Todos.Select(
                        todo =>
                            new TodoViewModel { Id = todo.Id, Description = todo.Description, FinishBy = todo.FinishBy, Priority = todo.Priority})
                        .ToList()
            };
            var item = model.Todos.First(t => t.Id == id);

            if (Request.IsAjaxRequest())
            {
                return PartialView("Show", item);
            }
            return View(item);
        }

        public ActionResult New()
        {
            return View(new TodoCreationViewModel());
        }

        public ActionResult Create(TodoCreationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("New", model);
            }
            _todoService.Add(1, new Todo { Description = model.Description, FinishBy = model.FinishBy, Priority = model.Priority });
            TempData["Message"] = "Successfully create todo item";
            return RedirectToRoute(new { controller = "Todo", action = "index"});
        }

    }
}
