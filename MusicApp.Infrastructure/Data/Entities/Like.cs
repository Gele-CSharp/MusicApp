using System.ComponentModel.DataAnnotations;

namespace MusicApp.Infrastructure.Data.Entities
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        public int AlbumId { get; set; }
    }
}
