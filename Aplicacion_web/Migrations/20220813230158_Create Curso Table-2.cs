using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacion_web.Migrations
{
    public partial class CreateCursoTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Large_Description",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Nivel",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Objetivos",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Publico_Objetivo",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Requisitos",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Short_Description",
                table: "Cursos",
                type: "nvarchar(280)",
                maxLength: 280,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Large_Description",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Objetivos",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Publico_Objetivo",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Requisitos",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Short_Description",
                table: "Cursos");
        }
    }
}
