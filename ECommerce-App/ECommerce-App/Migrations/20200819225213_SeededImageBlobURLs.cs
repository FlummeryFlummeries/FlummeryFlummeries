using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_App.Migrations
{
    public partial class SeededImageBlobURLs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Job%20Jelly.jpg");

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Tied%20for%20First.jpg");

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Tryion.jpg");

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Baby%20Cowboy.jpg");

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Polka.jpg");

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Lark%20on%20the%20Wing.jpg");

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Scarce%20Flour.jpg");

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Flum%20Jr..jpg");

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Political%20HumFlummery.jpg");

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Flawmery.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: null);
        }
    }
}
