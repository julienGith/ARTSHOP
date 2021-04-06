using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Shop.Migrations
{
    public partial class LivraisontypeProduit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUIT_AVOIR_LIVRAISO",
                table: "PRODUIT");

            migrationBuilder.DropIndex(
                name: "AVOIR_FK",
                table: "PRODUIT");

            migrationBuilder.DropColumn(
                name: "LVRTYPID",
                table: "PRODUIT");

            migrationBuilder.AddColumn<int>(
                name: "PRODID",
                table: "LIVRAISONTYPE",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LIVRAISONTYPE_PRODID",
                table: "LIVRAISONTYPE",
                column: "PRODID");

            migrationBuilder.AddForeignKey(
                name: "FK_LIVRAISONTYPE_PRODUIT_PRODID",
                table: "LIVRAISONTYPE",
                column: "PRODID",
                principalTable: "PRODUIT",
                principalColumn: "PRODID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LIVRAISONTYPE_PRODUIT_PRODID",
                table: "LIVRAISONTYPE");

            migrationBuilder.DropIndex(
                name: "IX_LIVRAISONTYPE_PRODID",
                table: "LIVRAISONTYPE");

            migrationBuilder.DropColumn(
                name: "PRODID",
                table: "LIVRAISONTYPE");

            migrationBuilder.AddColumn<int>(
                name: "LVRTYPID",
                table: "PRODUIT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "AVOIR_FK",
                table: "PRODUIT",
                column: "LVRTYPID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUIT_AVOIR_LIVRAISO",
                table: "PRODUIT",
                column: "LVRTYPID",
                principalTable: "LIVRAISONTYPE",
                principalColumn: "LVRTYPID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
