using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Shop.Migrations
{
    public partial class LivraisonCoutPsup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LVRCOUTPSUP",
                table: "LIVRAISONTYPE",
                type: "decimal(9,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LVRCOUTPSUP",
                table: "LIVRAISONTYPE");
        }
    }
}
