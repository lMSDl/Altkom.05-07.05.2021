using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddStudentAndEducator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "efc",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IndexNumber",
                schema: "efc",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                schema: "efc",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "efc",
                table: "People");

            migrationBuilder.DropColumn(
                name: "IndexNumber",
                schema: "efc",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Specialization",
                schema: "efc",
                table: "People");
        }
    }
}
