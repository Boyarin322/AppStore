using System.ComponentModel.DataAnnotations;

namespace AppStore.Models
{

    public class Product
    {
        public Product(decimal price, string productname, string description) {
            Price= price;
            Productname= productname;
            Description= description;
            IsFavorite= false;
        }

        [Required]
        public decimal Price;

        public bool IsFavorite;

        [Required]
        public string Productname;

        [Required]
        public string Description;

        [Key]
        [Range(0, double.PositiveInfinity)]
        public int Id;

    }

}