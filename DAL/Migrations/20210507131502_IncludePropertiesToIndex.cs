using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class IncludePropertiesToIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_FirstLastName",
                schema: "efc",
                table: "People");

            migrationBuilder.CreateIndex(
                name: "Index_FirstLastName",
                schema: "efc",
                table: "People",
                columns: new[] { "FirstName", "LastName" })
                .Annotation("SqlServer:Include", new[] { "BirthDate", "PESEL" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_FirstLastName",
                schema: "efc",
                table: "People");

            migrationBuilder.CreateIndex(
                name: "Index_FirstLastName",
                schema: "efc",
                table: "People",
                columns: new[] { "FirstName", "LastName" });
        }
    }
}
