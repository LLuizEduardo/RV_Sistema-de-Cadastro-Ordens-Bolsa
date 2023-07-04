using Microsoft.EntityFrameworkCore.Migrations;

namespace RV.Infrastucture.Migrations
{
    public partial class inclusao_usuario_tb_acoes_e_opcoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Opcoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Acoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Opcoes_UsuarioId",
                table: "Opcoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Acoes_UsuarioId",
                table: "Acoes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acoes_Usuarios_UsuarioId",
                table: "Acoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Opcoes_Usuarios_UsuarioId",
                table: "Opcoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acoes_Usuarios_UsuarioId",
                table: "Acoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Opcoes_Usuarios_UsuarioId",
                table: "Opcoes");

            migrationBuilder.DropIndex(
                name: "IX_Opcoes_UsuarioId",
                table: "Opcoes");

            migrationBuilder.DropIndex(
                name: "IX_Acoes_UsuarioId",
                table: "Acoes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Opcoes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Acoes");
        }
    }
}
