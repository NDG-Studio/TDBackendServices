using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapApi.Migrations
{
    public partial class gridsysminimaze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApe",
                table: "MapItem",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "XMax", "YMax" },
                values: new object[] { 15, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 30, 15, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 45, 30, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 15, 30, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 30, 15, 30, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 45, 30, 30, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 15, 45, 30 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 30, 15, 45, 30 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 45, 30, 45, 30 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 60, 45, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 75, 60, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 90, 75, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 60, 45, 30, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 75, 60, 30, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 90, 75, 30, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 60, 45, 45, 30 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 75, 60, 45, 30 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 90, 75, 45, 30 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 105, 90, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 120, 105, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 135, 120, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 105, 90, 30, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 120, 105, 30, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 135, 120, 30, 15 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 105, 90, 45, 30 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 120, 105, 45, 30 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 135, 120, 45, 30 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "XMax", "YMax" },
                values: new object[] { 15, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 30, 15, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 45, 30, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 15, 480, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 30, 15, 480, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 45, 30, 480, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 15, 495, 480 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 30, 15, 495, 480 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 45, 30, 495, 480 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 60, 45, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 75, 60, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 90, 75, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 60, 45, 480, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 75, 60, 480, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 90, 75, 480, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 60, 45, 495, 480 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 75, 60, 495, 480 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 90, 75, 495, 480 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 105, 90, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 120, 105, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 135, 120, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 105, 90, 480, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 120, 105, 480, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 135, 120, 480, 465 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 105, 90, 495, 480 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 120, 105, 495, 480 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 135, 120, 495, 480 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "XMax", "YMax" },
                values: new object[] { 15, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 30, 15, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 45, 30, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 15, 930, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 30, 15, 930, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 45, 30, 930, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 15, 945, 930 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 30, 15, 945, 930 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 45, 30, 945, 930 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 60, 45, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 75, 60, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 90, 75, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 60, 45, 930, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 75, 60, 930, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 90, 75, 930, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 60, 45, 945, 930 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 75, 60, 945, 930 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 90, 75, 945, 930 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 105, 90, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 120, 105, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 135, 120, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 105, 90, 930, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 120, 105, 930, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 135, 120, 930, 915 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 105, 90, 945, 930 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 120, 105, 945, 930 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 135, 120, 945, 930 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "XMax", "YMax" },
                values: new object[] { 15, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 30, 15, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 45, 30, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 15, 1380, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 30, 15, 1380, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 45, 30, 1380, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 15, 1395, 1380 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 30, 15, 1395, 1380 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 45, 30, 1395, 1380 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 60, 45, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 75, 60, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 90, 75, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 60, 45, 1380, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 75, 60, 1380, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 90, 75, 1380, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 60, 45, 1395, 1380 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 75, 60, 1395, 1380 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 90, 75, 1395, 1380 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 105, 90, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 120, 105, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 135, 120, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 105, 90, 1380, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 120, 105, 1380, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 135, 120, 1380, 1365 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 105, 90, 1395, 1380 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 120, 105, 1395, 1380 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 135, 120, 1395, 1380 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "XMax", "YMax" },
                values: new object[] { 15, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 30, 15, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 45, 30, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 15, 1830, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 30, 15, 1830, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 45, 30, 1830, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 15, 1845, 1830 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 30, 15, 1845, 1830 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 45, 30, 1845, 1830 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 60, 45, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 75, 60, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 90, 75, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 60, 45, 1830, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 75, 60, 1830, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 90, 75, 1830, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 60, 45, 1845, 1830 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 75, 60, 1845, 1830 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 90, 75, 1845, 1830 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 105, 90, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 120, 105, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 135, 120, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 105, 90, 1830, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 120, 105, 1830, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 135, 120, 1830, 1815 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 105, 90, 1845, 1830 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 120, 105, 1845, 1830 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 135, 120, 1845, 1830 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "XMax", "YMax" },
                values: new object[] { 45, 45 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 90, 45, 45 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 135, 90, 45 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 45, 90, 45 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 90, 45, 90, 45 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 135, 90, 90, 45 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 45, 135, 90 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 90, 45, 135, 90 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 135, 90, 135, 90 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 45, 180, 135 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 90, 45, 180, 135 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 135, 90, 180, 135 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 45, 225, 180 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 90, 45, 225, 180 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 135, 90, 225, 180 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApe",
                table: "MapItem");

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "XMax", "YMax" },
                values: new object[] { 150, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 300, 150, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 450, 300, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 150, 300, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 300, 150, 300, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 450, 300, 300, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 150, 450, 300 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 300, 150, 450, 300 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 450, 300, 450, 300 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 600, 450, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 750, 600, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 900, 750, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 600, 450, 300, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 750, 600, 300, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 900, 750, 300, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 600, 450, 450, 300 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 750, 600, 450, 300 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 900, 750, 450, 300 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1050, 900, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1200, 1050, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1350, 1200, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1050, 900, 300, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1200, 1050, 300, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1350, 1200, 300, 150 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1050, 900, 450, 300 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1200, 1050, 450, 300 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1350, 1200, 450, 300 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "XMax", "YMax" },
                values: new object[] { 150, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 300, 150, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 450, 300, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 150, 750, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 300, 150, 750, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 450, 300, 750, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 150, 900, 750 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 300, 150, 900, 750 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 450, 300, 900, 750 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 600, 450, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 750, 600, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 900, 750, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 600, 450, 750, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 750, 600, 750, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 900, 750, 750, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 600, 450, 900, 750 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 750, 600, 900, 750 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 900, 750, 900, 750 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1050, 900, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1200, 1050, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1350, 1200, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1050, 900, 750, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1200, 1050, 750, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1350, 1200, 750, 600 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1050, 900, 900, 750 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1200, 1050, 900, 750 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1350, 1200, 900, 750 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "XMax", "YMax" },
                values: new object[] { 150, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 300, 150, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 450, 300, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 150, 1200, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 300, 150, 1200, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 450, 300, 1200, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 150, 1350, 1200 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 300, 150, 1350, 1200 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 450, 300, 1350, 1200 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 600, 450, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 750, 600, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 900, 750, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 600, 450, 1200, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 750, 600, 1200, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 900, 750, 1200, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 600, 450, 1350, 1200 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 750, 600, 1350, 1200 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 900, 750, 1350, 1200 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1050, 900, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1200, 1050, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1350, 1200, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1050, 900, 1200, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1200, 1050, 1200, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1350, 1200, 1200, 1050 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1050, 900, 1350, 1200 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1200, 1050, 1350, 1200 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1350, 1200, 1350, 1200 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "XMax", "YMax" },
                values: new object[] { 150, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 300, 150, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 450, 300, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 150, 1650, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 300, 150, 1650, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 450, 300, 1650, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 150, 1800, 1650 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 300, 150, 1800, 1650 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 450, 300, 1800, 1650 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 600, 450, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 750, 600, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 900, 750, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 600, 450, 1650, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 750, 600, 1650, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 900, 750, 1650, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 600, 450, 1800, 1650 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 750, 600, 1800, 1650 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 900, 750, 1800, 1650 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1050, 900, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1200, 1050, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1350, 1200, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1050, 900, 1650, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1200, 1050, 1650, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1350, 1200, 1650, 1500 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1050, 900, 1800, 1650 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1200, 1050, 1800, 1650 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1350, 1200, 1800, 1650 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "XMax", "YMax" },
                values: new object[] { 150, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 300, 150, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 450, 300, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 150, 2100, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 300, 150, 2100, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 450, 300, 2100, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 150, 2250, 2100 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 300, 150, 2250, 2100 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 450, 300, 2250, 2100 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 600, 450, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 750, 600, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 900, 750, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 600, 450, 2100, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 750, 600, 2100, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 900, 750, 2100, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 600, 450, 2250, 2100 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 750, 600, 2250, 2100 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 900, 750, 2250, 2100 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1050, 900, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1200, 1050, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1350, 1200, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1050, 900, 2100, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1200, 1050, 2100, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1350, 1200, 2100, 1950 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1050, 900, 2250, 2100 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1200, 1050, 2250, 2100 });

            migrationBuilder.UpdateData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1350, 1200, 2250, 2100 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "XMax", "YMax" },
                values: new object[] { 450, 450 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 900, 450, 450 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "XMax", "XMin", "YMax" },
                values: new object[] { 1350, 900, 450 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 450, 900, 450 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 900, 450, 900, 450 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1350, 900, 900, 450 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 450, 1350, 900 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 900, 450, 1350, 900 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1350, 900, 1350, 900 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 450, 1800, 1350 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 900, 450, 1800, 1350 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1350, 900, 1800, 1350 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "XMax", "YMax", "YMin" },
                values: new object[] { 450, 2250, 1800 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 900, 450, 2250, 1800 });

            migrationBuilder.UpdateData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "XMax", "XMin", "YMax", "YMin" },
                values: new object[] { 1350, 900, 2250, 1800 });
        }
    }
}
