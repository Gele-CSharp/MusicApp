using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Core.Models.Comments
{
    public class CommentModel
    {
        //public string? Content { get; set; }

        public int AlbumId { get; set; }

        public Comment? Comment { get; set; }

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
