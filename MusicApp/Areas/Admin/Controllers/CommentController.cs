using Microsoft.AspNetCore.Mvc;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Comments;

namespace MusicApp.Areas.Admin.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, int albumId)
        {
            var model = await commentService.GetCommentToEdit(albumId, id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCommentModel model)
        {
            await commentService.Edit(model);

            return RedirectToAction("Details", "Album", new { area = "Admin", albumId = model.AlbumId, isActive = true });
        }

        public async Task<IActionResult> Delete(int id, int albumId)
        {
            await commentService.Delete(albumId, id);
            return RedirectToAction("Details", "Album", new { area = "Admin", albumId, isActive = true });
        }

        [HttpPost]
        public async Task<IActionResult> Comment(CommentModel model, int albumId)
        {
            var userId = User.Id();

            if (model.Comment != null)
            {
                await commentService.AddComment(albumId, userId, model.Comment);
            }

            return RedirectToAction("Details", "Album", new { area = "Admin", albumId, isActive = true });
        }
    }
}
