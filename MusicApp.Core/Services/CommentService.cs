using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using MusicApp.Core.Contracts;
using MusicApp.Core.Models.Comments;
using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repository;

        public CommentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ICollection<Comment>> GetComments(int albumId)
        {
            return await repository
                .AllReadonly<Comment>()
                .Where(c => c.IsActive && c.AlbumId == albumId)
                .Include(c => c.User)
                .ToListAsync();
        }

        public async Task AddComment(int albumId, string userId, Comment comment)
        {
            var album = await repository.GetByIdAsync<Album>(albumId);
            comment.UserId = userId;
            comment.AlbumId = albumId;
            album.Comments.Add(comment);
            await repository.SaveChangesAsync();
        }

        public async Task Edit(EditCommentModel model)
        {
            var album = await repository
                .All<Album>()
                .Where(a => a.Id == model.AlbumId)
                .Include(a => a.Comments)
                .FirstAsync();

            var comment = await GetComment(model.AlbumId, model.Id);
            comment.Content = model.Content;

            try
            {
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database failed to save info.", ex);
            }
        }

        public async Task<Comment> GetComment(int albumId, int commentId)
        {
            return await repository
                .All<Comment>()
                .Where(c=> c.IsActive)
                .Include(c=> c.User)
                .Include(c=> c.Album)
                .Where(c=> c.Album.Id == albumId)
                .FirstAsync(c => c.Id == commentId);
        }

        public async Task<EditCommentModel> GetCommentToEdit(int albumId, int commentId)
        {
            var comment = await GetComment(albumId, commentId);

            return new EditCommentModel()
            {
                Id = comment.Id,
                AlbumId = comment.AlbumId,
                User = comment.User,
                Content = comment.Content
            };
        }

        public async Task Delete(int albumId, int commentId)
        {
            var comment = await GetComment(albumId, commentId);
            comment.IsActive = false;

            try
            {
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database failed to save info.", ex);
            }
        }
    }
}
