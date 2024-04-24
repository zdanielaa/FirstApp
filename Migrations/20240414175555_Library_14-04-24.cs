using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApp.Migrations
{
    /// <inheritdoc />
    public partial class Library_140424 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_loans_BooksCopy_BookCopyId",
                table: "loans");

            migrationBuilder.DropForeignKey(
                name: "FK_loans_Users_UserId",
                table: "loans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_loans",
                table: "loans");

            migrationBuilder.RenameTable(
                name: "loans",
                newName: "Loans");

            migrationBuilder.RenameIndex(
                name: "IX_loans_UserId",
                table: "Loans",
                newName: "IX_Loans_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_loans_BookCopyId",
                table: "Loans",
                newName: "IX_Loans_BookCopyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loans",
                table: "Loans",
                column: "LoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_BooksCopy_BookCopyId",
                table: "Loans",
                column: "BookCopyId",
                principalTable: "BooksCopy",
                principalColumn: "BookCopyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_UserId",
                table: "Loans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_BooksCopy_BookCopyId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_UserId",
                table: "Loans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loans",
                table: "Loans");

            migrationBuilder.RenameTable(
                name: "Loans",
                newName: "loans");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_UserId",
                table: "loans",
                newName: "IX_loans_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_BookCopyId",
                table: "loans",
                newName: "IX_loans_BookCopyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_loans",
                table: "loans",
                column: "LoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_loans_BooksCopy_BookCopyId",
                table: "loans",
                column: "BookCopyId",
                principalTable: "BooksCopy",
                principalColumn: "BookCopyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_loans_Users_UserId",
                table: "loans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
