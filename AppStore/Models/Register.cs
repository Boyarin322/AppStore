using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace AppStore.Models
{
    public class Register
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Input your name")]
        [MinLength(3, ErrorMessage = "Name must contain at least 3 symbols")]
        [MaxLength(20, ErrorMessage = "Name must not be longer than 20 symbols")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Input your email")]
        [RegularExpression("^[a - z0 - 9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$"
        ,ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Input your password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must contain at least 6 symbols")]
        [MaxLength(30, ErrorMessage = "Password must not be longer than 30 symbols")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Repeat your password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must contain at least 6 symbols")]
        [MaxLength(30, ErrorMessage = "Password must not be longer than 30 symbols")]
        [Compare("Password", ErrorMessage = "Passwords not equal")]
        public string ConfirmPassword { get; set; }

    }
}
