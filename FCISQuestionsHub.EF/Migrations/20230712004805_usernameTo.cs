using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FcisArchiveBlazor.Data.Migrations
{
    /// <inheritdoc />
    public partial class usernameTo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "StudentQuestionAnswer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "username",
                table: "StudentQuestionAnswer");
        }
    }
}
