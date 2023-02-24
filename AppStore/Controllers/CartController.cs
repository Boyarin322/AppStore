using AppStore.Interfaces;
using AppStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AppStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly IProductService _productService;

        public CartController(ILogger<CartController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}
