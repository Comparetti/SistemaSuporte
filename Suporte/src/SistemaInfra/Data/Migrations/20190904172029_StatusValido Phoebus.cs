using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaInfra.Migrations
{
    public partial class StatusValidoPhoebus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status_Valido",
                table: "Phoebus",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status_Valido",
                table: "Phoebus");
        }
    }
}
