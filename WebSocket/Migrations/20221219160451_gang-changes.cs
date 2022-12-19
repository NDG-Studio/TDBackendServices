using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSocket.Migrations
{
    public partial class gangchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CanStartWar",
                table: "MemberType",
                newName: "CanEditGang");

            migrationBuilder.AddColumn<bool>(
                name: "CanDestroyGang",
                table: "MemberType",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "GangEntryTypeId",
                table: "Gang",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanDestroyGang",
                table: "MemberType");

            migrationBuilder.DropColumn(
                name: "GangEntryTypeId",
                table: "Gang");

            migrationBuilder.RenameColumn(
                name: "CanEditGang",
                table: "MemberType",
                newName: "CanStartWar");
        }
    }
}
