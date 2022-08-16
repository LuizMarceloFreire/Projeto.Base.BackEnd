using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Base.BackEnd.Infra.Migrations
{
    public partial class CorrecaoEstadioId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Clube_Id_Fk",
                table: "Estadio");

            migrationBuilder.DropIndex(
                name: "IX_Estadio_ClubeId",
                table: "Estadio");

            migrationBuilder.DropColumn(
                name: "ClubeId",
                table: "Estadio");

            migrationBuilder.AddColumn<int>(
                name: "EstadioId",
                table: "Clube",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clube_EstadioId",
                table: "Clube",
                column: "EstadioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clube_Estadio_EstadioId",
                table: "Clube",
                column: "EstadioId",
                principalTable: "Estadio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clube_Estadio_EstadioId",
                table: "Clube");

            migrationBuilder.DropIndex(
                name: "IX_Clube_EstadioId",
                table: "Clube");

            migrationBuilder.DropColumn(
                name: "EstadioId",
                table: "Clube");

            migrationBuilder.AddColumn<int>(
                name: "ClubeId",
                table: "Estadio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estadio_ClubeId",
                table: "Estadio",
                column: "ClubeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "Clube_Id_Fk",
                table: "Estadio",
                column: "ClubeId",
                principalTable: "Clube",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
