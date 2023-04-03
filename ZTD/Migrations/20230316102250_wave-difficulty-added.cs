using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZTD.Migrations
{
    public partial class wavedifficultyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Wave");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 2, 23, 18, 32, 27, 548, DateTimeKind.Unspecified).AddTicks(2780), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 23, 18, 32, 27, 548, DateTimeKind.Unspecified).AddTicks(2870), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
