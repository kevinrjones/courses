using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using NLog;
using ShoeServices;
using Shoes.Filters;
using Shoes.Models;
using ShoesModel;

namespace Shoes.Controllers
{
    public class ShoeController : Controller
    {
        readonly IShoeService _shoeService;

        public ShoeController(IShoeService shoeService)
        {
            _shoeService = shoeService;
        }

        [LogFilter]
        [MyErrorHandler]
        public ActionResult Index()
        {
//            throw new Exception();
            var data = _shoeService.GetShoes();

            var shoes = new List<DisplayShoeVM>();

            foreach (var shoe in data)
            {
                shoes.Add(new DisplayShoeVM(shoe));
            }

            if (Request.IsAjaxRequest())
            {
                return Json(shoes, JsonRequestBehavior.AllowGet);
            }
            return View(shoes);
        }

        public ActionResult Show(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            return View(new DisplayShoeVM());
        }

        [HttpPost]
        public ActionResult Create(DisplayShoeVM shoe)
        {
            if (Request.IsAjaxRequest())
            {
                if (!ModelState.IsValid)
                {
                    return new ContentResult { Content = "Failed" };
                }
                return new ContentResult { Content = "OK" };
            }

            if (!ModelState.IsValid)
            {
                return View("New", shoe);
            }
            _shoeService.Create(new Shoe { Color = shoe.Colour, Type = shoe.Type, OwnerEmail = shoe.OwnerEmail, Size = shoe.Size });
            return RedirectToAction("Index");
        }


        public ContentResult Time()
        {
            return new ContentResult { Content = DateTime.Now.ToLongTimeString() };
        }
    }
}
