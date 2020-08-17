using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_App.Migrations.StoreDb
{
    public partial class ImageURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Flummery",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Flummery");
        }
    }
}
