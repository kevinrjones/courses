using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using Repository;
using TodoList.Helpers;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUsersRepository _users;
        string[] names = new[] { "Hardik", "Elliot", "Mark", "Hugo", "Kevin" };

        public UserController(IUsersRepository users)
        {
            _users = users;
        }

        [LogFilter]
        [HandleError(View = "MyError")]
        [MyAuthorize(Users = "kevin")]
        public ActionResult Index()
        {
            var users = _users.GetUsers();
            var usersVM = new List<UserModel>();

            foreach (var user in users)
            {
                var model = new UserModel {Age = user.Age, Id = user.Id, Name = user.Name};
                usersVM.Add(model);
            }
            
            return View(usersVM);
        }

        public ActionResult Details(int id)
        {
            return PartialView("Details", names[id - 1]);
        }

        public ActionResult Users()
        {
            var users = new List<UserModel>
                                        {
                                            new UserModel{Id = 1, Name = "Hardik", Age = 27}, 
                                            new UserModel{Id = 2, Name = "Elliot", Age=22},
                                            new UserModel{Id = 3, Name = "Mark", Age = 43}, 
                                            new UserModel{Id = 4, Name = "Hugo", Age=45},
                                            new UserModel{Id = 5, Name = "Kevin", Age=0x32},
                                        };
            return Json(users);
        }

        public ActionResult New()
        {
            Response.Cookies.Add(new HttpCookie("user", "kevin"));
            FormsAuthentication.RedirectToLoginPage();
            return View(new UserModel());
        }

        public ActionResult Create(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("new", user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

//        [OutputCache(Location = OutputCacheLocation.Server, Duration = 5)]
        [OutputCache(CacheProfile = "simple")]
        public string CurrentTime()
        {
            return DateTime.Now.ToLongTimeString();
        }
    }
}
