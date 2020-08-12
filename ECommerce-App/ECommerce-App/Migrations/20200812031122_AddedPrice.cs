using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_App.Migrations
{
    public partial class AddedPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Flummery",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Calories", "Price" },
                values: new object[] { 1525, 9.99m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Calories", "Compliment", "Name", "Price" },
                values: new object[] { 1300, "That tie looks great on you! Is it new?", "Tied for First", 9.99m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Calories", "Compliment", "Name", "Price" },
                values: new object[] { 900, "Oh wow, you really tried your hardest on that!", "Tryion", 9.99m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Calories", "Compliment", "Name", "Price" },
                values: new object[] { 912, "That chili would be pretty spicy to an infant.", "Baby Cowboy", 9.99m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Calories", "Compliment", "Name", "Price" },
                values: new object[] { 2100, "Stylish if your grandparents dressed you.", "Polka", 9.99m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Calories", "Compliment", "Name", "Price" },
                values: new object[] { 1792, "What a nice sorting algorithm.", "Lark on the Wing", 9.99m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Calories", "Compliment", "Name", "Price" },
                values: new object[] { 1135, "Yeah, that's a nice loaf of quarantine sourdough.", "Scarce Flour", 9.99m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Calories", "Price" },
                values: new object[] { 1280, 9.99m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Calories", "Price" },
                values: new object[] { 615, 9.99m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Calories", "Price" },
                values: new object[] { 1952, 9.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Flummery");

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 1,
                column: "Calories",
                value: 3000);

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Calories", "Compliment", "Name" },
                values: new object[] { 3000, "I can't believe you managed to pull that off. Good job.", "Job Jelly" });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Calories", "Compliment", "Name" },
                values: new object[] { 3000, "I can't believe you managed to pull that off. Good job.", "Job Jelly" });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Calories", "Compliment", "Name" },
                values: new object[] { 3000, "I can't believe you managed to pull that off. Good job.", "Job Jelly" });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Calories", "Compliment", "Name" },
                values: new object[] { 3000, "I can't believe you managed to pull that off. Good job.", "Job Jelly" });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Calories", "Compliment", "Name" },
                values: new object[] { 3000, "I can't believe you managed to pull that off. Good job.", "Job Jelly" });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Calories", "Compliment", "Name" },
                values: new object[] { 3000, "I can't believe you managed to pull that off. Good job.", "Job Jelly" });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 8,
                column: "Calories",
                value: 3000);

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 9,
                column: "Calories",
                value: 3000);

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 10,
                column: "Calories",
                value: 3000);
        }
    }
}
