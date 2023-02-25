using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace AppStore.Models
{

    public class Product
    {
        public Product(decimal price, string productname, string description, string photo) {

            Price= price;
            Productname= productname;
            Description= description;
            Photo= photo;
            Id= Guid.NewGuid();
        }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }


        [Required]
        public string Productname { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [Key]
        public Guid Id { get; set; }

    }

}