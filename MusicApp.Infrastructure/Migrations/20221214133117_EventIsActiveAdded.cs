using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Infrastructure.Migrations
{
    public partial class EventIsActiveAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42c8f95a-e61d-445a-bb23-67b2fd181c89",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76f30d33-3557-405d-b756-7535e530c40e", "AQAAAAEAACcQAAAAEIdy5VOr1oE93Yp8A1eNOzsbEx1VZ8duuS12sTOhwTE95FfCd9r9vIBSSBKbEr6W7g==", "c4409973-f048-4593-8d7b-0c1b5f9ac5fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43a3b5b6-a7e5-4949-a539-d7029f18f747",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c59e5591-fc6d-43ac-a192-2caf15f7161b", "AQAAAAEAACcQAAAAEBgilo7pTRAw7PCh/9hg7A/Fm20p1KuYknchzJOeCHISzbtlBXNeN8/plABQyWZ4VA==", "f4efbf0f-b9e3-4d30-a493-daab1181d5ca" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Events");

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
    }
}
