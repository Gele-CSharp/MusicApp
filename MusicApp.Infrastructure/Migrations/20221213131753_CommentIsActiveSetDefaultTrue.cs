using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Infrastructure.Migrations
{
    public partial class CommentIsActiveSetDefaultTrue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42c8f95a-e61d-445a-bb23-67b2fd181c89",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae367bf7-7155-48b8-bfc5-1b9dad9020fd", "AQAAAAEAACcQAAAAECb+cD0OYN1YMvJ3GVRJ6FBr6vHT5swbeffLF4Mc946gUXS0ZoMw3GAX+r07MpacEg==", "91708607-692d-4bde-a5cc-3af74e7d983b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43a3b5b6-a7e5-4949-a539-d7029f18f747",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e89a7c6-685d-4d7c-9bbe-07a84499bad9", "AQAAAAEAACcQAAAAEKPRC33hJB8o+18I0gtyUUse3ZldG8p9XlAmtBrSxnSy+vTVUfJc4Y9/K+EcFOKHQg==", "86f1a727-46dc-4ffc-a7fe-5dc22e0362b5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
