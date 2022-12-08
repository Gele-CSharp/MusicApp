using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Album;
using MusicApp.Core.Models.Comments;
using MusicApp.Infrastructure.Data.Entities;

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

        [AllowAnonymous]
        public async Task<IActionResult> Details(int albumId)
        {
            var model = await albumService.GetAlbumDetails(albumId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Comment(CommentModel model, int albumId)
        {
            var userId = User.Id();

            if (model.Comment != null)
            {
                await albumService.AddComent(albumId, userId, model.Comment);
            }

            return RedirectToAction(nameof(Details), new { albumId });
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddAlbumModel();
            var genreModels = await albumService.GetGenreModels();
            model.Genres = genreModels;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAlbumModel model)
        {
            if (ModelState.IsValid == false)
            {
                var genreModels = await albumService.GetGenreModels();
                model.Genres = genreModels;

                return View(model);
            }

            string userId = User.Id();
            int albumId = await albumService.AddAlbum(model, userId);

            return RedirectToAction(nameof(Details), new {albumId});
        }
    }
}
