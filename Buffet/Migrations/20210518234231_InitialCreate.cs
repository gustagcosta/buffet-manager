using Microsoft.EntityFrameworkCore.Migrations;

namespace Buffet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalId",
                table: "Eventos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_LocalId",
                table: "Eventos",
                column: "LocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Locais_LocalId",
                table: "Eventos",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Locais_LocalId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_LocalId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "Eventos");
        }
    }
}
