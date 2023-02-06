using System.ComponentModel.DataAnnotations;

namespace AppStore.Models.ViewModels
{
    public class LoggerViewModel
    {
        [Required(ErrorMessage = "Input your name")]
        [MinLength(3, ErrorMessage = "Username must contain at least 3 symbols")]
        [MaxLength(20, ErrorMessage = "Username must not be longer than 20 symbols")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Input your password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must contain at least 6 symbols")]
        [MaxLength(30, ErrorMessage = "Password must not be longer than 30 symbols")]
        public string Password { get; set; }
    }
}
