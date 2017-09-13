using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kello.ViewModels;

namespace Kello.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        public ActionResult Show(string id)
        {
            // look up board in db
            // create a board view model
            var board = new BoardViewModel { Id = 1, Title = "Teach MVC" };
            // render vm
            return View(board);
        }

        public ActionResult CreateList(NewListViewModel vm)
        {
            return View();
        }

        public ActionResult ShowAsJson()
        {
            var board = new BoardViewModel { Id = 1, Title = "Teach MVC" };

            return Json(board, JsonRequestBehavior.AllowGet);
        }

        public string Text()
        {
            return "Hello, World";
        }
    }
}