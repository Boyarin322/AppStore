using AppStore.Helpers;
using AppStore.Interfaces;
using AppStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<AdministrationController> _logger;
        public AdministrationController(ILogger<AdministrationController> logger, IUserService userService,
            IProductService productService, IWebHostEnvironment environment)
        {
            _logger = logger;
            _userService = userService;
            _productService = productService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var responce = await _userService.GetUsers();
            if (responce.StatusCode == Enums.StatusCode.Success)
            {
                return View(responce.Data);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var response = await _userService.DeleteUser(id);
            if (response.StatusCode == Enums.StatusCode.Success)
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
            var product = await _productService.GetValue(id);

            var photoPath = Path.Combine(_environment.WebRootPath, product.Data.Photo);
            if (System.IO.File.Exists(photoPath))
            {
                System.IO.File.Delete(photoPath);
            }
            else
            {
                _logger.LogError($"not found {photoPath}");
            }
            var responce = await _productService.DeleteProduct(id);
            if (responce.StatusCode == Enums.StatusCode.Success)
            {
                return RedirectToAction("Products", "Administration");
            }
            //add error view
            return RedirectToAction("Products", "Administration");
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                _logger.LogError("Failed to create product due invalid model state");
                return View(model);
            }
            if (ImageHelper.IsImage(model.ImageFile) == false)
            {
                _logger.LogError("Failed to create product due invalid photo filetype");
                return View(model);
            }

            string fileName = $"{model.Productname}-{model.Id}{Path.GetExtension(model.ImageFile.FileName)}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(stream);
            }
            model.Photo = $"/images/{fileName}";

            var responce = await _productService.CreateProduct(model);
            if (responce.StatusCode == Enums.StatusCode.Success)
            {
                _logger.LogInformation(message: $"Product {model.Productname} created");
                return RedirectToAction("Products", "Administration");
            }

            _logger.LogError("Failed to create product due some error");
            return View(model);
        }
    }
}
