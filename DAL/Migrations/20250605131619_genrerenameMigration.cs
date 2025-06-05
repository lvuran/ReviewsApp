using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class genrerenameMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Fantasy");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Crime");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Romance");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Childrens");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Historical");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Fantastika");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Krimi");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Ljubavni");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Dječji");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Povijesni");
        }
    }
}
