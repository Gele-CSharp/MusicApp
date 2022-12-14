using Microsoft.AspNetCore.Mvc;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Album;

namespace MusicApp.Areas.Admin.Controllers
{
    public class AlbumController : BaseController
    {
        private readonly IAlbumService albumService;
        private readonly ICommentService commentService;

        public AlbumController(IAlbumService _albumService,
                               ICommentService _commentService)
        {
            albumService = _albumService;
            commentService = _commentService;
        }

        public async Task<IActionResult> All([FromQuery] AdminAreaAllAlbumsModel query)
        {
            var result = await albumService.AdminGetAllAlbums(query.Genre, query.SearchTerm, query.Sorting, query.State);

            query.TotalAlbumsCount = result.TotalAlbumsCount;
            query.Genres = await albumService.GetGenres();
            query.Albums = result.Albums;

            return View(query);
        }

        public async Task<IActionResult> Details(int albumId, bool isActive)
        {
            var model = await albumService.AdminGetAlbumDetails(albumId, isActive);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await albumService.AdminGetAlbumDetailsToEdit(id);
            model.Genres = await albumService.GetGenreModels();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddAlbumModel model)
        {
            if (ModelState.IsValid == false)
            {
                model.Genres = await albumService.GetGenreModels();
                return View(model);
            }

            var userId = User.Id();
            var albumId = model.Id;

            await albumService.Edit(albumId, userId, model);

            return RedirectToAction(nameof(Details), new { area = "Admin", albumId, isActive = model.IsActive });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.Id();
            await albumService.Delete(id, userId);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Restore(int id)
        {
            var userId = User.Id();
            await albumService.Restore(id, userId);
            return RedirectToAction(nameof(All));
        }
    }
}

