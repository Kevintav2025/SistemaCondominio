using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCondominio.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Reservas",
                newName: "MoradorId");

            migrationBuilder.RenameColumn(
                name: "DataReserva",
                table: "Reservas",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "Disponivel",
                table: "AreasComuns",
                newName: "Ativo");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AreaComumId",
                table: "Reservas",
                column: "AreaComumId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_MoradorId",
                table: "Reservas",
                column: "MoradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_AreasComuns_AreaComumId",
                table: "Reservas",
                column: "AreaComumId",
                principalTable: "AreasComuns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Moradores_MoradorId",
                table: "Reservas",
                column: "MoradorId",
                principalTable: "Moradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_AreasComuns_AreaComumId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Moradores_MoradorId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_AreaComumId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_MoradorId",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "MoradorId",
                table: "Reservas",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Reservas",
                newName: "DataReserva");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "AreasComuns",
                newName: "Disponivel");
        }
    }
}
