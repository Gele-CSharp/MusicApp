namespace MusicApp.Core.Models.Album
{
    /// <summary>
    /// Homepage album model
    /// </summary>
    public class HomepageAlbumModel : IAlbumModel
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
        /// Album cover image url
        /// </summary>
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// Performer
        /// </summary>
        public string Artist { get; init; } = null!;
    }
}
