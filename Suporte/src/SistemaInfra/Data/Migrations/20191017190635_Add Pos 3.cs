using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaInfra.Migrations
{
    public partial class AddPos3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Pos",
               columns: table => new
               {
                   PosId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   Modelo = table.Column<string>(nullable: true),
                   NumeroDeSerie = table.Column<string>(nullable: true),
                   Status = table.Column<bool>(nullable: false),
                   VendidoAlugadoAlocado = table.Column<bool>(nullable: false),
                   Desvinculado = table.Column<bool>(nullable: false),
                   DescontoAluguel = table.Column<double>(nullable: false),
                   DiaVencimento = table.Column<int>(nullable: false),
                   ValorAluguel = table.Column<double>(nullable: false),
                   DescontoEmFaturamento = table.Column<bool>(nullable: false),
                   DescontoSaldoNegativo = table.Column<bool>(nullable: false),
                   AluguelDesativado = table.Column<bool>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Pos", x => x.PosId);
               });
            migrationBuilder.AlterColumn<string>(
                   name: "VendidoAlugadoAlocado",
                   table: "Pos",
                   nullable: true,
                   oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Pos",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "Desvinculado",
                table: "Pos",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "DescontoSaldoNegativo",
                table: "Pos",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "DescontoEmFaturamento",
                table: "Pos",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "AluguelDesativado",
                table: "Pos",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<string>(
                name: "IdPos",
                table: "Pos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPos",
                table: "Pos");

            migrationBuilder.AlterColumn<bool>(
                name: "VendidoAlugadoAlocado",
                table: "Pos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Pos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Desvinculado",
                table: "Pos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "DescontoSaldoNegativo",
                table: "Pos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "DescontoEmFaturamento",
                table: "Pos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AluguelDesativado",
                table: "Pos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
