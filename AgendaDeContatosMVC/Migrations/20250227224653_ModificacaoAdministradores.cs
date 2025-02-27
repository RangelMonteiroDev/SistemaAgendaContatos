using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaDeContatosMVC.Migrations
{
    /// <inheritdoc />
    public partial class ModificacaoAdministradores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Administradores");

            migrationBuilder.AddColumn<int>(
                name: "IdAutenticacaoAdmin",
                table: "Administradores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AutenticacoesAdmins",
                columns: table => new
                {
                    IdAutenticacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAministrador = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HashCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutenticacoesAdmins", x => x.IdAutenticacao);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutenticacoesAdmins");

            migrationBuilder.DropColumn(
                name: "IdAutenticacaoAdmin",
                table: "Administradores");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Administradores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
