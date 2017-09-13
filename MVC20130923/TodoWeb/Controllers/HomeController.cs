using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoWeb.Models;

namespace TodoWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        static List<User> _names = new List<User> { new User { EMail = "Alice" }, new User { EMail = "Bob" }, new User { EMail = "Charlie" }, };


        public ActionResult Index()
        {
            return View(_names);
        }


        public ActionResult Get(int? id)
        {
            return new EmptyResult();
        }


        // GET
        public ActionResult New()
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Create(string name)
        {
            _names.Add(new User { EMail = name });
            return Redirect("/");
        }
    }
}
