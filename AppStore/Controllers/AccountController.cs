using AppStore.Interfaces;
using AppStore.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
             return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var response = await _userService.Register(model);
               if(response.StatusCode == Enums.StatusCode.Success)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new System.Security.Claims.ClaimsPrincipal(response.Data));

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Logger()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logger(LoggerViewModel model)
        {
            if(ModelState.IsValid)
            {
                var response = await _userService.Logger(model);
                if(response.StatusCode == Enums.StatusCode.Success)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new System.Security.Claims.ClaimsPrincipal(response.Data));

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

    }
}
