using System.ComponentModel.DataAnnotations;
using System.Data.Common;
namespace AppStore.Models
{
    public abstract class Product
    {
        [Required]
        [Range(0, 100000)]
        protected decimal Price;
        protected bool IsFavorite;
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        protected string Name;
        [MaxLength(1000)]
        [MinLength(10)]
        protected string Description;
        [Required]
        [Range(0,double.PositiveInfinity)]
        protected int Id;

    }
}
