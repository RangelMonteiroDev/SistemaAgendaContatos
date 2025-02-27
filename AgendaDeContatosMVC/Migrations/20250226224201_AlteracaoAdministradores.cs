using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaDeContatosMVC.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoAdministradores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ativo",
                table: "Administradores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Administradores");
        }
    }
}
