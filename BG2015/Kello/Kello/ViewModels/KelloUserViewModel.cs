using System.ComponentModel.DataAnnotations;

namespace Kello.ViewModels
{
    public class KelloUserViewModel
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}