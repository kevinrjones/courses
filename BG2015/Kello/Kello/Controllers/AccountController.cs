using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Kello.Models;
using Kello.ViewModels;
using KelloRepository.Contexts;
using Microsoft.AspNet.Identity;

namespace Kello.Controllers
{
    public class AccountController : Controller
    {
        private readonly KelloUserManager _userManager;

        public AccountController()
        {
            _userManager = new KelloUserManager();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userManager.Dispose();
            }
            base.Dispose(disposing);
        }

        // display the login UI
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // execute the login
        [HttpPost]
        public ActionResult Login(KelloUserViewModel userViewModel)
        {
            return RedirectToAction("Index", "Boards");
        }

        public ActionResult Logout()
        {
            return new RedirectResult("/");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel register)
        {
            return RedirectToAction("Login");
        }


    }
}