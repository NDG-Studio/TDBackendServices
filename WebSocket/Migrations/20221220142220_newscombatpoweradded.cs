using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSocket.Migrations
{
    public partial class newscombatpoweradded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ACombatPower",
                table: "News",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AUserAvatar",
                table: "News",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TCombatPower",
                table: "News",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TUserAvatar",
                table: "News",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACombatPower",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AUserAvatar",
                table: "News");

            migrationBuilder.DropColumn(
                name: "TCombatPower",
                table: "News");

            migrationBuilder.DropColumn(
                name: "TUserAvatar",
                table: "News");
        }
    }
}
