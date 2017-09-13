using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using SimpleAppWeb.Controllers;

namespace SimpleAppWeb.Models
{
    public class UserTodos
    {
        public UserViewModel User { get; set;}
        public List<TodoViewModel> Todos { get; set; }
    }
}