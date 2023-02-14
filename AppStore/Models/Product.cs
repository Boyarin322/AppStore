using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppStore.Models
{

    public class Product
    {
        public Product(decimal price, string productname, string description) {

            Price= price;
            Productname= productname;
            Description= description;
            Id= Guid.NewGuid();
        }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }


        [Required]
        public string Productname { get; set; }

        [Required]
        public string Description { get; set; }

        [Key]
        public Guid Id { get; set; }

    }

}