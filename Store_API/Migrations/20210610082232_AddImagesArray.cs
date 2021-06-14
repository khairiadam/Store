using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_API.Migrations
{
    public partial class AddImagesArray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
