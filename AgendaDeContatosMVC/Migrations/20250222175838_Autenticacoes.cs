using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaDeContatosMVC.Migrations
{
    /// <inheritdoc />
    public partial class Autenticacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autenticacoes",
                columns: table => new
                {
                    IdAutenticacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HashCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autenticacoes", x => x.IdAutenticacao);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autenticacoes");
        }
    }
}
