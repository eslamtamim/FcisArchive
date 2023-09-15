using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCISQuestionsHub.EF.Migrations
{
    /// <inheritdoc />
    public partial class removingQuestiontextIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_subjects_SubjectId",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_studentQuestionAnswer_Users_studentsId",
                table: "studentQuestionAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_studentQuestionAnswer_questions_questionId",
                table: "studentQuestionAnswer");

            migrationBuilder.DropIndex(
                name: "IX_questions_SubjectId",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_Text_SubjectId_LectureId",
                table: "questions");

            migrationBuilder.CreateIndex(
                name: "IX_questions_SubjectId_LectureId",
                table: "questions",
                columns: new[] { "SubjectId", "LectureId" });

            migrationBuilder.AddForeignKey(
                name: "FK_questions_subjects_SubjectId",
                table: "questions",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_subjects_SubjectId",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_studentQuestionAnswer_Users_studentsId",
                table: "studentQuestionAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_studentQuestionAnswer_questions_questionId",
                table: "studentQuestionAnswer");

            migrationBuilder.DropIndex(
                name: "IX_questions_SubjectId_LectureId",
                table: "questions");

            migrationBuilder.CreateIndex(
                name: "IX_questions_SubjectId",
                table: "questions",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_Text_SubjectId_LectureId",
                table: "questions",
                columns: new[] { "Text", "SubjectId", "LectureId" });

            migrationBuilder.AddForeignKey(
                name: "FK_questions_subjects_SubjectId",
                table: "questions",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
