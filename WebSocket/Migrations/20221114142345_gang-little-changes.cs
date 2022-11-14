using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSocket.Migrations
{
    public partial class ganglittlechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Power",
                table: "GangMember",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "GangMember",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MemberCount",
                table: "Gang",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Power",
                table: "GangMember");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "GangMember");

            migrationBuilder.DropColumn(
                name: "MemberCount",
                table: "Gang");
        }
    }
}
