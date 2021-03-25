using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class UserpasswordAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Values",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Values",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Values",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Values");
        }
    }
}
