using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Data.Migrations
{
    public partial class AddedDescriptionToAlbumEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Artist", "Title" },
                values: new object[] { "Bob Dylan", "Blood on the Tracks" });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Artist", "Title" },
                values: new object[] { "Lauryn Hill", "The Miseducation of Lauryn Hill" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42c8f95a-e61d-445a-bb23-67b2fd181c87");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43a3b5b6-a7e5-4949-a539-d7029f18f746");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Albums");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Artist", "Title" },
                values: new object[] { "Blood on the Tracks", "Bob Dylan" });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Artist", "Title" },
                values: new object[] { "The Miseducation of Lauryn Hill", "Lauryn Hill" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "42c8f95a-e61d-445a-bb23-67b2fd181c87", 0, "ed6c5ae5-2326-45ef-9266-061de7ae2f04", "User", "user@mail.com", false, "Pesho", "Petrov", false, null, "USER@MAIL.COM", "USER@MAIL.COM", "AQAAAAEAACcQAAAAECa1t55o2pnYluEm7icWTlh6nytSqaEGuc2SRphXEy//vvTbKFfeyYlT4br2Xg1b2A==", null, false, "ca5ff1c3-e8c4-485f-81b6-3e214dec598d", false, "user@mail.com" },
                    { "43a3b5b6-a7e5-4949-a539-d7029f18f746", 0, "1b8c9668-4111-4d49-a1f4-7e4b9785ed5f", "User", "admin@mail.com", false, "Ivan", "Ivanov", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEDvQ34kzfv3fxwdMl4APJ0Gy15TBmGp/VM9mR0aiNZFdGlwFyTnfrLcgYI1+Y/gLPA==", null, false, "fa0f6f4f-7efe-4315-877c-e721dfe366e1", false, "admin@mail.com" }
                });
        }
    }
}
