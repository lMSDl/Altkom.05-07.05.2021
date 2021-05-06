using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeDiscriminator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "efc",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "ClassType",
                schema: "efc",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassType",
                schema: "efc",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "efc",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
