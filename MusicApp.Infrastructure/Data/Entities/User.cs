using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApp.Infrastructure.Data.Entities
{
    /// <summary>
    /// User model
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// User first name
        /// </summary>
        [Required]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// User last name
        /// </summary>
        public string LastName { get; set; } = null!;

        /// <summary>
        /// User collection of albums
        /// </summary>
        public ICollection<Album> Albums { get; set; } = new HashSet<Album>();

        /// <summary>
        /// User liked albums
        /// </summary>
        public ICollection<Like> Likes { get; set; } = new HashSet<Like>();
    }
}
