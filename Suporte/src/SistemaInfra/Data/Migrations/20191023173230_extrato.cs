using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaInfra.Migrations
{
    public partial class extrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescontoAluguel",
                table: "Pos");

            migrationBuilder.DropColumn(
                name: "CountPos",
                table: "Extrato");

            migrationBuilder.RenameColumn(
                name: "VendidoAlugadoAlocado",
                table: "Pos",
                newName: "PosStatus");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Pos",
                newName: "NumeroLogico");

            migrationBuilder.RenameColumn(
                name: "Desvinculado",
                table: "Pos",
                newName: "DataCadastro");

            migrationBuilder.RenameColumn(
                name: "DescontoSaldoNegativo",
                table: "Pos",
                newName: "Cpfcnpj");

            migrationBuilder.RenameColumn(
                name: "AluguelDesativado",
                table: "Pos",
                newName: "AluguelStatus");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Extrato",
                newName: "cpfcnpj");

            migrationBuilder.RenameColumn(
                name: "IdTransacao",
                table: "Extrato",
                newName: "TotalRecebido");

            migrationBuilder.RenameColumn(
                name: "ExtratoAluguelId",
                table: "Extrato",
                newName: "PosCadastradas");

            migrationBuilder.AddColumn<int>(
                name: "ExtratoId",
                table: "Pos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosAtivas",
                table: "Extrato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusCobranca",
                table: "Extrato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalAluguel",
                table: "Extrato",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pos_ExtratoId",
                table: "Pos",
                column: "ExtratoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_Extrato_ExtratoId",
                table: "Pos",
                column: "ExtratoId",
                principalTable: "Extrato",
                principalColumn: "ExtratoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pos_Extrato_ExtratoId",
                table: "Pos");

            migrationBuilder.DropIndex(
                name: "IX_Pos_ExtratoId",
                table: "Pos");

            migrationBuilder.DropColumn(
                name: "ExtratoId",
                table: "Pos");

            migrationBuilder.DropColumn(
                name: "PosAtivas",
                table: "Extrato");

            migrationBuilder.DropColumn(
                name: "StatusCobranca",
                table: "Extrato");

            migrationBuilder.DropColumn(
                name: "TotalAluguel",
                table: "Extrato");

            migrationBuilder.RenameColumn(
                name: "PosStatus",
                table: "Pos",
                newName: "VendidoAlugadoAlocado");

            migrationBuilder.RenameColumn(
                name: "NumeroLogico",
                table: "Pos",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Pos",
                newName: "Desvinculado");

            migrationBuilder.RenameColumn(
                name: "Cpfcnpj",
                table: "Pos",
                newName: "DescontoSaldoNegativo");

            migrationBuilder.RenameColumn(
                name: "AluguelStatus",
                table: "Pos",
                newName: "AluguelDesativado");

            migrationBuilder.RenameColumn(
                name: "cpfcnpj",
                table: "Extrato",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "TotalRecebido",
                table: "Extrato",
                newName: "IdTransacao");

            migrationBuilder.RenameColumn(
                name: "PosCadastradas",
                table: "Extrato",
                newName: "ExtratoAluguelId");

            migrationBuilder.AddColumn<double>(
                name: "DescontoAluguel",
                table: "Pos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CountPos",
                table: "Extrato",
                nullable: false,
                defaultValue: 0);
        }
    }
}
