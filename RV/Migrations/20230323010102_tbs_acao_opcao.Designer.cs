﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RV;

namespace RV.Migrations
{
    [DbContext(typeof(BancoContent))]
    [Migration("20230323010102_tbs_acao_opcao")]
    partial class tbs_acao_opcao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RV.AcaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Corretora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Papel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("TipoOrdem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Acoes");
                });

            modelBuilder.Entity("RV.OpcaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Corretora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Papel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("TipoOrdem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Opcoes");
                });
#pragma warning restore 612, 618
        }
    }
}
