using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Entities;
using Microsoft.Web.WebPages.OAuth;
using TaskList.Filters;
using TaskList.Models;
using TodoRepository.interfaces;

namespace TaskList.Controllers
{
    [LogFilter]
    public class ListController : Controller
    {
        private readonly ITodoRepository _repository;

        public ListController()
        {
            
        }

        public ListController(ITodoRepository repository)
        {
            _repository = repository;
        }
        public void LoginWithGoogle()
        {
            var url = Url.Action("LoginCallback");
            OAuthWebSecurity.RequestAuthentication("google", url);
        }

        public ActionResult LoginCallback()
        {
            var result = OAuthWebSecurity.VerifyAuthentication();
            if (result.IsSuccessful)
            {
                return View("Index");
            }
            return View("Error", result.Error);
        }

        //[OutputCache(Duration = 60, VaryByParam = "none", Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult Index()
        {
            //throw new Exception();
            var cookie = new HttpCookie("kev", "jones");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Add(cookie);
            Session["data"] = "kevin";
            List<TodoViewModel> viewModel = _repository.Entities.Select(t => new TodoViewModel { Todo = t.WhatToDo, When = t.WhenToDoIt }).ToList();

            return View(viewModel);
        }

        [HttpGet]
        [MyErrorHandler]
        [Authorize]
        public ActionResult New(string description, int? value)
        {
            //throw new Exception();
            var model = new TodoViewModel { EMail = "kevinj@mantiso.com", When = DateTime.Now };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(TodoViewModel model)
        {
            if (!Request.IsAjaxRequest())
            {
                if (!ModelState.IsValid)
                {
                    return View("New", model);
                }
                var todo = new Todo { WhatToDo = model.Todo, WhenToDoIt = model.When == null ? DateTime.Now : model.When.Value };
                _repository.Create(todo);
                TempData["message"] = "New Item Added";
                return RedirectToAction("Index");
            }
            return Json(new { message = "Success" });
        }

        public ActionResult GetDate()
        {
            return PartialView("_date");
        }
    }
}
