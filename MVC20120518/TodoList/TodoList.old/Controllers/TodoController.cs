using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        public ActionResult Index()
        {
            var name = new UserModel {Name = "Hugo"};
          
            return View(name);
        }

        public ActionResult New()
        {
            var name = new UserModel();
            return View(name);
        }
    }
}
