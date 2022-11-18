using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityApi.Migrations
{
    public partial class istutorialdoneadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTutorialDone",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 18, 12, 19, 7, 708, DateTimeKind.Unspecified).AddTicks(1513), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 18, 12, 19, 7, 708, DateTimeKind.Unspecified).AddTicks(1567), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTutorialDone",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 18, 10, 33, 17, 743, DateTimeKind.Unspecified).AddTicks(6345), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 18, 10, 33, 17, 743, DateTimeKind.Unspecified).AddTicks(6388), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
