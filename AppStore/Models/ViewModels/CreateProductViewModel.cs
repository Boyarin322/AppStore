using System.ComponentModel.DataAnnotations;

namespace AppStore.Models.ViewModels
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Input product name")]
        [MinLength(3, ErrorMessage = "Productname must contain at least 3 symbols")]
        [MaxLength(30, ErrorMessage = "Productname must not be longer than 30 symbols")]
        public string Productname { get; set; }

        [Required(ErrorMessage = "Input description")]
        [MinLength(20, ErrorMessage = "Productname must contain at least 20 symbols")]
        [MaxLength(500, ErrorMessage = "Productname must not be longer than 500 symbols")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Input price")]
        [Range(0, int.MaxValue, ErrorMessage ="Price must be valid")]
        public decimal Price { get; set; }
    }
}
