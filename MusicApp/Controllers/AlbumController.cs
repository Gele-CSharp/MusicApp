using Microsoft.AspNetCore.Mvc;

namespace MusicApp.Controllers
{
    public class AlbumController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
