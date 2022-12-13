using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Infrastructure.Migrations
{
    public partial class CommentAndEventPropertiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42c8f95a-e61d-445a-bb23-67b2fd181c89",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0ef4807-eaf6-4a41-b51d-602e93afeabd", "AQAAAAEAACcQAAAAEHcWMwWLdXmlMol+4uF6fP/7ecat/W6JMN4WvIYI81L7HHCTMlq41AM0ICQfQKKlYA==", "64067aa4-0c1b-468a-b482-9e2ae04ea9dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43a3b5b6-a7e5-4949-a539-d7029f18f747",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a297c71-3383-4ea8-bc59-22906ccfa96f", "AQAAAAEAACcQAAAAEHuNbW2DiiwyfgqmL+6Y52E/ZC9OO1HjCpSwDsyhBklDp5DiCRj7rjXcLgp7D9c+cg==", "ca82a565-493c-4b02-8032-e8518372915f" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "ImageUrl" },
                values: new object[] { new DateTime(2022, 12, 4, 20, 0, 0, 0, DateTimeKind.Unspecified), "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.eventim.bg%2Fbg%2Fartist%2Flili-ivanova-2%2Fprofile.html&psig=AOvVaw3IDtRNU1-18kn24xJVnSN8&ust=1671022386647000&source=images&cd=vfe&ved=2ahUKEwj53bTP0fb7AhWRYPEDHUnCBqAQjRx6BAgAEAo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42c8f95a-e61d-445a-bb23-67b2fd181c89",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2fabc68-73d2-40f6-9af6-867280cf2bc7", "AQAAAAEAACcQAAAAEGgAyA+RebmpttslJ/QINOhx3pF/MeEWlfhWlRxwIy+Rak/60mgEhtRaCsXbj1EFsA==", "fe2b0d90-61c0-4a0c-afaf-2836c1a270d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43a3b5b6-a7e5-4949-a539-d7029f18f747",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fbffaf5-3856-419e-bcce-97e374168f23", "AQAAAAEAACcQAAAAEOc5JtiDH2TelaM8T/qCzVNeHYU3DOcDVErVKPv/vujPTv57g3QBSG9P+2BS63h5mg==", "c309e6e6-70f6-4c53-83d8-4cb4f748827e" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
