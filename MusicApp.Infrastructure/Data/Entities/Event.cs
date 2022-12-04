using System.ComponentModel.DataAnnotations;
using static MusicApp.Infrastructure.Data.DataConstants.Event;

namespace MusicApp.Infrastructure.Data.Entities
{
    /// <summary>
    /// Event model
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Event identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Artist to perform at the event
        /// </summary>
        [Required]
        [StringLength(ArtistNameMaxLength)]
        public string Artist { get; set; } = null!;

        /// <summary>
        /// Event location
        /// </summary>
        [Required]
        [StringLength(LocationNameMaxLength)]
        public string Location { get; set; } = null!;

        /// <summary>
        /// Event date
        /// </summary>
        public DateTime Date { get; set; }
    }
}
