﻿using Microsoft.AspNetCore.Mvc;

namespace MusicApp.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
