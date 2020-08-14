using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_App.Migrations.StoreDb
{
    public partial class updateSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Calories", "Manufacturer", "Price", "Weight" },
                values: new object[] { 1150, "Flum & Co", 72.99m, 0.6m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Calories", "Manufacturer", "Price", "Weight" },
                values: new object[] { 873, "Flippery Flumstons", 46.33m, 0.7m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 5,
                column: "Manufacturer",
                value: "Flippery Flumstons");

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 6,
                column: "Manufacturer",
                value: "Full On Flummery");

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Calories", "Compliment", "Manufacturer", "Name", "Price", "Weight" },
                values: new object[] { 465, "What a nice painting! It's going right on the fridge.", "Flum For Kids", "Flum Jr.", 4.99m, 0.2m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Calories", "Compliment", "Manufacturer", "Name", "Price", "Weight" },
                values: new object[] { 1325, "You all are the hardworking, salt of the earth type.", "Local Government", "Political HumFlummery", 52.99m, 0.1m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Calories", "Compliment", "Manufacturer", "Name" },
                values: new object[] { 1792, "You're so good at arguing, you should be a lawyer.", "Flumm Board for Ethical Flumming", "Flawmery" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Calories", "Manufacturer", "Price", "Weight" },
                values: new object[] { 1300, "Acme Baking", 9.99m, 0.5m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Calories", "Manufacturer", "Price", "Weight" },
                values: new object[] { 900, "Acme Baking", 9.99m, 0.5m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 5,
                column: "Manufacturer",
                value: "Acme Baking");

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 6,
                column: "Manufacturer",
                value: "Acme Baking");

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Calories", "Compliment", "Manufacturer", "Name", "Price", "Weight" },
                values: new object[] { 1280, "I can't believe you managed to pull that off. Good job.", "Acme Baking", "Job Jelly", 9.99m, 0.5m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Calories", "Compliment", "Manufacturer", "Name", "Price", "Weight" },
                values: new object[] { 615, "I can't believe you managed to pull that off. Good job.", "Acme Baking", "Job Jelly", 9.99m, 0.5m });

            migrationBuilder.UpdateData(
                table: "Flummery",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Calories", "Compliment", "Manufacturer", "Name" },
                values: new object[] { 1952, "I can't believe you managed to pull that off. Good job.", "Acme Baking", "Job Jelly" });
        }
    }
}
