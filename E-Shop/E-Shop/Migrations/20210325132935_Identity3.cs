using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Shop.Migrations
{
    public partial class Identity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_PARTENAIRE_PartenaireId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_PartenaireId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PartenaireId",
                table: "Roles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartenaireId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PartenaireId",
                table: "Roles",
                column: "PartenaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_PARTENAIRE_PartenaireId",
                table: "Roles",
                column: "PartenaireId",
                principalTable: "PARTENAIRE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
