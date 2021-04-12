using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Shop.Migrations
{
    public partial class format : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "POIDS1",
                table: "PRODUIT");

            migrationBuilder.DropColumn(
                name: "POIDS2",
                table: "PRODUIT");

            migrationBuilder.DropColumn(
                name: "POIDS3",
                table: "PRODUIT");

            migrationBuilder.DropColumn(
                name: "PRIX",
                table: "PRODUIT");

            migrationBuilder.CreateTable(
                name: "FORMAT",
                columns: table => new
                {
                    FORMATID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODID = table.Column<int>(type: "int", nullable: false),
                    PRIX = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    POIDS = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LITRE = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORMAT", x => x.FORMATID);
                    table.ForeignKey(
                        name: "FK_FORMAT_PRODUIT_PRODID",
                        column: x => x.PRODID,
                        principalTable: "PRODUIT",
                        principalColumn: "PRODID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "PESER_FK",
                table: "FORMAT",
                column: "PRODID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FORMAT");

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

            migrationBuilder.AddColumn<int>(
                name: "POIDS3",
                table: "PRODUIT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PRIX",
                table: "PRODUIT",
                type: "decimal(9,2)",
                nullable: true);
        }
    }
}
