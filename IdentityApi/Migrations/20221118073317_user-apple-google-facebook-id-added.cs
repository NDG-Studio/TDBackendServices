using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityApi.Migrations
{
    public partial class userapplegooglefacebookidadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppleId",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookId",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GooglePlayId",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 18, 10, 33, 17, 743, DateTimeKind.Unspecified).AddTicks(6345), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 18, 10, 33, 17, 743, DateTimeKind.Unspecified).AddTicks(6388), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppleId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FacebookId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GooglePlayId",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 17, 20, 33, 8, 874, DateTimeKind.Unspecified).AddTicks(5430), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 11, 17, 20, 33, 8, 874, DateTimeKind.Unspecified).AddTicks(5478), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
