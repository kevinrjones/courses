using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TodoWeb.Validators;

namespace TodoWeb.Models
{
    public class CreateTodoViewModel
    {
        [Required(ErrorMessage = "You must set this field")]
        public string WhatToDo { get; set; }
        [Remote("IsValid", "Validating", HttpMethod = "POST")]
        public string Who { get; set; }
        public DateTime WhenToDoIt { get; set; }
        [MaxDays(Days = 5)]
        public int NumberOfDays { get; set; }
    }
}