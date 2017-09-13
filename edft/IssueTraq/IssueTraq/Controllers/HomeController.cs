using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using IssueRepository.Interfaces;
using IssueTraq.Models;

namespace IssueTraq.Controllers
{
    public class HomeController : Controller
    {
        private IIssueRepository _repository;

        public HomeController(IIssueRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var issues = _repository.Entities.ToList();
            List<Issue> modelIssues = new List<Issue>();
            foreach (var issue in issues)
            {
                var i = new Issue
                {
                    Title = issue.Title
                };
                modelIssues.Add(i);
            }

            return View(modelIssues);
        }

        public ActionResult Get(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            return View(new Issue());
        }

        [HttpPost]
        public ActionResult Create(Issue issue, Issue issue1)
        {
            if (!ModelState.IsValid)
            {
                return View("New", issue);
            }
            _repository.Create(new Entities.Issue { Title = issue.Title, Description = issue.Description });

            return RedirectToAction("Index");
        }

        public ActionResult GetAsJson()
        {
            var issues = _repository.Entities.ToList();
            List<Issue> modelIssues = new List<Issue>();
            foreach (var issue in issues)
            {
                var i = new Issue
                {
                    Title = issue.Title
                };
                modelIssues.Add(i);
            }
            return Json(modelIssues, JsonRequestBehavior.AllowGet);
        }

    }
}