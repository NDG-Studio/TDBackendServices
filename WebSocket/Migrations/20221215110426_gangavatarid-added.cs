using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSocket.Migrations
{
    public partial class gangavataridadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AGangAvatarId",
                table: "News",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TGangAvatarId",
                table: "News",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvatarId",
                table: "Gang",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AGangAvatarId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "TGangAvatarId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AvatarId",
                table: "Gang");
        }
    }
}
