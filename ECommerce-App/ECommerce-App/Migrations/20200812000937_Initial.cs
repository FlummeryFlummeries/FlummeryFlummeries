using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_App.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flummery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    Calories = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    Compliment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flummery", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Flummery",
                columns: new[] { "Id", "Calories", "Compliment", "Manufacturer", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, 3000, "I can't believe you managed to pull that off. Good job.", "Acme Baking", "Job Jelly", 0.5m },
                    { 2, 3000, "I can't believe you managed to pull that off. Good job.", "Acme Baking", "Job Jelly", 0.5m },
                    { 3, 3000, "I can't believe you managed to pull that off. Good job.", "Acme Baking", "Job Jelly", 0.5m },
                    { 4, 3000, "I can't believe you managed to pull that off. Good job.", "Acme Baking", "Job Jelly", 0.5m },
                    { 5, 3000, "I can't believe you managed to pull that off. Good job.", "Acme Baking", "Job Jelly", 0.5m },
                    { 6, 3000, "I can't believe you managed to pull that off. Good job.", "Acme Baking", "Job Jelly", 0.5m },
                    { 7, 3000, "I can't believe you managed to pull that off. Good job.", "Acme Baking", "Job Jelly", 0.5m },
                    { 8, 3000, "I can't believe you managed to pull that off. Good job.", "Acme Baking", "Job Jelly", 0.5m },
                    { 9, 3000, "I can't believe you managed to pull that off. Good job.", "Acme Baking", "Job Jelly", 0.5m },
                    { 10, 3000, "I can't believe you managed to pull that off. Good job.", "Acme Baking", "Job Jelly", 0.5m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flummery");
        }
    }
}
