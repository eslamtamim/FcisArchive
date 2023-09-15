using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCISQuestionsHub.EF.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOndeletePDf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileUploads_PdfUploads_RequestID",
                table: "FileUploads");

            migrationBuilder.AddForeignKey(
                name: "FK_FileUploads_PdfUploads_RequestID",
                table: "FileUploads",
                column: "RequestID",
                principalTable: "PdfUploads",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileUploads_PdfUploads_RequestID",
                table: "FileUploads");

            migrationBuilder.AddForeignKey(
                name: "FK_FileUploads_PdfUploads_RequestID",
                table: "FileUploads",
                column: "RequestID",
                principalTable: "PdfUploads",
                principalColumn: "RequestId");
        }
    }
}
