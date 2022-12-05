namespace MusicApp.Core.Models.Album
{
    /// <summary>
    /// Album model interface
    /// </summary>
    public interface IAlbumModel
    {
        /// <summary>
        /// Artist name
        /// </summary>
        public string Artist { get; }

        /// <summary>
        /// Album title
        /// </summary>
        public string Title { get; }
    }
}
