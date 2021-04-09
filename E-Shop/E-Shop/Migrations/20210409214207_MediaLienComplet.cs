using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Shop.Migrations
{
    public partial class MediaLienComplet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HTML",
                table: "MEDIA",
                newName: "LIENCOMPLET");

            migrationBuilder.AlterColumn<int>(
                name: "POIDS",
                table: "PRODUIT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LIENCOMPLET",
                table: "MEDIA",
                newName: "HTML");

            migrationBuilder.AlterColumn<int>(
                name: "POIDS",
                table: "PRODUIT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
