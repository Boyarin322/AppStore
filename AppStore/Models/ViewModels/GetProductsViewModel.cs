using System.ComponentModel.DataAnnotations;

namespace AppStore.Models.ViewModels
{
    public class GetProductsViewModel
    {
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Productname")]
        public string Productname { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public decimal? Price { get; set; }

    }
}
