﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaInfra.Data;

namespace SistemaInfra.Migrations
{
    [DbContext(typeof(SuporteContext))]
    [Migration("20190904193641_Analise Observacao")]
    partial class AnaliseObservacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SuporteCore.Entity.Analise", b =>
                {
                    b.Property<int>("AnaliseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Card_number")
                        .IsRequired();

                    b.Property<string>("Confirmation_date");

                    b.Property<string>("CpfCnpj");

                    b.Property<DateTime?>("Date_base");

                    b.Property<string>("NomeRazao");

                    b.Property<string>("Nsu")
                        .IsRequired();

                    b.Property<string>("Obsservacao");

                    b.Property<int>("PhoebusId");

                    b.Property<string>("Terminal");

                    b.HasKey("AnaliseId");

                    b.HasIndex("PhoebusId");

                    b.ToTable("Analise");
                });

            modelBuilder.Entity("SuporteCore.Entity.Intermeio", b =>
                {
                    b.Property<int>("IntermeioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bandeira");

                    b.Property<string>("Card_number")
                        .IsRequired();

                    b.Property<string>("CodAutorizacao");

                    b.Property<string>("Confirmation_date");

                    b.Property<string>("CpfCnpj");

                    b.Property<DateTime?>("Date_base");

                    b.Property<string>("Email");

                    b.Property<string>("MID");

                    b.Property<string>("Modelo");

                    b.Property<string>("NomeRazao");

                    b.Property<string>("Nsu")
                        .IsRequired();

                    b.Property<string>("NumeroDeSerie");

                    b.Property<string>("PosId");

                    b.Property<string>("SaldoLiberado");

                    b.Property<string>("Status");

                    b.Property<string>("TID");

                    b.Property<string>("Terminal");

                    b.Property<string>("TransacaoId");

                    b.Property<string>("UsuarioId");

                    b.Property<string>("Valor");

                    b.HasKey("IntermeioId");

                    b.ToTable("Intermeio");
                });

            modelBuilder.Entity("SuporteCore.Entity.Phoebus", b =>
                {
                    b.Property<int>("PhoebusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acquirer");

                    b.Property<string>("Acquirer_nsu");

                    b.Property<string>("Authorization_number");

                    b.Property<string>("Authorization_time");

                    b.Property<string>("Brand");

                    b.Property<string>("Card_holder");

                    b.Property<string>("Card_input_method");

                    b.Property<string>("Card_number")
                        .IsRequired();

                    b.Property<string>("Client_version");

                    b.Property<string>("Confirmation_date");

                    b.Property<DateTime?>("Date_base");

                    b.Property<string>("Fallback");

                    b.Property<string>("Finish_date");

                    b.Property<string>("Merchant");

                    b.Property<string>("Merchant_category_code");

                    b.Property<string>("Merchant_national_id");

                    b.Property<string>("Merchant_national_type");

                    b.Property<string>("Nsu")
                        .IsRequired();

                    b.Property<string>("Origin");

                    b.Property<string>("Original_date");

                    b.Property<string>("Original_nsu");

                    b.Property<string>("Parcels");

                    b.Property<string>("Payment_date");

                    b.Property<string>("Product_id");

                    b.Property<string>("Product_name");

                    b.Property<string>("Requested_password");

                    b.Property<string>("Response_code");

                    b.Property<string>("Server_version");

                    b.Property<string>("Start_date");

                    b.Property<string>("Status");

                    b.Property<bool>("Status_Valido");

                    b.Property<string>("Tef_merchant");

                    b.Property<string>("Tef_terminal");

                    b.Property<string>("Terminal");

                    b.Property<string>("Terminal_manufacturer");

                    b.Property<string>("Terminal_model");

                    b.Property<string>("Terminal_serial_number");

                    b.Property<string>("Terminal_type");

                    b.Property<string>("value");

                    b.HasKey("PhoebusId");

                    b.ToTable("Phoebus");
                });

            modelBuilder.Entity("SuporteCore.Entity.Analise", b =>
                {
                    b.HasOne("SuporteCore.Entity.Phoebus", "Phoebus")
                        .WithMany()
                        .HasForeignKey("PhoebusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
