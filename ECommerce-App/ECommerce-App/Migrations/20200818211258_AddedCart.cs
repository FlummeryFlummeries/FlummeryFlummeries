using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_App.Migrations.StoreDb
{
    public partial class AddedCart : Migration
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
                name: "CartItems",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartItems_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "63866547-918c-4c25-8d19-16c845d2fa2e" });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 2, "cf1833eb-dbd6-42b1-ab9c-cf24382b9d07" });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "CartId", "ProductId", "Id", "Qty" },
                values: new object[,]
                {
                    { 1, 3, 1, 2 },
                    { 1, 7, 2, 4 },
                    { 2, 1, 3, 5 },
                    { 2, 5, 4, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Cart");
        }
    }
}
