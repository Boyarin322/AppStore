using AppStore.Enums;
using System.ComponentModel.DataAnnotations;

namespace AppStore.Models.ViewModels
{
    public class UserViewModel
    {
        [Display(Name= "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Role")]
        public Roles Role { get; set; }
    }
}
