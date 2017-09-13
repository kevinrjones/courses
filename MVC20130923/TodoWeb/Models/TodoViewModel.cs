using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoWeb.Models
{
    public class TodoViewModel
    {
        public TodoViewModel()
        {
            Priorities = new List<SelectListItem>
            {
                new SelectListItem{Text = "One", Value = "1"},
                new SelectListItem{Text = "Two", Value = "2"},
                new SelectListItem{Text = "3", Value = "3"},
                new SelectListItem{Text = "4", Value = "4"},
                new SelectListItem{Text = "5", Value = "5"},
            };
        }
        public int Id { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
        public DateTime FinishBy { get; set; }
        public string DoBy { get; set; }

        public List<SelectListItem> Priorities { get; set; }
    }
}