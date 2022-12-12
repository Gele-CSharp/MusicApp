using Microsoft.AspNetCore.Mvc;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Album;

namespace MusicApp.Areas.Admin.Controllers
{
    public class AlbumController : BaseController
    {
        private readonly IAlbumService albumService;

        public AlbumController(IAlbumService _albumService)
        {
            albumService = _albumService;
        }

        public async Task<IActionResult> All([FromQuery] AllAlbumsModel query)
        {
            var result = await albumService.GetAllAlbums(query.Genre, query.SearchTerm, query.Sorting);

            query.TotalAlbumsCount = result.TotalAlbumsCount;
            query.Genres = await albumService.GetGenres();
            query.Albums = result.Albums;

            return View(query);
        }

        public async Task<IActionResult> Details(int albumId)
        {
            var model = await albumService.GetAlbumDetails(albumId);

            return View(model);
        }
    }
}
