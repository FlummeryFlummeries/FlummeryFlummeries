using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_App.Migrations
{
    public partial class UpdatingOrderCartsandOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderCardItem_OrderCart_OrderCartId",
                table: "OrderCardItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderCardItem_Flummery_ProductId",
                table: "OrderCardItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderCardItem",
                table: "OrderCardItem");

            migrationBuilder.RenameTable(
                name: "OrderCardItem",
                newName: "OrderCartItem");

            migrationBuilder.RenameIndex(
                name: "IX_OrderCardItem_ProductId",
                table: "OrderCartItem",
                newName: "IX_OrderCartItem_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "OrderCart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderCartItem",
                table: "OrderCartItem",
                columns: new[] { "OrderCartId", "ProductId" });

            migrationBuilder.UpdateData(
                table: "OrderCart",
                keyColumn: "Id",
                keyValue: 1,
                column: "CartId",
                value: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCartItem_OrderCart_OrderCartId",
                table: "OrderCartItem",
                column: "OrderCartId",
                principalTable: "OrderCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCartItem_Flummery_ProductId",
                table: "OrderCartItem",
                column: "ProductId",
                principalTable: "Flummery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderCartItem_OrderCart_OrderCartId",
                table: "OrderCartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderCartItem_Flummery_ProductId",
                table: "OrderCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderCartItem",
                table: "OrderCartItem");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "OrderCart");

            migrationBuilder.RenameTable(
                name: "OrderCartItem",
                newName: "OrderCardItem");

            migrationBuilder.RenameIndex(
                name: "IX_OrderCartItem_ProductId",
                table: "OrderCardItem",
                newName: "IX_OrderCardItem_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderCardItem",
                table: "OrderCardItem",
                columns: new[] { "OrderCartId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCardItem_OrderCart_OrderCartId",
                table: "OrderCardItem",
                column: "OrderCartId",
                principalTable: "OrderCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCardItem_Flummery_ProductId",
                table: "OrderCardItem",
                column: "ProductId",
                principalTable: "Flummery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
