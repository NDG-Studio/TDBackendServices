using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSocket.Migrations
{
    public partial class newschanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wounded",
                table: "News",
                newName: "WarLoot");

            migrationBuilder.RenameColumn(
                name: "Prisoners",
                table: "News",
                newName: "TWounded");

            migrationBuilder.RenameColumn(
                name: "LostResource",
                table: "News",
                newName: "TWall");

            migrationBuilder.RenameColumn(
                name: "Casualities",
                table: "News",
                newName: "TTroop");

            migrationBuilder.AddColumn<string>(
                name: "ACoord",
                table: "News",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ADead",
                table: "News",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AGangId",
                table: "News",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AGangName",
                table: "News",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "APrisoner",
                table: "News",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ATroop",
                table: "News",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AUserId",
                table: "News",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AUsername",
                table: "News",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AWounded",
                table: "News",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCollected",
                table: "News",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ProcessDate",
                table: "News",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TCoord",
                table: "News",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TDead",
                table: "News",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TGangId",
                table: "News",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TGangName",
                table: "News",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TPrisoner",
                table: "News",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TScrap",
                table: "News",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TUserId",
                table: "News",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TUsername",
                table: "News",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "VictorySide",
                table: "News",
                type: "smallint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACoord",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ADead",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AGangId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AGangName",
                table: "News");

            migrationBuilder.DropColumn(
                name: "APrisoner",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ATroop",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AUserId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AUsername",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AWounded",
                table: "News");

            migrationBuilder.DropColumn(
                name: "IsCollected",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ProcessDate",
                table: "News");

            migrationBuilder.DropColumn(
                name: "TCoord",
                table: "News");

            migrationBuilder.DropColumn(
                name: "TDead",
                table: "News");

            migrationBuilder.DropColumn(
                name: "TGangId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "TGangName",
                table: "News");

            migrationBuilder.DropColumn(
                name: "TPrisoner",
                table: "News");

            migrationBuilder.DropColumn(
                name: "TScrap",
                table: "News");

            migrationBuilder.DropColumn(
                name: "TUserId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "TUsername",
                table: "News");

            migrationBuilder.DropColumn(
                name: "VictorySide",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "WarLoot",
                table: "News",
                newName: "Wounded");

            migrationBuilder.RenameColumn(
                name: "TWounded",
                table: "News",
                newName: "Prisoners");

            migrationBuilder.RenameColumn(
                name: "TWall",
                table: "News",
                newName: "LostResource");

            migrationBuilder.RenameColumn(
                name: "TTroop",
                table: "News",
                newName: "Casualities");
        }
    }
}
