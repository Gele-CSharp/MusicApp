using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MusicApp.Infrastructure.Data.DataConstants.Album;

namespace MusicApp.Infrastructure.Data.Entities
{
    /// <summary>
    /// Music album model
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Album identifier
        /// </summary>
        [Key]
        public int Id { get; init; }

        /// <summary>
        /// Album title
        /// </summary>
        [Required]
        [StringLength(AlbumTitleMaxLength)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Music performer
        /// </summary>
        [Required]
        [StringLength(ArtistNameMaxLength)]
        public string Artist { get; set; } = null!;

        /// <summary>
        /// Album cover image
        /// </summary>
        [Required]
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// Genre identifier
        /// </summary>
        [Required]
        public int GenreId { get; set; }

        /// <summary>
        /// Music genre
        /// </summary>
        [Required]
        public Genre Genre { get; set; } = null!;

        /// <summary>
        /// Album release year
        /// </summary>
        [Required]
        public int Year { get; set; }

        /// <summary>
        /// Comments about current album
        /// </summary>
        public virtual IEnumerable<Comment> Comments { get; set; } = new HashSet<Comment>();

        /// <summary>
        /// Number of likes for current album 
        /// </summary>
        public int Likes { get; set; } = 0;

        /// <summary>
        /// Identifier of user added the album
        /// </summary>
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        /// <summary>
        /// User added current album
        /// </summary>
        public virtual User User { get; set; } = null!;

        /// <summary>
        /// Determines if album to be displayed
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
