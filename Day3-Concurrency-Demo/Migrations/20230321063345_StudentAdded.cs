using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day3_Concurrency_Demo.Migrations
{
    public partial class StudentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "StudentType" },
                values: new object[] { 1, "Vijay", 0 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "StudentType" },
                values: new object[] { 2, "Suresh", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
