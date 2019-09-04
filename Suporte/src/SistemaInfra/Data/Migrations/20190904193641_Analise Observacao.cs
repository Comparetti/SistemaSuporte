using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaInfra.Migrations
{
    public partial class AnaliseObservacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ANaliseId",
                table: "Analise",
                newName: "AnaliseId");

            migrationBuilder.AddColumn<string>(
                name: "Obsservacao",
                table: "Analise",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Obsservacao",
                table: "Analise");

            migrationBuilder.RenameColumn(
                name: "AnaliseId",
                table: "Analise",
                newName: "ANaliseId");
        }
    }
}
