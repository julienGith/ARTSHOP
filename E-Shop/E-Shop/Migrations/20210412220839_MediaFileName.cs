using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Shop.Migrations
{
    public partial class MediaFileName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LIENCOMPLET",
                table: "MEDIA",
                newName: "FILENAME");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FILENAME",
                table: "MEDIA",
                newName: "LIENCOMPLET");
        }
    }
}
