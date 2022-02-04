using Microsoft.EntityFrameworkCore.Migrations;

namespace WeblawyersBox.Migrations
{
    public partial class obs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_Processos_Tbs_Processo_Tbs_idProcesso",
                table: "Documentos_Processos_Tbs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Envolvidas_Tbs_Processo_Tbs_idProcesso",
                table: "Pessoas_Envolvidas_Tbs");

            migrationBuilder.AlterColumn<string>(
                name: "idprocesso",
                table: "TimesheetTbs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "idProcesso",
                table: "Pessoas_Envolvidas_Tbs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "idprocesso",
                table: "Intrevistas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Idprocesso",
                table: "EstatusProcesses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "idProcesso",
                table: "Documentos_Processos_Tbs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_Processos_Tbs_Processo_Tbs_idProcesso",
                table: "Documentos_Processos_Tbs",
                column: "idProcesso",
                principalTable: "Processo_Tbs",
                principalColumn: "Ids",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Envolvidas_Tbs_Processo_Tbs_idProcesso",
                table: "Pessoas_Envolvidas_Tbs",
                column: "idProcesso",
                principalTable: "Processo_Tbs",
                principalColumn: "Ids",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_Processos_Tbs_Processo_Tbs_idProcesso",
                table: "Documentos_Processos_Tbs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Envolvidas_Tbs_Processo_Tbs_idProcesso",
                table: "Pessoas_Envolvidas_Tbs");

            migrationBuilder.AlterColumn<string>(
                name: "idprocesso",
                table: "TimesheetTbs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "idProcesso",
                table: "Pessoas_Envolvidas_Tbs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "idprocesso",
                table: "Intrevistas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Idprocesso",
                table: "EstatusProcesses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "idProcesso",
                table: "Documentos_Processos_Tbs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_Processos_Tbs_Processo_Tbs_idProcesso",
                table: "Documentos_Processos_Tbs",
                column: "idProcesso",
                principalTable: "Processo_Tbs",
                principalColumn: "Ids",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Envolvidas_Tbs_Processo_Tbs_idProcesso",
                table: "Pessoas_Envolvidas_Tbs",
                column: "idProcesso",
                principalTable: "Processo_Tbs",
                principalColumn: "Ids",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
