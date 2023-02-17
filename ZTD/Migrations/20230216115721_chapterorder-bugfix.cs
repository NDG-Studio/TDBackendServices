using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZTD.Migrations
{
    public partial class chapterorderbugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Chapter",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 2, 16, 14, 57, 21, 482, DateTimeKind.Unspecified).AddTicks(1580), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 16, 14, 57, 21, 482, DateTimeKind.Unspecified).AddTicks(1620), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Chapter",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 2, 15, 16, 24, 8, 611, DateTimeKind.Unspecified).AddTicks(3970), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 15, 16, 24, 8, 611, DateTimeKind.Unspecified).AddTicks(4020), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
