using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityApi.Migrations
{
    public partial class log_column_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppVersion",
                table: "Log",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceId",
                table: "Log",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceModel",
                table: "Log",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceType",
                table: "Log",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "Log",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OsVersion",
                table: "Log",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeMs",
                table: "Log",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Log",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LastSeen",
                value: new DateTimeOffset(new DateTime(2022, 7, 8, 12, 45, 12, 314, DateTimeKind.Unspecified).AddTicks(2923), new TimeSpan(0, 3, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppVersion",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "DeviceModel",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "DeviceType",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Ip",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "OsVersion",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "TimeMs",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Log");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LastSeen",
                value: new DateTimeOffset(new DateTime(2022, 7, 6, 14, 18, 42, 470, DateTimeKind.Unspecified).AddTicks(8924), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
