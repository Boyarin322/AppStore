using AppStore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;
        public ProductsController(ILogger<ProductsController> logger, IProductService productService) 
        {
            _logger = logger; 
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productService.GetProducts();
            if (response.StatusCode == Enums.StatusCode.Success)
            {
                return View(response.Data);
            }
            _logger.LogError(response.Description);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var response = await _productService.GetProduct(id);
            if(response.StatusCode == Enums.StatusCode.Success)
            {
                return View(response.Data);
            }
            _logger.LogError(response.Description);
            return RedirectToAction("Index", "Home");
        }
        //public async Task<IActionResult> UpdateProduct(Guid id)
        //{
          //  var responce = await _productService.UpdateProduct(id);
        //}
    }
}
