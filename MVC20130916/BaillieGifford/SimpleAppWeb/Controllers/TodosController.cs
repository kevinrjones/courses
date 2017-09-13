using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGServices;
using DataModels;
using SimpleAppWeb.Filters;
using SimpleAppWeb.Models;

namespace SimpleAppWeb.Controllers
{
    public class TodosController : BaseController
    {
        private ITodoService _service;

        public TodosController(ITodoService service)
        {
            _service = service;
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "none")]
        public ActionResult Index()
        {
            var data = Request.Cookies["Alice"];
            if (data == null)
            {
                var cookie = new HttpCookie("Alice", "Some Data");
                Response.Cookies.Add(cookie);
            }

            var sessionData = Session["SessionItem"];
            if (sessionData == null)
            {
                sessionData = Session["SessionItem"] = "Some data";
            }
            var user = _service.GetTodoItemsForUser(1);
            var viewModel = new UserViewModel {Name = user.Name, EMailAddress = user.EMail};
            var todoVMs = new List<TodoViewModel>();
            foreach (var todo in user.Todos)
            {
                var model = new TodoViewModel { Id = todo.Id, Description = todo.Description };
                todoVMs.Add(model);
            }

            var ut = new UserTodos {User = viewModel, Todos = todoVMs};

            return View(ut);
        }


        public ActionResult Get(int id)
        {
            var user = _service.GetTodoItemForUser(1, id);
            var item = user.Todos.FirstOrDefault();
            var model = new TodoViewModel
            {
                Id = item.Id,
                Description = item.Description,
                Priority = item.Priority,
                DoBy = DateTime.Now
            };
            if (Request.IsAjaxRequest())
            {
                return PartialView("TodoDetails", model);
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult New()
        {            
            return View(new TodoItemCreateViewModel());
        }

        [HttpPost]
        public ActionResult Create(TodoItemCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("New", new TodoItemCreateViewModel{Description = model.Description, Priority = model.Priority});
            }
            var todo = new Todo { Id = 5, Description = model.Description, Priority = model.Priority, DoBy = DateTime.Now};

            _service.AddTodoItem(1, todo);

            TempData["message"] = "Todo Item Created";
            return RedirectToAction("Index");
        }
    }
}
