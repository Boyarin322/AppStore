using System.ComponentModel.DataAnnotations;

namespace AppStore.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Input your name")]
        [MinLength(3, ErrorMessage = "Username must contain at least 3 symbols")]
        [MaxLength(20, ErrorMessage = "Username must not be longer than 20 symbols")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Input your email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
        , ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Input your password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must contain at least 6 symbols")]
        [MaxLength(30, ErrorMessage = "Password must not be longer than 30 symbols")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repeat your password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must contain at least 6 symbols")]
        [MaxLength(30, ErrorMessage = "Password must not be longer than 30 symbols")]
        [Compare("Password", ErrorMessage = "Passwords not equal")]
        public string ConfirmPassword { get; set; }

    }
}
