using Microsoft.EntityFrameworkCore.Migrations;

namespace CarusoPizza.Migrations
{
    public partial class PizzaSizeIdNullableForNonPizzaProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_PizzaSizes_PizzaSizeId",
                table: "OrderProducts");

            migrationBuilder.AlterColumn<int>(
                name: "PizzaSizeId",
                table: "OrderProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_PizzaSizes_PizzaSizeId",
                table: "OrderProducts",
                column: "PizzaSizeId",
                principalTable: "PizzaSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_PizzaSizes_PizzaSizeId",
                table: "OrderProducts");

            migrationBuilder.AlterColumn<int>(
                name: "PizzaSizeId",
                table: "OrderProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_PizzaSizes_PizzaSizeId",
                table: "OrderProducts",
                column: "PizzaSizeId",
                principalTable: "PizzaSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
