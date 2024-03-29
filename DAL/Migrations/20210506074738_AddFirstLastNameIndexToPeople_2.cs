﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddFirstLastNameIndexToPeople_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "efc",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[LastName] + ' ' + [FirstName]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "efc",
                table: "People");
        }
    }
}
