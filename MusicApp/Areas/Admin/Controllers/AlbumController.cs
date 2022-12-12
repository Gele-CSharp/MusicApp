using Microsoft.AspNetCore.Mvc;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Album;
using MusicApp.Core.Models.Comments;

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

        [HttpPost]
        public async Task<IActionResult> Comment(CommentModel model, int albumId)
        {
            var userId = User.Id();

            if (model.Comment != null)
            {
                await commentService.AddComment(albumId, userId, model.Comment);
            }

            return RedirectToAction(nameof(Details), new { albumId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await albumService.GetAlbumDetailsToEdit(id);
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

            return RedirectToAction(nameof(Details), new { albumId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.Id();
            await albumService.Delete(id, userId);
            return RedirectToAction(nameof(All));
        }
    }
}

