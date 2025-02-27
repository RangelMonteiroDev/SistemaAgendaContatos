using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaDeContatosMVC.Migrations
{
    /// <inheritdoc />
    public partial class ModificacaoAutenticacoesAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAministrador",
                table: "AutenticacoesAdmins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAministrador",
                table: "AutenticacoesAdmins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
