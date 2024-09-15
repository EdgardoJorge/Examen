using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Examen.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    precio = table.Column<double>(type: "float", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total = table.Column<float>(type: "real", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    id_pedido = table.Column<int>(type: "int", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Pedidos_id_pedido",
                        column: x => x.id_pedido,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "id", "ApellidoMaterno", "ApellidoPaterno", "DNI", "EMail", "Nombre" },
                values: new object[,]
                {
                    { 1, "Rosas", "Rosas", "17273363", "ideideijde@deidhe.com", "Leonardo" },
                    { 2, "Rosas", "Pablo", "12134564", "dheui@hduehde.com", "Juan" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "id", "Nombre", "precio", "stock" },
                values: new object[,]
                {
                    { 1, "Pan integral", 12.300000000000001, 12 },
                    { 2, "Pan Frances", 10.0, 20 }
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "fechaPedido", "id_cliente", "total" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 15, 9, 13, 55, 970, DateTimeKind.Local).AddTicks(5642), 1, 13f },
                    { 2, new DateTime(2024, 9, 15, 9, 13, 55, 970, DateTimeKind.Local).AddTicks(5670), 2, 12f }
                });

            migrationBuilder.InsertData(
                table: "DetallePedidos",
                columns: new[] { "id", "cantidad", "id_pedido", "id_producto" },
                values: new object[,]
                {
                    { 1, 12, 1, 2 },
                    { 2, 3, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_id_pedido",
                table: "DetallePedidos",
                column: "id_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_id_producto",
                table: "DetallePedidos",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_id_cliente",
                table: "Pedidos",
                column: "id_cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePedidos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
