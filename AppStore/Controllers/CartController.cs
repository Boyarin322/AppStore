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
        private readonly ICartService _cartService;

        public CartController(ILogger<CartController> logger, ICartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
        }
        [HttpGet]
        public async Task<IActionResult> Cart(Guid userID)
        {
            var response = await _cartService.GetCart(userID);
            if(response.StatusCode == Enums.StatusCode.Success)
            {
                return View(response);
            }
            _logger.LogError(response.Description);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid userID, Guid productID)
        {
            var response = await _cartService.AddToCart(userID,productID);
            if(response.StatusCode == Enums.StatusCode.Success)
        {
                return RedirectToAction("Products", "ProductController");
            }
            _logger.LogError(response.Description);
            return RedirectToAction("Index");
        }
    }
}
