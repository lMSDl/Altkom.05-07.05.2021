using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddPeselToPersonAsAlternateKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PESEL",
                schema: "efc",
                table: "People",
                type: "decimal(11,0)",
                precision: 11,
                scale: 0,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_People_PESEL",
                schema: "efc",
                table: "People",
                column: "PESEL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_People_PESEL",
                schema: "efc",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PESEL",
                schema: "efc",
                table: "People");
        }
    }
}
