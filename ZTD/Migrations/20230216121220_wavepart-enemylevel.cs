using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZTD.Migrations
{
    public partial class wavepartenemylevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 2, 16, 15, 12, 20, 248, DateTimeKind.Unspecified).AddTicks(7320), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 16, 15, 12, 20, 248, DateTimeKind.Unspecified).AddTicks(7360), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_WavePart_EnemyLevelId",
                table: "WavePart",
                column: "EnemyLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_WavePart_EnemyLevel_EnemyLevelId",
                table: "WavePart",
                column: "EnemyLevelId",
                principalTable: "EnemyLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WavePart_EnemyLevel_EnemyLevelId",
                table: "WavePart");

            migrationBuilder.DropIndex(
                name: "IX_WavePart_EnemyLevelId",
                table: "WavePart");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 2, 16, 14, 57, 21, 482, DateTimeKind.Unspecified).AddTicks(1580), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 16, 14, 57, 21, 482, DateTimeKind.Unspecified).AddTicks(1620), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
