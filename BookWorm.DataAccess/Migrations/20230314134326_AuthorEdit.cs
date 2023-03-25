using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWorm.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AuthorEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "Authors",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Authors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Authors",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Authors",
                newName: "imageUrl");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Authors",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Authors",
                newName: "first_name");
        }
    }
}
