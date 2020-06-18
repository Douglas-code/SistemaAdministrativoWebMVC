using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaAdministrativoWebMvc.Migrations
{
    public partial class DepartamentoForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroVendas_Vendedors_VendedorId",
                table: "RegistroVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendedors_Departamento_DepartamentoId",
                table: "Vendedors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendedors",
                table: "Vendedors");

            migrationBuilder.RenameTable(
                name: "Vendedors",
                newName: "Vendedor");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedors_DepartamentoId",
                table: "Vendedor",
                newName: "IX_Vendedor_DepartamentoId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Vendedor",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendedor",
                table: "Vendedor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroVendas_Vendedor_VendedorId",
                table: "RegistroVendas",
                column: "VendedorId",
                principalTable: "Vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamento_DepartamentoId",
                table: "Vendedor",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroVendas_Vendedor_VendedorId",
                table: "RegistroVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamento_DepartamentoId",
                table: "Vendedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendedor",
                table: "Vendedor");

            migrationBuilder.RenameTable(
                name: "Vendedor",
                newName: "Vendedors");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedor_DepartamentoId",
                table: "Vendedors",
                newName: "IX_Vendedors_DepartamentoId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Vendedors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendedors",
                table: "Vendedors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroVendas_Vendedors_VendedorId",
                table: "RegistroVendas",
                column: "VendedorId",
                principalTable: "Vendedors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedors_Departamento_DepartamentoId",
                table: "Vendedors",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
