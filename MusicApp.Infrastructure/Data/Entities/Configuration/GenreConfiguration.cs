using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MusicApp.Infrastructure.Data.Entities.Configuration
{
    internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(SeedGenres());
        }

        private List<Genre> SeedGenres()
        {
            var genres = new List<Genre>();

            var genre = new Genre()
            {
                Id = 1,
                Name = "Pop"
            };

            genres.Add(genre);

            genre = new Genre()
            {
                Id = 2,
                Name = "Hip hop"
            };

            genres.Add(genre);

            genre = new Genre()
            {
                Id = 3,
                Name = "Rock"
            };

            genres.Add(genre);

            genre = new Genre()
            {
                Id = 4,
                Name = "Soul"
            };

            genres.Add(genre);

            genre = new Genre()
            {
                Id = 5,
                Name = "Reggae"
            };

            genres.Add(genre);

            genre = new Genre()
            {
                Id = 6,
                Name = "Jazz"
            };

            genres.Add(genre);

            genre = new Genre()
            {
                Id = 7,
                Name = "Funk"
            };

            genres.Add(genre);

            genre = new Genre()
            {
                Id = 8,
                Name = "Country"
            };

            genres.Add(genre);

            return genres;
        }
    }
}
