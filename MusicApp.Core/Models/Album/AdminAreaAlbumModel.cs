namespace MusicApp.Core.Models.Album
{
    /// <summary>
    /// Album model for admin area
    /// </summary>
    public class AdminAreaAlbumModel : AlbumModel
    {
        /// <summary>
        /// Determines if album to be displayed
        /// </summary>
        public bool IsActive { get; set; }
    }
}
