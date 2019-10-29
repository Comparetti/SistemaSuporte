using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaInfra.Migrations
{
    public partial class extratoposcobradas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Pos");

            migrationBuilder.DropColumn(
                name: "PosAtivas",
                table: "Extrato");

            migrationBuilder.AlterColumn<double>(
                name: "TotalRecebido",
                table: "Extrato",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalAluguel",
                table: "Extrato",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PosCobradas",
                table: "Extrato",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosCobradas",
                table: "Extrato");

            migrationBuilder.AddColumn<string>(
                name: "IdUsuario",
                table: "Pos",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TotalRecebido",
                table: "Extrato",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "TotalAluguel",
                table: "Extrato",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "PosAtivas",
                table: "Extrato",
                nullable: true);
        }
    }
}
