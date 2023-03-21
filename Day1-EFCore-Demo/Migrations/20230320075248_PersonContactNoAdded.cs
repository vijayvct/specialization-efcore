using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day1_EFCore_Demo.Migrations
{
    public partial class PersonContactNoAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "People");
        }
    }
}
