using Microsoft.EntityFrameworkCore.Migrations;

namespace CarusoPizza.Migrations
{
    public partial class CascadeDeleteBehaviorAtTablesOrderProductAndOrderProductTopping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductToppings_OrderProducts_OrderProductId",
                table: "OrderProductToppings");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductToppings_OrderProducts_OrderProductId",
                table: "OrderProductToppings",
                column: "OrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductToppings_OrderProducts_OrderProductId",
                table: "OrderProductToppings");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductToppings_OrderProducts_OrderProductId",
                table: "OrderProductToppings",
                column: "OrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
