using Microsoft.EntityFrameworkCore.Migrations;

namespace CarusoPizza.Migrations
{
    public partial class OrderUserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ApplicationUsers_CreatorId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CreatorId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatorId",
                table: "Orders",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ApplicationUsers_CreatorId",
                table: "Orders",
                column: "CreatorId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ApplicationUsers_CreatorId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CreatorId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ApplicationUsers");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId1",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatorId1",
                table: "Orders",
                column: "CreatorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ApplicationUsers_CreatorId1",
                table: "Orders",
                column: "CreatorId1",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
