using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        // when we apply migration
        // creates table
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //inside create name (name we gave 'DbSet' inside DbContext), columns
            migrationBuilder.CreateTable(
                // creates two columns, 1. ID, 2. Name
                // EF recognizes that we want to use ID as primary key because this is what we called it in our Value class
                // Because Id is an ID and an integer, it is automatically going to increment each time we add a new entity into our values table
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });
        }
        // Does the opposite of the up method, drop table with the Name of name
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Values");
        }
    }
}
