using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Data.Migrations
{
    public partial class AlbumDescriptionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Albums",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Marvin Gaye’s masterpiece began as a reaction to police brutality. In May 1969, Renaldo “Obie” Benson, the Four Tops’ bass singer, watched TV coverage of hundreds of club-wielding cops breaking up the People’s Park, a protest hub in Berkeley. Aghast at the violence, Benson began to write a song with Motown lyricist Al Cleveland, trying to capture the confusion and pain of the times.");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "“Who’s gonna hear this shit?” Beach Boys singer Mike Love asked the band’s resident genius, Brian Wilson, in 1966, as Wilson played him the new songs he was working on. “The ears of a dog?” Confronted with his bandmate’s contempt, Wilson made lemonade of lemons. “Ironically,” he observed, “Mike’s barb inspired the album’s title.”");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "In 1971, Joni Mitchell represented the West Coast feminine ideal — celebrated by Robert Plant as “a girl out there with love in her eyes and flowers in her hair” on Led Zeppelin’s “Goin’ to California.” It was a status that Mitchell hadn’t asked for and did not want: “I went, ‘Oh, my God, a lot of people are listening to me,’” she recalled in 2013. “’They better find out who they’re worshiping. Let’s see if they can take it. Let’s get real.’ So I wrote Blue.”");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Months before the recording sessions for Songs in the Key of Life ended, the musicians in Stevie Wonder’s band had T-shirts made up that proclaimed, “We’re almost finished.” It was the stock answer to casual fans and Motown executives and everybody who’d fallen in love with Wonder’s early-Seventies gems – 1972’s Talking Book, 1973’s Innervisions, and 1974’s Fulfillingness’ First Finale – and who had been waiting two years for the next chapter.");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "“It was a very happy record,” said producer George Martin, describing this album in The Beatles Anthology. “I guess it was happy because everybody thought it was going to be the last.” Indeed, Abbey Road — recorded in two months during the summer of 1969 — almost never got made at all. That January, the Beatles were on the verge of a breakup, exhausted and angry with one another after the disastrous sessions for the aborted Get Back LP, later salvaged as Let It Be [see No. 342].");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "An overnight-success story of the 1990s, Nirvana’s second album and its totemic ﬁrst single, “Smells Like Teen Spirit,” shot up from the Northwest underground — the nascent grunge scene in Seattle — to kick Michael Jackson’s Dangerous off the top of the Billboard charts and blow hair metal off the map. Few albums have had such an overpowering impact on a generation — a nation of teens suddenly turned punk — and such a catastrophic effect on its main creator. ");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "With Rumours, Fleetwood Mac turned private turmoil into gleaming, melodic public art. The band’s two couples — bassist John McVie and singer-keyboard player Christine McVie, who were married; guitarist Lindsey Buckingham and vocalist Stevie Nicks, who were not — broke up during the protracted sessions for the album.");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "“I think Purple Rain is the most avant-garde, ‘purple’ thing I’ve ever done,” Prince told Ebony in 1986. He was still a rising star with only a couple of hits when he got the audacious idea to make a movie based on his life, and make his next LP the movie’s soundtrack. When it was released in 1984, he became the first artist to have the Number One song, album, and movie in North America. ");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "Bob Dylan once introduced this album’s opening song, “Tangled Up in Blue,” onstage as taking him 10 years to live and two years to write. It was, for him, a pointed reference to the personal crisis — the collapse of his marriage to Sara Lowndes — that at least partly inspired this album, Dylan’s best of the 1970s. ");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "“This is a very sexist industry,” Lauryn Hill told Essence magazine in 1998. “They’ll never throw the ‘genius’ title to a sister.” Though already a star as co-leader of the Fugees, with Wyclef Jean, she was hungry to express her own vision. “I wanted to write songs that lyrically move me and have the integrity of reggae and the knock of hip-hop and the instrumentation of classic soul,” the singer said of her debut album.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42c8f95a-e61d-445a-bb23-67b2fd181c87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4ca8f30-c5eb-47e7-aa86-d637438e1046", "AQAAAAEAACcQAAAAEPSGz9z68px+821q8ovSW9rINtNOx8SMXYj2dwOisPeKeQv2YviuO4K7Eiw3fMc0DQ==", "142ff0b1-0364-4fd5-bf65-ff8f9e87dac9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43a3b5b6-a7e5-4949-a539-d7029f18f746",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46507844-25ff-47d8-943c-201060913cb4", "AQAAAAEAACcQAAAAEOPVwXA9SU8jrNHWTKqSJXKdYKr9i+zJDQlUtjk0fhy3ut8zUxlgOCpNPVd1Fkjf5g==", "edcc6e2c-ae15-47a3-aae7-cc11e194d083" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42c8f95a-e61d-445a-bb23-67b2fd181c87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea112923-aba0-4df6-a681-c502310c4d04", "AQAAAAEAACcQAAAAEJcRxbbN/MyBGp9tXyKZPv14gJkszVT2UzLMUMWernsfnkgK2FfWMHzKEiUEXnbWxg==", "474373cf-7642-4684-b214-e1ab0f5ed2ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43a3b5b6-a7e5-4949-a539-d7029f18f746",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea7c6890-25eb-484d-9dee-b9f0e717590b", "AQAAAAEAACcQAAAAEGLDoooWfTLBDnfNIoN8zhqD6Br3WSCCIqkZ9iF6qBbmWlQHuVmyG7QBRBTCKLqNyA==", "c6793764-4918-445e-9a0e-e25b09f51ca7" });
        }
    }
}
