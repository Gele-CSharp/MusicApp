namespace MusicApp.Core.Models.Album
{
    /// <summary>
    /// All albums model
    /// </summary>
    public class AllAlbumsModel
    {
        /// <summary>
        /// Albums per page
        /// </summary>
        public int AlbumsPerPage { get; set; } 

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
        public IEnumerable<string> Genres { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// Albums collection
        /// </summary>
        public IEnumerable<AlbumModel> Albums { get; set; } = Enumerable.Empty<AlbumModel>();
    }
}
