using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Data.Migrations
{
    public partial class DatabaseSetUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artist = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Albums_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "42c8f95a-e61d-445a-bb23-67b2fd181c87", 0, "ed6c5ae5-2326-45ef-9266-061de7ae2f04", "User", "user@mail.com", false, "Pesho", "Petrov", false, null, "USER@MAIL.COM", "USER@MAIL.COM", "AQAAAAEAACcQAAAAECa1t55o2pnYluEm7icWTlh6nytSqaEGuc2SRphXEy//vvTbKFfeyYlT4br2Xg1b2A==", null, false, "ca5ff1c3-e8c4-485f-81b6-3e214dec598d", false, "user@mail.com" },
                    { "43a3b5b6-a7e5-4949-a539-d7029f18f746", 0, "1b8c9668-4111-4d49-a1f4-7e4b9785ed5f", "User", "admin@mail.com", false, "Ivan", "Ivanov", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEDvQ34kzfv3fxwdMl4APJ0Gy15TBmGp/VM9mR0aiNZFdGlwFyTnfrLcgYI1+Y/gLPA==", null, false, "fa0f6f4f-7efe-4315-877c-e721dfe366e1", false, "admin@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Artist", "Date", "Location" },
                values: new object[] { 1, "Лили Иванова", new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Зала Армеец" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pop" },
                    { 2, "Hip hop" },
                    { 3, "Rock" },
                    { 4, "Soul" },
                    { 5, "Reggae" },
                    { 6, "Jazz" },
                    { 7, "Funk" },
                    { 8, "Country" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Artist", "GenreId", "ImageUrl", "IsActive", "Likes", "Title", "UserId", "Year" },
                values: new object[,]
                {
                    { 1, "Marvin Gaye", 4, "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-001-Marvin-Gaye-WHATS-GOING-ON.jpg?w=1000", true, 0, "What’s Going On", "42c8f95a-e61d-445a-bb23-67b2fd181c87", 1971 },
                    { 2, "The Beach Boys", 3, "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-002-Beach-Boys-PET-SOUNDS-update.jpg?w=1000", true, 0, "Pet Sounds", "42c8f95a-e61d-445a-bb23-67b2fd181c87", 1966 },
                    { 3, "Joni Mitchell", 1, "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-003-JoniMitchell-BLUE-HR.jpg?w=1000", true, 0, "Blue", "42c8f95a-e61d-445a-bb23-67b2fd181c87", 1971 },
                    { 4, "Stevie Wonder", 4, "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-004-Stevie-Wonder-SONGS-IN-THE-KEY-OF-LIFE.jpg?w=1000", true, 0, "Songs in the Key of Life", "42c8f95a-e61d-445a-bb23-67b2fd181c87", 1976 },
                    { 5, "The Beatles", 4, "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-005-Beatles-ABBEY-ROAD.jpg?w=1000", true, 0, "Abbey Road", "42c8f95a-e61d-445a-bb23-67b2fd181c87", 1969 },
                    { 6, "Nirvana", 3, "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-006-Nirvana-NEVERMIND-HR.jpg?w=1000", true, 0, "Nevermind", "42c8f95a-e61d-445a-bb23-67b2fd181c87", 1991 },
                    { 7, "Fleetwood Mac", 3, "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-007-Fleetwood-Mac-RUMOURS.jpg?w=1000", true, 0, "Rumours", "42c8f95a-e61d-445a-bb23-67b2fd181c87", 1977 },
                    { 8, "Prince and the Revolution", 1, "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-008-Prince-PURPLE-RAIN.jpg?w=1000", true, 0, "Purple Rain", "43a3b5b6-a7e5-4949-a539-d7029f18f746", 1984 },
                    { 9, "Blood on the Tracks", 3, "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-009-Bob-Dylan-BLOOD-ON-THE-TRACKS.jpg?w=1000", true, 0, "Bob Dylan", "43a3b5b6-a7e5-4949-a539-d7029f18f746", 1975 },
                    { 10, "The Miseducation of Lauryn Hill", 4, "https://www.rollingstone.com/wp-content/uploads/2020/09/R1344-010-Lauryn-Hill-MISEDUCATION.jpg?w=1000", true, 0, "Lauryn Hill", "43a3b5b6-a7e5-4949-a539-d7029f18f746", 1998 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_GenreId",
                table: "Albums",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_UserId",
                table: "Albums",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AlbumId",
                table: "Comments",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42c8f95a-e61d-445a-bb23-67b2fd181c87");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43a3b5b6-a7e5-4949-a539-d7029f18f746");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
