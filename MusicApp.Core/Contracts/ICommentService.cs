using MusicApp.Core.Models.Comments;
using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Core.Contracts
{
    public interface ICommentService
    {
        Task<ICollection<Comment>> GetComments(int albumId);

        Task AddComment(int albumId, string userId, Comment comment);

        Task<Comment> GetComment(int albumId, int commentId);

        Task<EditCommentModel> GetCommentToEdit(int albumId, int commentId);

        Task Edit(EditCommentModel model);

        Task Delete(int albumId, int commentId);
    }
}
