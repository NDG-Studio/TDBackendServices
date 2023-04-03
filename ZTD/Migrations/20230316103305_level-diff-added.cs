using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZTD.Migrations
{
    public partial class leveldiffadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Wave");

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Level",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 3, 16, 13, 33, 4, 906, DateTimeKind.Unspecified).AddTicks(9430), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 16, 13, 33, 4, 906, DateTimeKind.Unspecified).AddTicks(9480), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Level");

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Wave",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 3, 16, 13, 22, 50, 734, DateTimeKind.Unspecified).AddTicks(5880), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 16, 13, 22, 50, 734, DateTimeKind.Unspecified).AddTicks(5930), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
