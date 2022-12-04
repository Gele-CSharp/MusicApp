using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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
    }
}
