using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSocket.Migrations
{
    public partial class aheroidadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AHeroId",
                table: "News",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AHeroName",
                table: "News",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AHeroId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AHeroName",
                table: "News");
        }
    }
}
