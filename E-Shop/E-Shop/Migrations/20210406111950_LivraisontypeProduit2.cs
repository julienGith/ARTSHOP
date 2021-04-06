using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Shop.Migrations
{
    public partial class LivraisontypeProduit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LIVRAISONTYPE_PRODUIT_PRODID",
                table: "LIVRAISONTYPE");

            migrationBuilder.AlterColumn<int>(
                name: "PRODID",
                table: "LIVRAISONTYPE",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LIVRAISONTYPE_PRODUIT_PRODID",
                table: "LIVRAISONTYPE",
                column: "PRODID",
                principalTable: "PRODUIT",
                principalColumn: "PRODID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LIVRAISONTYPE_PRODUIT_PRODID",
                table: "LIVRAISONTYPE");

            migrationBuilder.AlterColumn<int>(
                name: "PRODID",
                table: "LIVRAISONTYPE",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LIVRAISONTYPE_PRODUIT_PRODID",
                table: "LIVRAISONTYPE",
                column: "PRODID",
                principalTable: "PRODUIT",
                principalColumn: "PRODID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
