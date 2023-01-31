using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppStore.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]

        public string Email { get; set; }

    }
}
