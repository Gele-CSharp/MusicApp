using System.ComponentModel.DataAnnotations;
using static MusicApp.Infrastructure.Data.DataConstants.Album;

namespace MusicApp.Core.Models.Album
{
    /// <summary>
    /// Add album model
    /// </summary>
    public class AddAlbumModel : IAlbumModel
    {
        /// <summary>
        /// Album identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Album title
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(AlbumTitleMaxLength, MinimumLength = AlbumTitleMinLength)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Album Performer 
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(ArtistNameMaxLength, MinimumLength = ArtistNameMinLength)]
        public string Artist { get; set; } = null!;

        /// <summary>
        /// Album cover image Url
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// Album information
        /// </summary>
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string? Description { get; set; } 

        /// <summary>
        /// Music genre identifier
        /// </summary>
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        /// <summary>
        /// Genre options
        /// </summary>
        public IEnumerable<AlbumGenreModel> Genres { get; set; } = new HashSet<AlbumGenreModel>();

        /// <summary>
        /// Release year
        /// </summary>
        [Required]
        [Range(ReleaseYearMinValue, ReleaseYearMaxValue)]
        public int Year { get; set; }

        /// <summary>
        /// Determines if album to be displayed
        /// </summary>
        public bool IsActive { get; set; }
    }
}
