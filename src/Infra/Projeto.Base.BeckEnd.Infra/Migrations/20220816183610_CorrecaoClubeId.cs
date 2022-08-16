using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Base.BackEnd.Infra.Migrations
{
    public partial class CorrecaoClubeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "clube_pk",
                table: "Estadio");

            migrationBuilder.AddForeignKey(
                name: "Clube_Id_Fk",
                table: "Estadio",
                column: "ClubeId",
                principalTable: "Clube",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Clube_Id_Fk",
                table: "Estadio");

            migrationBuilder.AddForeignKey(
                name: "clube_pk",
                table: "Estadio",
                column: "ClubeId",
                principalTable: "Clube",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
