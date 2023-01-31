using AppStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if(ModelState.IsValid)
            {
                
            }
            return View();
        }

        public IActionResult Logger()
        {
            return View();
        }
    }
}
