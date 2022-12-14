using System.ComponentModel.DataAnnotations;
using static MusicApp.Infrastructure.Data.DataConstants.Event;

namespace MusicApp.Core.Models.Event
{
    public class EventModel
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
        /// Event image url
        /// </summary>
        [Required]
        public string ImageUrl { get; set; } = null!;

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

        /// <summary>
        /// Determines if event to be displayed
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
