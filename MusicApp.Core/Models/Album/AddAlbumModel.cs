using System.ComponentModel.DataAnnotations;
using static MusicApp.Infrastructure.Data.DataConstants.Album;

namespace MusicApp.Core.Models.Album
{
    /// <summary>
    /// Add album model
    /// </summary>
    public class AddAlbumModel
    {
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
    }
}
