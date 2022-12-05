using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MusicApp.Infrastructure.Data.Entities.Configuration
{
    internal class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasData(SeedAlbums());
        }

        private List<Album> SeedAlbums()
        {
            var albums = new List<Album>();

            var album = new Album()
            {
                Id = 1,
                Title = "What’s Going On",
                Artist = "Marvin Gaye",
                ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-001-Marvin-Gaye-WHATS-GOING-ON.jpg?w=1000",
                GenreId = 4,
                Year = 1971,
                UserId = "42c8f95a-e61d-445a-bb23-67b2fd181c87",
            };

            albums.Add(album);

            album = new Album()
            {
                Id = 2,
                Title = "Pet Sounds",
                Artist = "The Beach Boys",
                ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-002-Beach-Boys-PET-SOUNDS-update.jpg?w=1000",
                GenreId = 3,
                Year = 1966,
                UserId = "42c8f95a-e61d-445a-bb23-67b2fd181c87",
            };

            albums.Add(album);

            album = new Album()
            {
                Id = 3,
                Title = "Blue",
                Artist = "Joni Mitchell",
                ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-003-JoniMitchell-BLUE-HR.jpg?w=1000",
                GenreId = 1,
                Year = 1971,
                UserId = "42c8f95a-e61d-445a-bb23-67b2fd181c87",
            };

            albums.Add(album);

            album = new Album()
            {
                Id = 4,
                Title = "Songs in the Key of Life",
                Artist = "Stevie Wonder",
                ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-004-Stevie-Wonder-SONGS-IN-THE-KEY-OF-LIFE.jpg?w=1000",
                GenreId = 4,
                Year = 1976,
                UserId = "42c8f95a-e61d-445a-bb23-67b2fd181c87",
            };

            albums.Add(album);

            album = new Album()
            {
                Id = 5,
                Title = "Abbey Road",
                Artist = "The Beatles",
                ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-005-Beatles-ABBEY-ROAD.jpg?w=1000",
                GenreId = 4,
                Year = 1969,
                UserId = "42c8f95a-e61d-445a-bb23-67b2fd181c87",
            };

            albums.Add(album);

            album = new Album()
            {
                Id = 6,
                Title = "Nevermind",
                Artist = "Nirvana",
                ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-006-Nirvana-NEVERMIND-HR.jpg?w=1000",
                GenreId = 3,
                Year = 1991,
                UserId = "42c8f95a-e61d-445a-bb23-67b2fd181c87",
            };

            albums.Add(album);

            album = new Album()
            {
                Id = 7,
                Title = "Rumours",
                Artist = "Fleetwood Mac",
                ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-007-Fleetwood-Mac-RUMOURS.jpg?w=1000",
                GenreId = 3,
                Year = 1977,
                UserId = "42c8f95a-e61d-445a-bb23-67b2fd181c87",
            };

            albums.Add(album);

            album = new Album()
            {
                Id = 8,
                Title = "Purple Rain",
                Artist = "Prince and the Revolution",
                ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-008-Prince-PURPLE-RAIN.jpg?w=1000",
                GenreId = 1,
                Year = 1984,
                UserId = "43a3b5b6-a7e5-4949-a539-d7029f18f746",
            };

            albums.Add(album);

            album = new Album()
            {
                Id = 9,
                Title = "Blood on the Tracks",
                Artist = "Bob Dylan",
                ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-009-Bob-Dylan-BLOOD-ON-THE-TRACKS.jpg?w=1000",
                GenreId = 3,
                Year = 1975,
                UserId = "43a3b5b6-a7e5-4949-a539-d7029f18f746",
            };

            albums.Add(album);

            album = new Album()
            {
                Id = 10,
                Title = "The Miseducation of Lauryn Hill",
                Artist = "Lauryn Hill",
                ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-010-Lauryn-Hill-MISEDUCATION.jpg?w=1000",
                GenreId = 4,
                Year = 1998,
                UserId = "43a3b5b6-a7e5-4949-a539-d7029f18f746",
            };

            albums.Add(album);

            return albums;
        }
    }
}
