using System.ComponentModel.DataAnnotations;

namespace AppStore.Enums
{
    public enum Roles
    {
        [Display(Name = "User")]
        User = 0,
        [Display(Name = "Moderator")]
        Moderator = 1,
        [Display(Name = "Admin")]
        Admin = 2,
    }
}