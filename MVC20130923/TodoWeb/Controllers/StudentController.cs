using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace TodoWeb.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Details()
        {
            return Json(new Student { Id = 1, Name = "Atle", ShoeSize = 45 }, JsonRequestBehavior.AllowGet);
        }

    }

    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ShoeSize { get; set; }
    }
}
