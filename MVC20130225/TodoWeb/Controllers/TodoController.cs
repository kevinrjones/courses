using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using SystemFileAdapter;
using Entities;
using FileSystemInterfaces;
using ServiceInterfaces;
using TodoRepository.Interfaces;
using TodoWeb.Filters;
using TodoWeb.Models;

namespace TodoWeb.Controllers
{
    public class TodoController : Controller
    {
        readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [OutputCache(CacheProfile = "kevin")]
        public ActionResult Index()
        {
            var cookie = new HttpCookie("alice", "bob");
            cookie.Expires = new DateTime(2023, 11, 11);
            cookie.HttpOnly = true;
            cookie.Secure = true;
            Session["data"] = "Hello World";
            Response.Cookies.Add(cookie);

            var todos = new List<TodoViewModel>
                {
                    new TodoViewModel{Id =1, What = "Do something", Who = "kevinj@mantiso.com", When = DateTime.Now}, 
                    new TodoViewModel{Id=2, What = "Do what my wife tells me!", Who = "kevinj@mantiso.com", When = DateTime.Now}
                };
            return View(todos);
        }

        [MyFilter]
        public ActionResult Get(string id)
        {
            var model = new TodoViewModel();
            // lookup based on id
            // populate model
            model.Who = "kevinj@mantiso.com";
            model.What = "Finish the controller";
            if (Request.IsAjaxRequest())
            {
                return PartialView("_TodoItemView", model);
            }
            return View(model);
        }

        public ActionResult New()
        {
            return View(new CreateTodoViewModel());
        }

        public ActionResult Create(CreateTodoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("New", model);
            }
            _todoService.AddTodo(new Todo {TodoText = model.WhatToDo, TodoDate = model.WhenToDoIt});
            TempData["message"] = "Added new todo";
            return RedirectToAction("Index");

        }

        public ActionResult Update()
        {
            var models = new []{new TodoViewModel{Who = "Kevin"}, new TodoViewModel{Who="Fred"}};
            return Json(models);
        }

        public ActionResult ThrowError()
        {
            throw new Exception();
        }
    }
}
