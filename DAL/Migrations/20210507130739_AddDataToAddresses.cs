using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddDataToAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Street", "ZipCode" },
                values: new object[] { 4, "Kraków", "Krakowska", null });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Street", "ZipCode" },
                values: new object[] { 5, "Grańsk", "Grańska", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
