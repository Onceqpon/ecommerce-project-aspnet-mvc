using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektASPNET.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Manufacturers_ManufacturerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerIds",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerIds",
                table: "Products",
                column: "ManufacturerIds");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Manufacturers_ManufacturerIds",
                table: "Products",
                column: "ManufacturerIds",
                principalTable: "Manufacturers",
                principalColumn: "ManufacturerIds",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Manufacturers_ManufacturerIds",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ManufacturerIds",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ManufacturerIds",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Manufacturers_ManufacturerId",
                table: "Products",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "ManufacturerIds",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
