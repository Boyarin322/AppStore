using System.ComponentModel.DataAnnotations;
using System.Data.Common;
namespace AppStore.Models
{
    public abstract class Product
    {
        [Required]
        [Range(0, 100000)]
        protected decimal price;
        protected bool isFavorite;
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        protected string name;
        [MaxLength(1000)]
        [MinLength(10)]
        protected string description;
        [Required]
        [Range(0,double.PositiveInfinity)]
        protected int id;
        protected Photo photo;

    }
}
