using System.ComponentModel.DataAnnotations;
using System.Data.Common;
namespace AppStore.Models
{
    public class Product
    {
        [Required]
        [Range(0, 100000)]
        public decimal Price;
        public bool IsFavorite;
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Name;
        [MaxLength(1000)]
        [MinLength(10)]
        public string Description;
        [Required]
        [Range(0,double.PositiveInfinity)]
        public int Id;

    }
}
