using MusicApp.Core.Models.Album;
using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Core.Models.Statistics
{
    public class StatisticsAlbumModel : IAlbumModel
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
        /// Music genre
        /// </summary>
        public Genre Genre { get; set; } = null!;

        /// <summary>
        /// Album release year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Number of likes for current album 
        /// </summary>
        public int Likes { get; set; } = 0;
    }
}

