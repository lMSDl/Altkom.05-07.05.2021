using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL2.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SomeData",
                schema: "efc",
                table: "People");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SomeData",
                schema: "efc",
                table: "People",
                type: "decimal(10,5)",
                nullable: false,
                defaultValueSql: "((1000.0))");
        }
    }
}
