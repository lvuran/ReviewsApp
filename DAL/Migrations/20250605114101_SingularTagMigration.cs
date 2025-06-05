using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SingularTagMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewTag");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_TagId",
                table: "reviews",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_tags_TagId",
                table: "reviews",
                column: "TagId",
                principalTable: "tags",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_tags_TagId",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_TagId",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "reviews");

            migrationBuilder.CreateTable(
                name: "ReviewTag",
                columns: table => new
                {
                    ReviewsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewTag", x => new { x.ReviewsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ReviewTag_reviews_ReviewsId",
                        column: x => x.ReviewsId,
                        principalTable: "reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewTag_tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTag_TagsId",
                table: "ReviewTag",
                column: "TagsId");
        }
    }
}
