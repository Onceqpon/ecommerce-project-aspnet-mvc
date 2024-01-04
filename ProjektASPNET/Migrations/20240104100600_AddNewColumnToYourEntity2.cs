using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektASPNET.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnToYourEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvaibleParts",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvaibleParts",
                table: "Products");
        }
    }
}
