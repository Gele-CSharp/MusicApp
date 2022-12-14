using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MusicApp.Infrastructure.Data.DataConstants.Comment;

namespace MusicApp.Infrastructure.Data.Entities
{
    /// <summary>
    /// Comment model
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Comment identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Comment author identifier 
        /// </summary>
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        /// <summary>
        /// Author of current comment
        /// </summary>
        public User User { get; set; } = null!;

        /// <summary>
        /// Album identifier 
        /// </summary>
        [Required]
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }

        /// <summary>
        /// Music album 
        /// </summary>
        public virtual Album Album { get; set; } = null!;

        /// <summary>
        /// Comment content
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        /// <summary>
        /// Determines if comment to be displayed
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
