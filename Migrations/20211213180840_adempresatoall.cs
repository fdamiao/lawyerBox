using Microsoft.EntityFrameworkCore.Migrations;

namespace WeblawyersBox.Migrations
{
    public partial class adempresatoall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "idempresa",
                table: "TimesheetTbs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "idempresa",
                table: "Intrevistas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "idempresa",
                table: "FacturacaoTBs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "idempresa",
                table: "Documentos_Processos_Tbs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "idempresa",
                table: "CobrancaTBs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "idempresa",
                table: "Audiencia_Tabs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "idempresa",
                table: "ActividadesProcessos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idempresa",
                table: "TimesheetTbs");

            migrationBuilder.DropColumn(
                name: "idempresa",
                table: "Intrevistas");

            migrationBuilder.DropColumn(
                name: "idempresa",
                table: "FacturacaoTBs");

            migrationBuilder.DropColumn(
                name: "idempresa",
                table: "Documentos_Processos_Tbs");

            migrationBuilder.DropColumn(
                name: "idempresa",
                table: "CobrancaTBs");

            migrationBuilder.DropColumn(
                name: "idempresa",
                table: "Audiencia_Tabs");

            migrationBuilder.DropColumn(
                name: "idempresa",
                table: "ActividadesProcessos");
        }
    }
}
