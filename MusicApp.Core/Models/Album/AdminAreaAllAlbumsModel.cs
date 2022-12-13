using MusicApp.Infrastructure.Data.Entities;

namespace MusicApp.Core.Models.Album
{
    /// <summary>
    /// Admin area all albums model
    /// </summary>
    public class AdminAreaAllAlbumsModel
    {
        /// <summary>
        /// Albums per page
        /// </summary>
        public const int AlbumsPerPage = 3;

        /// <summary>
        /// Album genre
        /// </summary>
        public string Genre { get; set; } = null!;

        /// <summary>
        /// Search condition
        /// </summary>
        public string? SearchTerm { get; set; }

        /// <summary>
        /// Sorting condition
        /// </summary>
        public AlbumsSorting Sorting { get; set; }

        /// <summary>
        /// Number of displayed page
        /// </summary>
        public int CurrentPage { get; set; } = 1;

        /// <summary>
        /// Number of albums
        /// </summary>
        public int TotalAlbumsCount { get; set; }

        /// <summary>
        /// Genres collection
        /// </summary>
        public IEnumerable<Genre> Genres { get; set; } = Enumerable.Empty<Genre>();

        /// <summary>
        /// Determines if activ or deleted albums to be displayed
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Albums collection
        /// </summary>
        public IEnumerable<AdminAreaAlbumModel> Albums { get; set; } = Enumerable.Empty<AdminAreaAlbumModel>();
    }
}
