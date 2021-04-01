using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Shop.Migrations
{
    public partial class Boutiquedatecreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DATECREATION",
                table: "BOUTIQUE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
