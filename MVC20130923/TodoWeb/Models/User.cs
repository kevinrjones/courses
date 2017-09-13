using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoWeb.Models
{
    public class User
    {
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }
        public IList<TodoViewModel> Todos { get; set; }
    }
}