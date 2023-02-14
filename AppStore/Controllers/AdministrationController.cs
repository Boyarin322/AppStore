using AppStore.Helpers;
using AppStore.Interfaces;
using AppStore.Models;
using AppStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly ILogger<AdministrationController> _logger;
        public AdministrationController(ILogger<AdministrationController> logger,IUserService userService, IProductService productService)
        {
            _logger = logger;
            _userService = userService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var responce = await _userService.GetUsers();
            if(responce.StatusCode == Enums.StatusCode.Success)
            {
                return View(responce.Data);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _userService.DeleteUser(id);
            if(response.StatusCode== Enums.StatusCode.Success)
            {
                return RedirectToAction("Users", "Administration");
            }
            //add error view
            return RedirectToAction("Users", "Administration");
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(string email)
        {
            var result = await EmailHelper.SendMailAsync(email, "Checking...");
            _logger.LogInformation($"Messege to : {email} was sent: {result}");
            return RedirectToAction("Users", "Administration");
        }
        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var responce = await _productService.GetProducts();
            if (responce.StatusCode == Enums.StatusCode.Success)
            {
                return View(responce.Data);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var responce = await _productService.DeleteProduct(id);
            if(responce.StatusCode== Enums.StatusCode.Success)
            {
                return RedirectToAction("Products", "Administration");
            }
            //add error view
            return RedirectToAction("Products", "Administration");
        }
    }
}
