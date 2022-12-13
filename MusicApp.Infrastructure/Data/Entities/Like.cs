using System.ComponentModel.DataAnnotations;

namespace MusicApp.Infrastructure.Data.Entities
{
    /// <summary>
    /// Like model
    /// </summary>
    public class Like
    {
        /// <summary>
        /// Like identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Liked album identifier
        /// </summary>
        public int AlbumId { get; set; }
    }
}
