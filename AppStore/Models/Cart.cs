using System.ComponentModel.DataAnnotations;

namespace AppStore.Models
{
    public class Cart
    {
        public Cart(Guid userId, Guid productId)
        {
            Id = Guid.NewGuid();
            User_id = userId;
            Product_id = productId;
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid User_id { get; set; }
        [Required]
        public User User { get; set; }

        [Required]
        public Guid Product_id { get; set; }

        [Required]
        public Product Product { get; set; }
    }

}
