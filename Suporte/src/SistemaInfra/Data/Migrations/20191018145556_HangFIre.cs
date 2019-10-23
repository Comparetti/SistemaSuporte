using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaInfra.Migrations
{
    public partial class HangFIre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Extrato",
                columns: table => new
                {
                    ExtratoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExtratoAluguelId = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<string>(nullable: true),
                    IdTransacao = table.Column<string>(nullable: true),
                    CountPos = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<string>(nullable: true),
                    NomeRazao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extrato", x => x.ExtratoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Extrato");
        }
    }
}
