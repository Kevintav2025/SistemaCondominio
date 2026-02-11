using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCondominio.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAreaReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantidadeQuartos",
                table: "Apartamentos",
                newName: "CondominioId");

            migrationBuilder.AlterColumn<int>(
                name: "Bloco",
                table: "Apartamentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Moradores_ApartamentoId",
                table: "Moradores",
                column: "ApartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_CondominioId",
                table: "Apartamentos",
                column: "CondominioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartamentos_Condominios_CondominioId",
                table: "Apartamentos",
                column: "CondominioId",
                principalTable: "Condominios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Moradores_Apartamentos_ApartamentoId",
                table: "Moradores",
                column: "ApartamentoId",
                principalTable: "Apartamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartamentos_Condominios_CondominioId",
                table: "Apartamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Moradores_Apartamentos_ApartamentoId",
                table: "Moradores");

            migrationBuilder.DropIndex(
                name: "IX_Moradores_ApartamentoId",
                table: "Moradores");

            migrationBuilder.DropIndex(
                name: "IX_Apartamentos_CondominioId",
                table: "Apartamentos");

            migrationBuilder.RenameColumn(
                name: "CondominioId",
                table: "Apartamentos",
                newName: "QuantidadeQuartos");

            migrationBuilder.AlterColumn<string>(
                name: "Bloco",
                table: "Apartamentos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
