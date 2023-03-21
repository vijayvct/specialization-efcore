using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day1_EFCore_Demo.Migrations
{
    public partial class StoredProcedureAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"create procedure dbo.GetCategory @id int
            as 
            begin
            select * from Categories where id=@id
            end";

            var func=@"create function GetProductCount(@catid int) returns int
            as 
            begin
            declare @count int
            select @count=count(*) from Products where categoryid=@catid
            return @count
            end";

            migrationBuilder.Sql(sp);
            migrationBuilder.Sql(func);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop procedure GetCategory");
            migrationBuilder.Sql("drop function GetProductCount");
        }
    }
}
