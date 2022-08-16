using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Base.BackEnd.Infra.Migrations
{
    public partial class BaseInicialCorrecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CascadeMode",
                table: "Estadio");

            migrationBuilder.DropColumn(
                name: "ClassLevelCascadeMode",
                table: "Estadio");

            migrationBuilder.DropColumn(
                name: "RuleLevelCascadeMode",
                table: "Estadio");

            migrationBuilder.DropColumn(
                name: "CascadeMode",
                table: "Clube");

            migrationBuilder.DropColumn(
                name: "ClassLevelCascadeMode",
                table: "Clube");

            migrationBuilder.DropColumn(
                name: "RuleLevelCascadeMode",
                table: "Clube");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CascadeMode",
                table: "Estadio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassLevelCascadeMode",
                table: "Estadio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RuleLevelCascadeMode",
                table: "Estadio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CascadeMode",
                table: "Clube",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassLevelCascadeMode",
                table: "Clube",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RuleLevelCascadeMode",
                table: "Clube",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
