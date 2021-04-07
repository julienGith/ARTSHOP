using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Shop.Migrations
{
    public partial class ProduitPoids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "POIDS",
                table: "PRODUIT",
                type: "int",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "POIDS",
                table: "PRODUIT");
        }
    }
}
