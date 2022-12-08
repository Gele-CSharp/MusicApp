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
        /// Album title
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Album Performer 
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

        /// <summary>
        /// Release year
        /// </summary>
        public int Year { get; set; }
    }
}
