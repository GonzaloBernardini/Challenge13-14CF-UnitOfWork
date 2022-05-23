using Microsoft.EntityFrameworkCore.Migrations;

namespace Challenge13Kiosco.Migrations
{
    public partial class TestModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caracteristicas_Productos_ProductoId",
                table: "Caracteristicas");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "Caracteristicas",
                newName: "IdProducto");

            migrationBuilder.RenameIndex(
                name: "IX_Caracteristicas_ProductoId",
                table: "Caracteristicas",
                newName: "IX_Caracteristicas_IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Caracteristicas_Productos_IdProducto",
                table: "Caracteristicas",
                column: "IdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caracteristicas_Productos_IdProducto",
                table: "Caracteristicas");

            migrationBuilder.RenameColumn(
                name: "IdProducto",
                table: "Caracteristicas",
                newName: "ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_Caracteristicas_IdProducto",
                table: "Caracteristicas",
                newName: "IX_Caracteristicas_ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Caracteristicas_Productos_ProductoId",
                table: "Caracteristicas",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
