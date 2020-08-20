﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_App.Migrations
{
    public partial class OrderCartTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flummery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Calories = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    Compliment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flummery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderCart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BillingAddress = table.Column<string>(nullable: true),
                    BillingCity = table.Column<string>(nullable: true),
                    BillingState = table.Column<string>(nullable: true),
                    BillingZip = table.Column<string>(nullable: true),
                    ShippingAddress = table.Column<string>(nullable: true),
                    ShippingCity = table.Column<string>(nullable: true),
                    ShippingState = table.Column<string>(nullable: true),
                    ShippingZip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Flummery_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Flummery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderCardItem",
                columns: table => new
                {
                    OrderCartId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCardItem", x => new { x.OrderCartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderCardItem_OrderCart_OrderCartId",
                        column: x => x.OrderCartId,
                        principalTable: "OrderCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderCardItem_Flummery_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Flummery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 2, "63866547-918c-4c25-8d19-16c845d2fa2e" },
                    { 3, "cf1833eb-dbd6-42b1-ab9c-cf24382b9d07" }
                });

            migrationBuilder.InsertData(
                table: "Flummery",
                columns: new[] { "Id", "Calories", "Compliment", "ImageUrl", "Manufacturer", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { 1, 1525, "I can't believe you managed to pull that off. Good job.", null, "Acme Baking", "Job Jelly", 9.99m, 0.5m },
                    { 2, 1150, "That tie looks great on you! Is it new?", null, "Flum & Co", "Tied for First", 72.99m, 0.6m },
                    { 3, 873, "Oh wow, you really tried your hardest on that!", null, "Flippery Flumstons", "Tryion", 46.33m, 0.7m },
                    { 4, 912, "That chili would be pretty spicy to an infant.", null, "Acme Baking", "Baby Cowboy", 9.99m, 0.5m },
                    { 5, 2100, "Stylish if your grandparents dressed you.", null, "Flippery Flumstons", "Polka", 9.99m, 0.5m },
                    { 6, 1792, "What a nice sorting algorithm.", null, "Full On Flummery", "Lark on the Wing", 9.99m, 0.5m },
                    { 7, 1135, "Yeah, that's a nice loaf of quarantine sourdough.", null, "Acme Baking", "Scarce Flour", 9.99m, 0.5m },
                    { 8, 465, "What a nice painting! It's going right on the fridge.", null, "Flum For Kids", "Flum Jr.", 4.99m, 0.2m },
                    { 9, 1325, "You all are the hardworking, salt of the earth type.", null, "Local Government", "Political HumFlummery", 52.99m, 0.1m },
                    { 10, 1792, "You're so good at arguing, you should be a lawyer.", null, "Flumm Board for Ethical Flumming", "Flawmery", 9.99m, 0.5m }
                });

            migrationBuilder.InsertData(
                table: "OrderCart",
                columns: new[] { "Id", "BillingAddress", "BillingCity", "BillingState", "BillingZip", "FirstName", "LastName", "ShippingAddress", "ShippingCity", "ShippingState", "ShippingZip", "UserId" },
                values: new object[] { 1, "1808 Forgotten Way", "Wilmington", "DE", "00001", "John", "Dickinson", "1808 Forgotten Way", "Wilmington", "DE", "00001", "63866547-918c-4c25-8d19-16c845d2fa2e" });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "ProductId", "Qty" },
                values: new object[,]
                {
                    { 3, 1, 5 },
                    { 2, 3, 2 },
                    { 3, 5, 1 },
                    { 2, 7, 4 }
                });

            migrationBuilder.InsertData(
                table: "OrderCardItem",
                columns: new[] { "OrderCartId", "ProductId", "Qty" },
                values: new object[,]
                {
                    { 1, 3, 2 },
                    { 1, 8, 5 },
                    { 1, 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCardItem_ProductId",
                table: "OrderCardItem",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "OrderCardItem");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "OrderCart");

            migrationBuilder.DropTable(
                name: "Flummery");
        }
    }
}
