namespace MusicApp.Infrastructure.Data.Entities
{
    /// <summary>
    /// Musical genre model
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Genre identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Genre name
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Collection of albums with current genre
        /// </summary>
        public virtual IEnumerable<Album> Albums { get; set; } = new HashSet<Album>();
    }
}
