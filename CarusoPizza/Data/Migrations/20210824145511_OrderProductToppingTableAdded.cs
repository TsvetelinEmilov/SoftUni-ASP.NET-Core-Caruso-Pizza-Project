using Microsoft.EntityFrameworkCore.Migrations;

namespace CarusoPizza.Migrations
{
    public partial class OrderProductToppingTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_OrderProducts_OrderProductId",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_OrderProductId",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "Toppings");

            migrationBuilder.CreateTable(
                name: "OrderProductToppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsOrdered = table.Column<bool>(type: "bit", nullable: false),
                    OrderProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductToppings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProductToppings_OrderProducts_OrderProductId",
                        column: x => x.OrderProductId,
                        principalTable: "OrderProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductToppings_OrderProductId",
                table: "OrderProductToppings",
                column: "OrderProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProductToppings");

            migrationBuilder.AddColumn<int>(
                name: "OrderProductId",
                table: "Toppings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_OrderProductId",
                table: "Toppings",
                column: "OrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_OrderProducts_OrderProductId",
                table: "Toppings",
                column: "OrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
