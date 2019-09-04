using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaInfra.Migrations
{
    public partial class AlteracaonasclassIntermeioePhoebus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnaliseId",
                table: "Analise",
                newName: "ANaliseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ANaliseId",
                table: "Analise",
                newName: "AnaliseId");
        }
    }
}
