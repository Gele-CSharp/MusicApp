using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Core.Models.Comments
{
    public class EditCommentModel
    {
        public int Id { get; set; }

        public int AlbumId { get; set; }

        public string Content { get; set; } = null!;

        public User User { get; set; } = null!;  
    }
}
