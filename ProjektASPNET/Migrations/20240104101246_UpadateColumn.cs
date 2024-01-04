using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektASPNET.Migrations
{
    /// <inheritdoc />
    public partial class UpadateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ReleaseYear",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Products");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Products",
                nullable: true);
        }
    }
}
