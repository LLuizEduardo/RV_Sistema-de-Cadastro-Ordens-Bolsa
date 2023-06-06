using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RV.Infrastucture.Migrations
{
    public partial class TBCriacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Papel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Ordem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Corretora = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Opcoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opcao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Papel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strike = table.Column<double>(type: "float", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Ordem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Corretora = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcoes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acoes");

            migrationBuilder.DropTable(
                name: "Opcoes");
        }
    }
}
