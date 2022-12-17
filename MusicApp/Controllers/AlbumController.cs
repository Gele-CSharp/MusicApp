using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MusicApp.Core.Constants;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Album;
using MusicApp.Core.Models.Comments;
using MusicApp.Extensions;
using static MusicApp.Infrastructure.Data.DataConstants.Album;

namespace MusicApp.Controllers
{
    public class AlbumController : BaseController
    {
        private readonly ILogger<HomeController> logger;
        private readonly IAlbumService albumService;
        private readonly ICommentService commentService;
        private readonly IMemoryCache cache;

        public AlbumController(ILogger<HomeController> _logger,
                               IAlbumService _albumService,
                               ICommentService _commentService,
                               IMemoryCache _cache)
        {
            logger = _logger;
            albumService = _albumService;
            commentService = _commentService;
            cache = _cache;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllAlbumsModel query)
        {
            var result = await albumService.GetAllAlbums(query.Genre, query.SearchTerm, query.Sorting, query.CurrentPage, AllAlbumsModel.AlbumsPerPage);

            query.TotalAlbumsCount = result.TotalAlbumsCount;
            query.Genres = await albumService.GetGenres();
            query.Albums = result.Albums.ToList();
            
            return View(query);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int albumId, string information)
        {
            var model = await albumService.GetAlbumDetails(albumId);

            if (information != model.GetInformation())
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Comment(CommentModel model, int albumId)
        {
            var userId = User.Id();

            if (model.Comment != null)
            {
                await commentService.AddComment(albumId, userId, model.Comment);
                TempData[MessageConstant.SuccessMessage] = "You added a comment successfully.";
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
            TempData[MessageConstant.SuccessMessage] = "You added an album successfully.";

            return RedirectToAction(nameof(Details), new {albumId, information = model.GetInformation()});
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            var model = cache.Get<IEnumerable<AlbumModel>>(AlbumsCacheKey);

            if (model == null)
            {
                model = await albumService.GetAllUserAlbums(userId);
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                cache.Set(AlbumsCacheKey, model, cacheOptions);
            }

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
            TempData[MessageConstant.SuccessMessage] = "You edited an album successfully.";
            cache.Remove(AlbumsCacheKey);

            return RedirectToAction(nameof(Details), new { albumId, information = model.GetInformation() });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.Id();
            await albumService.Delete(id, userId);
            TempData[MessageConstant.SuccessMessage] = "You deleted an album successfully.";
            cache.Remove(AlbumsCacheKey);
            return RedirectToAction(nameof(All));
        }
    }
}
