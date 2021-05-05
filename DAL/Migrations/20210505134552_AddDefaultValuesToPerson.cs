using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddDefaultValuesToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SomeData",
                schema: "efc",
                table: "People",
                type: "decimal(10,5)",
                precision: 10,
                scale: 5,
                nullable: false,
                defaultValue: 1000m,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,5)",
                oldPrecision: 10,
                oldScale: 5);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "efc",
                table: "People",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                schema: "efc",
                table: "People",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "efc",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[LastName] + ' ' + [FirstName]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                schema: "efc",
                table: "People");

            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "efc",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Modified",
                schema: "efc",
                table: "People");

            migrationBuilder.AlterColumn<decimal>(
                name: "SomeData",
                schema: "efc",
                table: "People",
                type: "decimal(10,5)",
                precision: 10,
                scale: 5,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,5)",
                oldPrecision: 10,
                oldScale: 5,
                oldDefaultValue: 1000m);
        }
    }
}
