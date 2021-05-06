using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RemoveFilterFromPersonBirthDateIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_BirthDate",
                schema: "efc",
                table: "People");

            migrationBuilder.CreateIndex(
                name: "IX_People_BirthDate",
                schema: "efc",
                table: "People",
                column: "BirthDate",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_BirthDate",
                schema: "efc",
                table: "People");

            migrationBuilder.CreateIndex(
                name: "IX_People_BirthDate",
                schema: "efc",
                table: "People",
                column: "BirthDate",
                unique: true,
                filter: "[BirthDate] IS NOT NULL");
        }
    }
}
