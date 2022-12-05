using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Album;

namespace MusicApp.Controllers
{
    public class AlbumController : BaseController
    {
        private readonly ILogger<HomeController> logger;
        private readonly IAlbumService albumService;

        public AlbumController(ILogger<HomeController> _logger, IAlbumService _albumService)
        {
            logger = _logger;
            albumService = _albumService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllAlbumsModel query)
        {
            var result = await albumService.GetAllAlbums(query.Genre, query.SearchTerm, query.Sorting, query.CurrentPage, AllAlbumsModel.AlbumsPerPage);

            query.TotalAlbumsCount = result.TotalAlbumsCount;
            query.Genres = await albumService.GetGenres();
            query.Albums = result.Albums;

            return View(query);
        }
    }
}
