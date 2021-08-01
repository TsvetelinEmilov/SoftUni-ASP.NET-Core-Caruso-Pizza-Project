using Microsoft.EntityFrameworkCore.Migrations;

namespace CarusoPizza.Migrations
{
    public partial class PizzaSizeTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PizzaSize",
                table: "OrderProducts",
                newName: "PizzaSizeId");

            migrationBuilder.CreateTable(
                name: "PizzaSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaSizes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_PizzaSizeId",
                table: "OrderProducts",
                column: "PizzaSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_PizzaSizes_PizzaSizeId",
                table: "OrderProducts",
                column: "PizzaSizeId",
                principalTable: "PizzaSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_PizzaSizes_PizzaSizeId",
                table: "OrderProducts");

            migrationBuilder.DropTable(
                name: "PizzaSizes");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_PizzaSizeId",
                table: "OrderProducts");

            migrationBuilder.RenameColumn(
                name: "PizzaSizeId",
                table: "OrderProducts",
                newName: "PizzaSize");
        }
    }
}
