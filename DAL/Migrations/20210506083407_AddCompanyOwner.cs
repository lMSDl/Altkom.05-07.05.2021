using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddCompanyOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_OwnerId",
                table: "Company",
                column: "OwnerId",
                unique: true,
                filter: "[OwnerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_People_OwnerId",
                table: "Company",
                column: "OwnerId",
                principalSchema: "efc",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_People_OwnerId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_OwnerId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Company");
        }
    }
}
