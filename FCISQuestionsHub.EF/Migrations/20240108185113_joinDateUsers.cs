using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCISQuestionsHub.EF.Migrations
{
    /// <inheritdoc />
    public partial class joinDateUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                schema: "security",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmittedOn",
                table: "studentQuestionAnswer",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoinDate",
                schema: "security",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmittedOn",
                table: "studentQuestionAnswer",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
