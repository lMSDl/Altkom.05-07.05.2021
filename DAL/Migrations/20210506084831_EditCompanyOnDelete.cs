using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditCompanyOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_People_OwnerId",
                table: "Company");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_People_OwnerId",
                table: "Company",
                column: "OwnerId",
                principalSchema: "efc",
                principalTable: "People",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_People_OwnerId",
                table: "Company");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_People_OwnerId",
                table: "Company",
                column: "OwnerId",
                principalSchema: "efc",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
