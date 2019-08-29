using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaInfra.Migrations
{
    public partial class CreateDateBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Intermeio",
                columns: table => new
                {
                    IntermeioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nsu = table.Column<string>(nullable: false),
                    Card_number = table.Column<string>(nullable: false),
                    Terminal = table.Column<string>(nullable: true),
                    Confirmation_date = table.Column<string>(nullable: true),
                    Date_base = table.Column<DateTime>(nullable: true),
                    TransacaoId = table.Column<string>(nullable: true),
                    Bandeira = table.Column<string>(nullable: true),
                    CodAutorizacao = table.Column<string>(nullable: true),
                    Valor = table.Column<string>(nullable: true),
                    PosId = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    NumeroDeSerie = table.Column<string>(nullable: true),
                    TID = table.Column<string>(nullable: true),
                    MID = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: true),
                    CpfCnpj = table.Column<string>(nullable: true),
                    NomeRazao = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    SaldoLiberado = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intermeio", x => x.IntermeioId);
                });

            migrationBuilder.CreateTable(
                name: "Phoebus",
                columns: table => new
                {
                    PhoebusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nsu = table.Column<string>(nullable: false),
                    Card_number = table.Column<string>(nullable: false),
                    Terminal = table.Column<string>(nullable: true),
                    Confirmation_date = table.Column<string>(nullable: true),
                    Date_base = table.Column<DateTime>(nullable: true),
                    Acquirer_nsu = table.Column<string>(nullable: true),
                    value = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Parcels = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Start_date = table.Column<string>(nullable: true),
                    Finish_date = table.Column<string>(nullable: true),
                    Payment_date = table.Column<string>(nullable: true),
                    Response_code = table.Column<string>(nullable: true),
                    Authorization_number = table.Column<string>(nullable: true),
                    Tef_terminal = table.Column<string>(nullable: true),
                    Terminal_serial_number = table.Column<string>(nullable: true),
                    Terminal_manufacturer = table.Column<string>(nullable: true),
                    Terminal_model = table.Column<string>(nullable: true),
                    Terminal_type = table.Column<string>(nullable: true),
                    Acquirer = table.Column<string>(nullable: true),
                    Merchant = table.Column<string>(nullable: true),
                    Tef_merchant = table.Column<string>(nullable: true),
                    Merchant_category_code = table.Column<string>(nullable: true),
                    Merchant_national_type = table.Column<string>(nullable: true),
                    Merchant_national_id = table.Column<string>(nullable: true),
                    Product_name = table.Column<string>(nullable: true),
                    Product_id = table.Column<string>(nullable: true),
                    Card_input_method = table.Column<string>(nullable: true),
                    Requested_password = table.Column<string>(nullable: true),
                    Fallback = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true),
                    Authorization_time = table.Column<string>(nullable: true),
                    Client_version = table.Column<string>(nullable: true),
                    Server_version = table.Column<string>(nullable: true),
                    Original_nsu = table.Column<string>(nullable: true),
                    Original_date = table.Column<string>(nullable: true),
                    Card_holder = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phoebus", x => x.PhoebusId);
                });

            migrationBuilder.CreateTable(
                name: "Analise",
                columns: table => new
                {
                    AnaliseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nsu = table.Column<string>(nullable: false),
                    Card_number = table.Column<string>(nullable: false),
                    Terminal = table.Column<string>(nullable: true),
                    Confirmation_date = table.Column<string>(nullable: true),
                    Date_base = table.Column<DateTime>(nullable: true),
                    CpfCnpj = table.Column<string>(nullable: true),
                    NomeRazao = table.Column<string>(nullable: true),
                    PhoebusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analise", x => x.AnaliseId);
                    table.ForeignKey(
                        name: "FK_Analise_Phoebus_PhoebusId",
                        column: x => x.PhoebusId,
                        principalTable: "Phoebus",
                        principalColumn: "PhoebusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analise_PhoebusId",
                table: "Analise",
                column: "PhoebusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analise");

            migrationBuilder.DropTable(
                name: "Intermeio");

            migrationBuilder.DropTable(
                name: "Phoebus");
        }
    }
}
