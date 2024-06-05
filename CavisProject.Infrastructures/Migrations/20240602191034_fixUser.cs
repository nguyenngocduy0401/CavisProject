using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class fixUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireOTPEmail",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OTPEmail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireOTPEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OTPEmail",
                table: "AspNetUsers");
        }
    }
}
