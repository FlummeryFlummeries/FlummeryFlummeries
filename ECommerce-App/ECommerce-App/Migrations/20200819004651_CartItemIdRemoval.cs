using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_App.Migrations.StoreDb
{
    public partial class CartItemIdRemoval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "CartItems");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Flummery_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Flummery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Flummery_ProductId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { 1, 3 },
                column: "Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { 1, 7 },
                column: "Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { 2, 1 },
                column: "Id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumns: new[] { "CartId", "ProductId" },
                keyValues: new object[] { 2, 5 },
                column: "Id",
                value: 4);
        }
    }
}
