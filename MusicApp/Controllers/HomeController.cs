using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Album;
using MusicApp.Models;
using System.Diagnostics;
using static MusicApp.Infrastructure.Data.DataConstants.Album;

namespace MusicApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;
        private readonly IAlbumService albumService;
        private readonly IMemoryCache cache;


        public HomeController(ILogger<HomeController> _logger,
                              IAlbumService _albumService,
                              IMemoryCache _cache)
        {
            logger = _logger;
            albumService = _albumService;
            cache = _cache;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = cache.Get<IEnumerable<HomepageAlbumModel>>(LastThreeAlbumsCacheKey);

            if (model == null)
            {
                model = await albumService.GetLastThreeAlbums();
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(3));

                cache.Set(LastThreeAlbumsCacheKey, model, cacheOptions);
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}