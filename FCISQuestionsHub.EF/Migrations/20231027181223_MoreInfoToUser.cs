using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCISQuestionsHub.EF.Migrations
{
    /// <inheritdoc />
    public partial class MoreInfoToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademicYear",
                schema: "security",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Department",
                schema: "security",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                schema: "security",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Section",
                schema: "security",
                table: "Users",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicYear",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Department",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Section",
                schema: "security",
                table: "Users");
        }
    }
}
