using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektASPNET.Migrations
{
    /// <inheritdoc />
    public partial class UserAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_applicationUsers",
                table: "applicationUsers");

            migrationBuilder.RenameTable(
                name: "applicationUsers",
                newName: "ApplicationUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers");

            migrationBuilder.RenameTable(
                name: "ApplicationUsers",
                newName: "applicationUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_applicationUsers",
                table: "applicationUsers",
                column: "Id");
        }
    }
}
