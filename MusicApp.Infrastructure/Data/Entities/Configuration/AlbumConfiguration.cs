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
                Description = "Marvin Gaye’s masterpiece began as a reaction to police brutality. In May 1969, Renaldo “Obie” Benson, the Four Tops’ bass singer, watched TV coverage of hundreds of club-wielding cops breaking up the People’s Park, a protest hub in Berkeley. Aghast at the violence, Benson began to write a song with Motown lyricist Al Cleveland, trying to capture the confusion and pain of the times.",
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
                Description = "“Who’s gonna hear this shit?” Beach Boys singer Mike Love asked the band’s resident genius, Brian Wilson, in 1966, as Wilson played him the new songs he was working on. “The ears of a dog?” Confronted with his bandmate’s contempt, Wilson made lemonade of lemons. “Ironically,” he observed, “Mike’s barb inspired the album’s title.”",
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
                Description = "In 1971, Joni Mitchell represented the West Coast feminine ideal — celebrated by Robert Plant as “a girl out there with love in her eyes and flowers in her hair” on Led Zeppelin’s “Goin’ to California.” It was a status that Mitchell hadn’t asked for and did not want: “I went, ‘Oh, my God, a lot of people are listening to me,’” she recalled in 2013. “’They better find out who they’re worshiping. Let’s see if they can take it. Let’s get real.’ So I wrote Blue.”",
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
                Description = "Months before the recording sessions for Songs in the Key of Life ended, the musicians in Stevie Wonder’s band had T-shirts made up that proclaimed, “We’re almost finished.” It was the stock answer to casual fans and Motown executives and everybody who’d fallen in love with Wonder’s early-Seventies gems – 1972’s Talking Book, 1973’s Innervisions, and 1974’s Fulfillingness’ First Finale – and who had been waiting two years for the next chapter.",
                UserId = "42c8f95a-e61d-445a-bb23-67b2fd181c87"
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
                Description = "“It was a very happy record,” said producer George Martin, describing this album in The Beatles Anthology. “I guess it was happy because everybody thought it was going to be the last.” Indeed, Abbey Road — recorded in two months during the summer of 1969 — almost never got made at all. That January, the Beatles were on the verge of a breakup, exhausted and angry with one another after the disastrous sessions for the aborted Get Back LP, later salvaged as Let It Be [see No. 342].",
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
                Description = "An overnight-success story of the 1990s, Nirvana’s second album and its totemic ﬁrst single, “Smells Like Teen Spirit,” shot up from the Northwest underground — the nascent grunge scene in Seattle — to kick Michael Jackson’s Dangerous off the top of the Billboard charts and blow hair metal off the map. Few albums have had such an overpowering impact on a generation — a nation of teens suddenly turned punk — and such a catastrophic effect on its main creator. ",
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
                Description = "With Rumours, Fleetwood Mac turned private turmoil into gleaming, melodic public art. The band’s two couples — bassist John McVie and singer-keyboard player Christine McVie, who were married; guitarist Lindsey Buckingham and vocalist Stevie Nicks, who were not — broke up during the protracted sessions for the album.",
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
                Description = "“I think Purple Rain is the most avant-garde, ‘purple’ thing I’ve ever done,” Prince told Ebony in 1986. He was still a rising star with only a couple of hits when he got the audacious idea to make a movie based on his life, and make his next LP the movie’s soundtrack. When it was released in 1984, he became the first artist to have the Number One song, album, and movie in North America. ",
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
                Description = "Bob Dylan once introduced this album’s opening song, “Tangled Up in Blue,” onstage as taking him 10 years to live and two years to write. It was, for him, a pointed reference to the personal crisis — the collapse of his marriage to Sara Lowndes — that at least partly inspired this album, Dylan’s best of the 1970s. ",
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
                Description = "“This is a very sexist industry,” Lauryn Hill told Essence magazine in 1998. “They’ll never throw the ‘genius’ title to a sister.” Though already a star as co-leader of the Fugees, with Wyclef Jean, she was hungry to express her own vision. “I wanted to write songs that lyrically move me and have the integrity of reggae and the knock of hip-hop and the instrumentation of classic soul,” the singer said of her debut album.",
                UserId = "43a3b5b6-a7e5-4949-a539-d7029f18f746",
            };

            albums.Add(album);

            return albums;
        }
    }
}
