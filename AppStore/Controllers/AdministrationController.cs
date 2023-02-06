using AppStore.Interfaces;
using AppStore.Models;
using AppStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IUserService _userService;

        public AdministrationController(IUserService userService)
        {
            _userService = userService;
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
            return RedirectToAction("Users", "Administration");
        }
    }
}
