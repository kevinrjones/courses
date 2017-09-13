using System;
using System.Web.Mvc;
using TodoList.Helpers;

namespace TodoList.Models
{
    [Serializable]
    public class UserModel
    {
        public int Id { get; set; }
        [NameValidation(ErrorMessage = "Name is Invalid")]
        public string Name { get; set; }
        //[Remote("ValidateAge", "Validation")]
        public int Age { get; set; }
    }
}
