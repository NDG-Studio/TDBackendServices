using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityApi.Migrations
{
    public partial class firstlogindatepropertyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "FirstLogInDate",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 8, 18, 2, 47, 547, DateTimeKind.Unspecified).AddTicks(3198), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 8, 18, 2, 47, 547, DateTimeKind.Unspecified).AddTicks(3265), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstLogInDate",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LastSeen",
                value: new DateTimeOffset(new DateTime(2022, 7, 18, 17, 46, 23, 457, DateTimeKind.Unspecified).AddTicks(9231), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
