using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCISQuestionsHub.EF.Migrations
{
    /// <inheritdoc />
    public partial class editQuestionOndeleteAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentQuestionAnswer_Users_studentsId",
                table: "studentQuestionAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_studentQuestionAnswer_questions_questionId",
                table: "studentQuestionAnswer");

            migrationBuilder.AddForeignKey(
                name: "FK_studentQuestionAnswer_Users_studentsId",
                table: "studentQuestionAnswer",
                column: "studentsId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_studentQuestionAnswer_questions_questionId",
                table: "studentQuestionAnswer",
                column: "questionId",
                principalTable: "questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentQuestionAnswer_Users_studentsId",
                table: "studentQuestionAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_studentQuestionAnswer_questions_questionId",
                table: "studentQuestionAnswer");

            migrationBuilder.AddForeignKey(
                name: "FK_studentQuestionAnswer_Users_studentsId",
                table: "studentQuestionAnswer",
                column: "studentsId",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_studentQuestionAnswer_questions_questionId",
                table: "studentQuestionAnswer",
                column: "questionId",
                principalTable: "questions",
                principalColumn: "Id");
        }
    }
}
