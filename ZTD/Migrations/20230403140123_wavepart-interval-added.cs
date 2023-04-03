using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZTD.Migrations
{
    public partial class wavepartintervaladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "IntervalTime",
                table: "WavePart",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 3, 17, 1, 23, 547, DateTimeKind.Unspecified).AddTicks(2600), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 3, 17, 1, 23, 547, DateTimeKind.Unspecified).AddTicks(2660), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntervalTime",
                table: "WavePart");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 3, 16, 13, 33, 4, 906, DateTimeKind.Unspecified).AddTicks(9430), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 16, 13, 33, 4, 906, DateTimeKind.Unspecified).AddTicks(9480), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
