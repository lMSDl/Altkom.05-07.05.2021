using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddFirstLastNameIndexToPeople_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "efc",
                table: "People");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "efc",
                table: "People",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "Index_FirstLastName",
                schema: "efc",
                table: "People",
                columns: new[] { "FirstName", "LastName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_FirstLastName",
                schema: "efc",
                table: "People");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "efc",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "efc",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[LastName] + ' ' + [FirstName]");
        }
    }
}
