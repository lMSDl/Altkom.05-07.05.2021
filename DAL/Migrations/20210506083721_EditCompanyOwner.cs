using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditCompanyOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_People_OwnerId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_OwnerId",
                table: "Company");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Company",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_OwnerId",
                table: "Company",
                column: "OwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_People_OwnerId",
                table: "Company",
                column: "OwnerId",
                principalSchema: "efc",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_People_OwnerId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_OwnerId",
                table: "Company");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Company",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
