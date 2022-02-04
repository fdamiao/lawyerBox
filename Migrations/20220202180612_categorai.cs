using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeblawyersBox.Migrations
{
    public partial class categorai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDistribuicao",
                table: "Processo_Tbs");

            migrationBuilder.DropColumn(
                name: "DataNotificacao",
                table: "Processo_Tbs");

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "TpProcessos",
                maxLength: 180,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "TimesheetTbs",
                maxLength: 180,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "Processo_Tbs",
                maxLength: 180,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);

            migrationBuilder.AddColumn<int>(
                name: "Categorias",
                table: "Processo_Tbs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "Pessoas_Envolvidas_Tbs",
                maxLength: 180,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "PagamentoLicencas",
                maxLength: 180,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "Intrevistas",
                maxLength: 180,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "FacturacaoTBs",
                maxLength: 180,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "EstatusProcesses",
                maxLength: 180,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "Documentos_Processos_Tbs",
                maxLength: 180,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "CobrancaTBs",
                maxLength: 180,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "Cliente_Tbs",
                maxLength: 180,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "Audiencia_Tabs",
                maxLength: 180,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);

            migrationBuilder.AlterColumn<string>(
                name: "idprocesso",
                table: "ActividadesProcessos",
                maxLength: 180,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "ActividadesProcessos",
                maxLength: 180,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorias",
                table: "Processo_Tbs");

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "TpProcessos",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 180,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "TimesheetTbs",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 180,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "Processo_Tbs",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 180,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDistribuicao",
                table: "Processo_Tbs",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNotificacao",
                table: "Processo_Tbs",
                type: "date",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "Pessoas_Envolvidas_Tbs",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 180,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "PagamentoLicencas",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 180,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "Intrevistas",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 180,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "FacturacaoTBs",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 180,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "EstatusProcesses",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 180,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "Documentos_Processos_Tbs",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 180,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "CobrancaTBs",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 180,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "Cliente_Tbs",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 180,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "Audiencia_Tabs",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 180,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "idprocesso",
                table: "ActividadesProcessos",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 180,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iduser",
                table: "ActividadesProcessos",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 180,
                oldNullable: true);
        }
    }
}
