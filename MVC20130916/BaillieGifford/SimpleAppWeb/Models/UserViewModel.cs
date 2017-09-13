using System.ComponentModel.DataAnnotations;

namespace SimpleAppWeb.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EMailAddress { get; set; }
    }
}