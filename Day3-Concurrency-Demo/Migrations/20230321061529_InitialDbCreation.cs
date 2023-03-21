using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day3_Concurrency_Demo.Migrations
{
    public partial class InitialDbCreation : Migration
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
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Contact", "FName", "LName" },
                values: new object[] { 1, "999-000-8888", "Bill", "G" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Contact", "FName", "LName" },
                values: new object[] { 2, "222-999-0000", "Malcolm", "D" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Contact", "FName", "LName" },
                values: new object[] { 3, "333-555-1111", "James", "C" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
