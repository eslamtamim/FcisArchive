using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCISQuestionsHub.EF.Migrations
{
    /// <inheritdoc />
    public partial class lecisnotuniuqe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_lectures_Name",
                table: "lectures");

            migrationBuilder.CreateIndex(
                name: "IX_lectures_Name",
                table: "lectures",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_lectures_Name",
                table: "lectures");

            migrationBuilder.CreateIndex(
                name: "IX_lectures_Name",
                table: "lectures",
                column: "Name",
                unique: true);
        }
    }
}
