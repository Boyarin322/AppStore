using AppStore.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppStore.Models
{
    public class User
    { 
        public User(string username, string email, string password)
        {
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            Password = password; 
            Role = Roles.User;
        }
        

        [Key]
        public Guid Id { get; set; }

        [Required]
   
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
     
        public string Password { get; set; }

        [Required]
        [Display(Name = "Role")]
        public Roles Role { get; set; } 
    }
}
