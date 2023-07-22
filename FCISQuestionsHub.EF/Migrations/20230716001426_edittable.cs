using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FcisArchiveBlazor.Data.Migrations
{
    /// <inheritdoc />
    public partial class edittable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestionAnswer_answerId",
                table: "StudentQuestionAnswer",
                column: "answerId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestionAnswer_answers_answerId",
                table: "StudentQuestionAnswer",
                column: "answerId",
                principalTable: "answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestionAnswer_answers_answerId",
                table: "StudentQuestionAnswer");

            migrationBuilder.DropIndex(
                name: "IX_StudentQuestionAnswer_answerId",
                table: "StudentQuestionAnswer");
        }
    }
}
