using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Helpers;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TodoController : BaseController
    {
        [HttpGet]
        [LogFilter]
        public ActionResult Index()
        {
//            Response.Cookies.Add(new HttpCookie("newuser", "kevin"){Expires = DateTime.Now.AddDays(1)});
            var todos = new List<NewTodoModel>();
            for (int i = 0; i < 10; i++)
            {
                var model = new NewTodoModel { Priority = i, Title = "Title " + i, Entry = "Entry " + i };
                todos.Add(model);
            }
            return View(todos);
        }

        [HttpGet]
        public ActionResult New()
        {
            var model = new NewTodoModel();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Create(NewTodoModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            
            return View("New", model);
        }

        [HttpGet]
        public ActionResult GetFile(string name)
        {
            var routePath = Server.MapPath("~/pdfs");
            var fileName = Path.Combine(routePath, name + ".pdf");
            return File(fileName, "application/pdf");
        }

        public ActionResult GetJson()
        {
            var item = new NewTodoModel { Title = "Do slides", Entry = "For the course", Priority = 1 };
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}
