using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Shop.Migrations
{
    public partial class LivraisontypeBtqId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BTQID",
                table: "LIVRAISONTYPE",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LIVRAISONTYPE_BTQID",
                table: "LIVRAISONTYPE",
                column: "BTQID");

            migrationBuilder.AddForeignKey(
                name: "FK_LIVRAISONTYPE_BOUTIQUE_BTQID",
                table: "LIVRAISONTYPE",
                column: "BTQID",
                principalTable: "BOUTIQUE",
                principalColumn: "BTQID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LIVRAISONTYPE_BOUTIQUE_BTQID",
                table: "LIVRAISONTYPE");

            migrationBuilder.DropIndex(
                name: "IX_LIVRAISONTYPE_BTQID",
                table: "LIVRAISONTYPE");

            migrationBuilder.DropColumn(
                name: "BTQID",
                table: "LIVRAISONTYPE");
        }
    }
}
