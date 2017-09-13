using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoWeb.Models
{
    public class TodoViewModel
    {
        public int Id { get; set; }
        public string What { get; set; }
        [UIHint("EmailAddress")]
        public string Who { get; set; }

        public DateTime When { get; set; }
    }
}