using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Shop.Migrations
{
    public partial class produitPoids123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "POIDS",
                table: "PRODUIT",
                newName: "POIDS3");

            migrationBuilder.AddColumn<int>(
                name: "POIDS1",
                table: "PRODUIT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "POIDS2",
                table: "PRODUIT",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "POIDS1",
                table: "PRODUIT");

            migrationBuilder.DropColumn(
                name: "POIDS2",
                table: "PRODUIT");

            migrationBuilder.RenameColumn(
                name: "POIDS3",
                table: "PRODUIT",
                newName: "POIDS");
        }
    }
}
