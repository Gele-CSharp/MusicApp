using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Core.Models.Album
{
    /// <summary>
    /// Album model
    /// </summary>
    public class AlbumModel : IAlbumModel
    {
        /// <summary>
        /// Album ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Alum title
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Artist 
        /// </summary>
        public string Artist { get; set; } = null!;

        /// <summary>
        /// Album cover image Url
        /// </summary>
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// Music genre
        /// </summary>
        public Genre Genre { get; set; } = null!;
    }
}
