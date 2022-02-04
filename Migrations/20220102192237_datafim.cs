using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeblawyersBox.Migrations
{
    public partial class datafim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "datapfim",
                table: "PagamentoLicencas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "datapfim",
                table: "PagamentoLicencas");
        }
    }
}
