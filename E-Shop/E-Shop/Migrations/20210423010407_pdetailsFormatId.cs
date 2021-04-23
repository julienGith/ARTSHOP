using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Shop.Migrations
{
    public partial class pdetailsFormatId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_P_DETAIL",
                table: "P_DETAIL");

            migrationBuilder.AddColumn<int>(
                name: "FORMATID",
                table: "P_DETAIL",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_P_DETAIL",
                table: "P_DETAIL",
                columns: new[] { "PANIERID", "PRODID", "FORMATID" });

            migrationBuilder.CreateIndex(
                name: "IX_P_DETAIL_FORMATID",
                table: "P_DETAIL",
                column: "FORMATID");

            migrationBuilder.AddForeignKey(
                name: "FK_P_DETAIL_FORMAT_FORMATID",
                table: "P_DETAIL",
                column: "FORMATID",
                principalTable: "FORMAT",
                principalColumn: "FORMATID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_P_DETAIL_FORMAT_FORMATID",
                table: "P_DETAIL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_P_DETAIL",
                table: "P_DETAIL");

            migrationBuilder.DropIndex(
                name: "IX_P_DETAIL_FORMATID",
                table: "P_DETAIL");

            migrationBuilder.DropColumn(
                name: "FORMATID",
                table: "P_DETAIL");

            migrationBuilder.AddPrimaryKey(
                name: "PK_P_DETAIL",
                table: "P_DETAIL",
                columns: new[] { "PANIERID", "PRODID" });
        }
    }
}
