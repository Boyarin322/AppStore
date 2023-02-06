using AppStore.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppStore.Models
{
    public class User
    { 
        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
            Role = Roles.User;
        }
        

        [Key]
        public int Id { get; set; }

        [Required]
   
        public string Username { get; set; }

        [Required]
     
        public string Password { get; set; }

        [Required]

        public string Email { get; set; }

        [Required]
        [Display(Name = "Role")]
        public Roles Role { get; set; } 
    }
}
