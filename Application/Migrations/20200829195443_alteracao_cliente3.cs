using Microsoft.EntityFrameworkCore.Migrations;

namespace devboost.dronedelivery.felipe.Migrations
{
    public partial class alteracao_cliente3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pedido_PedidoFK",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_PedidoFK",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_PedidoFK",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_PedidoFK",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "PedidoFK",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "PedidoFK",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Pedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Pedido");

            migrationBuilder.AddColumn<int>(
                name: "PedidoFK",
                table: "Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PedidoFK",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_PedidoFK",
                table: "Pedido",
                column: "PedidoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PedidoFK",
                table: "Cliente",
                column: "PedidoFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pedido_PedidoFK",
                table: "Cliente",
                column: "PedidoFK",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_PedidoFK",
                table: "Pedido",
                column: "PedidoFK",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
