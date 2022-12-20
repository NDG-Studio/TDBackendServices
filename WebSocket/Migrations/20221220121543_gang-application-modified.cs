using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSocket.Migrations
{
    public partial class gangapplicationmodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Coordinate",
                table: "GangApplication",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rank1",
                table: "GangApplication",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rank2",
                table: "GangApplication",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rank3",
                table: "GangApplication",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rank4",
                table: "GangApplication",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserAvatarId",
                table: "GangApplication",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "GangApplication",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coordinate",
                table: "GangApplication");

            migrationBuilder.DropColumn(
                name: "Rank1",
                table: "GangApplication");

            migrationBuilder.DropColumn(
                name: "Rank2",
                table: "GangApplication");

            migrationBuilder.DropColumn(
                name: "Rank3",
                table: "GangApplication");

            migrationBuilder.DropColumn(
                name: "Rank4",
                table: "GangApplication");

            migrationBuilder.DropColumn(
                name: "UserAvatarId",
                table: "GangApplication");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "GangApplication");
        }
    }
}
