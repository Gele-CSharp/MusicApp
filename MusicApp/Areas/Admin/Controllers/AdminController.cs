using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        private readonly SignInManager<User> signInManager;

        public AdminController(SignInManager<User> _signInManager)
        {
            signInManager = _signInManager;
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
