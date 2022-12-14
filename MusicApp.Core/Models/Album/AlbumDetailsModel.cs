using MusicApp.Core.Models.Comments;
using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Core.Models.Album
{
    public class AlbumDetailsModel
    {
        /// <summary>
        /// Album identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Album title
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Performer
        /// </summary>
        public string Artist { get; set; } = null!;

        /// <summary>
        /// Album information
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Album cover image
        /// </summary>
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// Genre identifier
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        /// Music genre
        /// </summary>
        public Genre Genre { get; set; } = null!;

        /// <summary>
        /// Album release year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Comments about current album
        /// </summary>
        public CommentModel? Comments { get; set; }

        /// <summary>
        /// Number of likes for current album 
        /// </summary>
        public int Likes { get; set; } = 0;

        /// <summary>
        /// Identifier of user added the album
        /// </summary>
        public string UserId { get; set; } = null!;

        /// <summary>
        /// User added current album
        /// </summary>
        public virtual User User { get; set; } = null!;

        /// <summary>
        /// Determines if album to be displayed
        /// </summary>
        public bool IsActive { get; set; }
    }
}
