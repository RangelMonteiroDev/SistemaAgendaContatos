using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaDeContatosMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddCellNumberInModelUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CellNumber",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellNumber",
                table: "Usuarios");
        }
    }
}
