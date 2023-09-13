using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FCISQuestionsHub.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddingFilesAndRefactoringQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_questions_Text_Subject",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "questions");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionType",
                table: "questions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Hint",
                table: "questions",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "questions",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LectureId",
                table: "questions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "questions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PdfUploads",
                columns: table => new
                {
                    RequestId = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    TimeUploaded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfUploads", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Semester = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileUploads",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileSize = table.Column<int>(type: "integer", nullable: false),
                    RequestID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUploads", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_FileUploads_PdfUploads_RequestID",
                        column: x => x.RequestID,
                        principalTable: "PdfUploads",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lectures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UploaderId = table.Column<string>(type: "text", nullable: false),
                    SubjectId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lectures_subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileErrors",
                columns: table => new
                {
                    ErrorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ErrorMessage = table.Column<string>(type: "text", nullable: false),
                    ErrorTitle = table.Column<string>(type: "text", nullable: false),
                    ErrorDescription = table.Column<string>(type: "text", nullable: false),
                    FileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileErrors", x => x.ErrorId);
                    table.ForeignKey(
                        name: "FK_FileErrors_FileUploads_FileId",
                        column: x => x.FileId,
                        principalTable: "FileUploads",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_questions_LectureId",
                table: "questions",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_SubjectId",
                table: "questions",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_Text_SubjectId_LectureId",
                table: "questions",
                columns: new[] { "Text", "SubjectId", "LectureId" });

            migrationBuilder.CreateIndex(
                name: "IX_FileErrors_FileId",
                table: "FileErrors",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileUploads_RequestID",
                table: "FileUploads",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_lectures_Name",
                table: "lectures",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lectures_SubjectId",
                table: "lectures",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_Name",
                table: "subjects",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_lectures_LectureId",
                table: "questions",
                column: "LectureId",
                principalTable: "lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_subjects_SubjectId",
                table: "questions",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_lectures_LectureId",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_subjects_SubjectId",
                table: "questions");

            migrationBuilder.DropTable(
                name: "FileErrors");

            migrationBuilder.DropTable(
                name: "lectures");

            migrationBuilder.DropTable(
                name: "FileUploads");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "PdfUploads");

            migrationBuilder.DropIndex(
                name: "IX_questions_LectureId",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_SubjectId",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_Text_SubjectId_LectureId",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "questions");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionType",
                table: "questions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Hint",
                table: "questions",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "questions",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_questions_Text_Subject",
                table: "questions",
                columns: new[] { "Text", "Subject" });
        }
    }
}
