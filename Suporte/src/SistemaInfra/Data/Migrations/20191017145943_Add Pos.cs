using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaInfra.Migrations
{
    public partial class AddPos : Migration
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
        }

    }
}
