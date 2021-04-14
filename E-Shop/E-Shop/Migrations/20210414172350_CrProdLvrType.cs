using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Shop.Migrations
{
    public partial class CrProdLvrType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LIVRAISONTYPE_PRODUIT_PRODID",
                table: "LIVRAISONTYPE");

            migrationBuilder.DropIndex(
                name: "IX_LIVRAISONTYPE_PRODID",
                table: "LIVRAISONTYPE");

            migrationBuilder.AlterColumn<decimal>(
                name: "POIDS",
                table: "FORMAT",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "LITRE",
                table: "FORMAT",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,3)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PRODLVRTYPE",
                columns: table => new
                {
                    PRODID = table.Column<int>(type: "int", nullable: false),
                    LVRTYPEID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODLVRTYPE", x => new { x.LVRTYPEID, x.PRODID });
                    table.ForeignKey(
                        name: "FK_PRODLVRTYPE_LIVRAISONTYPE_LVRTYPEID",
                        column: x => x.LVRTYPEID,
                        principalTable: "LIVRAISONTYPE",
                        principalColumn: "LVRTYPID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODLVRTYPE_PRODUIT_PRODID",
                        column: x => x.PRODID,
                        principalTable: "PRODUIT",
                        principalColumn: "PRODID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "LVRTYPE_FK",
                table: "PRODLVRTYPE",
                column: "LVRTYPEID");

            migrationBuilder.CreateIndex(
                name: "PROD_FK",
                table: "PRODLVRTYPE",
                column: "PRODID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODLVRTYPE");

            migrationBuilder.AlterColumn<decimal>(
                name: "POIDS",
                table: "FORMAT",
                type: "decimal(9,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "LITRE",
                table: "FORMAT",
                type: "decimal(9,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
