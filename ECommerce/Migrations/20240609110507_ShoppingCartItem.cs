using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class ShoppingCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "shoppingCartItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCartItems_UserId",
                table: "shoppingCartItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCartItems_AspNetUsers_UserId",
                table: "shoppingCartItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCartItems_AspNetUsers_UserId",
                table: "shoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_shoppingCartItems_UserId",
                table: "shoppingCartItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "shoppingCartItems");
        }
    }
}
