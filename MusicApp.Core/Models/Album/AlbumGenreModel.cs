namespace MusicApp.Core.Models.Album
{
    /// <summary>
    /// Model for album genre
    /// </summary>
    public class AlbumGenreModel
    {
        /// <summary>
        /// Genre identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Genre name
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
