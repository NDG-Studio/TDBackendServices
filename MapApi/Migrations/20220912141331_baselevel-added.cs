using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapApi.Migrations
{
    public partial class baseleveladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BaseLevel",
                table: "MapItem",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseLevel",
                table: "MapItem");
        }
    }
}
