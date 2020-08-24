using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_App.Migrations
{
    public partial class SeededImageBlobURLsWithSpaces2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Lark%20on%20the%20Wing.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Lark%20on%the%20Wing.jpg");
        }
    }
}
