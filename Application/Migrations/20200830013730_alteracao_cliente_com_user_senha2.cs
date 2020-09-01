using Microsoft.EntityFrameworkCore.Migrations;

namespace devboost.dronedelivery.felipe.Migrations
{
    public partial class alteracao_cliente_com_user_senha2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cliente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cliente");
        }
    }
}
