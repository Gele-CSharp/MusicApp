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
        private readonly ICommentService commentService;

        public AlbumController(ILogger<HomeController> _logger,
                               IAlbumService _albumService,
                               ICommentService commentService)
        {
            logger = _logger;
            albumService = _albumService;
            this.commentService = commentService;
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
                await commentService.AddComment(albumId, userId, model.Comment);
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

        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            var model = await albumService.GetAllUserAlbums(userId);

            return View(model);
        }

        public async Task<IActionResult> Like(int id)
        {
            await albumService.LikeAlbum(id, User.Id());
            return RedirectToAction(nameof(Details), new { albumId = id });
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
