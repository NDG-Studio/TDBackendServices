using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityApi.Migrations
{
    public partial class userentitychanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsingNFT",
                table: "User");

            migrationBuilder.AddColumn<bool>(
                name: "IsApe",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "IsApe", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 11, 17, 20, 33, 8, 874, DateTimeKind.Unspecified).AddTicks(5430), new TimeSpan(0, 3, 0, 0, 0)), true, new DateTimeOffset(new DateTime(2022, 11, 17, 20, 33, 8, 874, DateTimeKind.Unspecified).AddTicks(5478), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApe",
                table: "User");

            migrationBuilder.AddColumn<bool>(
                name: "UsingNFT",
                table: "User",
                type: "boolean",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen", "UsingNFT" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 8, 18, 2, 47, 547, DateTimeKind.Unspecified).AddTicks(3198), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 8, 18, 2, 47, 547, DateTimeKind.Unspecified).AddTicks(3265), new TimeSpan(0, 3, 0, 0, 0)), true });
        }
    }
}
