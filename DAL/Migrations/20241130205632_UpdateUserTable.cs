using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Versions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Versions_AuthorId",
                table: "Versions",
                newName: "IX_Versions_UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Versions",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Versions_UserId",
                table: "Versions",
                newName: "IX_Versions_AuthorId");
        }
    }
}
