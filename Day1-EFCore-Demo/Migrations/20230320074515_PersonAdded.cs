using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day1_EFCore_Demo.Migrations
{
    public partial class PersonAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "FName", "LName" },
                values: new object[] { 1, "Bill", "G" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "FName", "LName" },
                values: new object[] { 2, "Scott", "Hanselman" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "FName", "LName" },
                values: new object[] { 3, "Steve", "J" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
