using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HC.Data.Migrations
{
    public partial class AdicionaDatasDeCOntrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Criacao",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualização",
                table: "Clientes",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Criacao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "UltimaAtualização",
                table: "Clientes");
        }
    }
}
