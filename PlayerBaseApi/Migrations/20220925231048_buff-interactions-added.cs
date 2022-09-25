using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class buffinteractionsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LootBluePrintChance",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "LootGemChance",
                table: "Buff");

            migrationBuilder.RenameColumn(
                name: "ScrapCount",
                table: "LootLevel",
                newName: "MinScrapCount");

            migrationBuilder.RenameColumn(
                name: "GemCount",
                table: "LootLevel",
                newName: "MinGemCount");

            migrationBuilder.RenameColumn(
                name: "BlueprintCount",
                table: "LootLevel",
                newName: "MinBlueprintCount");

            migrationBuilder.RenameColumn(
                name: "LootScrapChance",
                table: "Buff",
                newName: "LootPerfectRunMultiplier");

            migrationBuilder.AddColumn<string>(
                name: "GainedResources",
                table: "PlayerHeroLoot",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PlayerHeroLoot",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxBlueprintCount",
                table: "LootLevel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxGemCount",
                table: "LootLevel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxScrapCount",
                table: "LootLevel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 1, 1, 10, 1 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 3, 2, 30, 2 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 4, 3, 40, 3 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 6, 4, 60, 4 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 7, 6, 70, 5 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 9, 7, 90, 6 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 10, 8, 100, 7 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 12, 9, 120, 8 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 13, 10, 130, 9 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 15, 12, 150, 10 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 16, 13, 160, 11 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 18, 14, 180, 12 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 19, 15, 190, 13 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 21, 16, 210, 14 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 22, 18, 220, 15 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 24, 19, 240, 16 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 25, 20, 250, 17 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 27, 21, 270, 18 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 28, 22, 280, 19 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 30, 24, 300, 20 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 31, 25, 310, 21 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 33, 26, 330, 22 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 34, 27, 340, 23 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 36, 28, 360, 24 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 37, 30, 370, 25 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 39, 31, 390, 26 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 40, 32, 400, 27 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 42, 33, 420, 28 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 43, 34, 430, 29 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 45, 36, 450, 30 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 46, 37, 460, 31 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 48, 38, 480, 32 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 49, 39, 490, 33 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 51, 40, 510, 34 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 52, 42, 520, 35 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 54, 43, 540, 36 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 55, 44, 550, 37 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 57, 45, 570, 38 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 58, 46, 580, 39 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 60, 48, 600, 40 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 61, 49, 610, 41 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 63, 50, 630, 42 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 64, 51, 640, 43 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 66, 52, 660, 44 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 67, 54, 670, 45 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 69, 55, 690, 46 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 70, 56, 700, 47 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 72, 57, 720, 48 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 73, 58, 730, 49 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 75, 60, 750, 50 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 76, 61, 760, 51 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 78, 62, 780, 52 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 79, 63, 790, 53 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 81, 64, 810, 54 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 82, 66, 820, 55 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 84, 67, 840, 56 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 85, 68, 850, 57 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 87, 69, 870, 58 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 88, 70, 880, 59 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 90, 72, 900, 60 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 91, 73, 910, 61 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 93, 74, 930, 62 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 94, 75, 940, 63 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 96, 76, 960, 64 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 97, 78, 970, 65 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 99, 79, 990, 66 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 100, 80, 1000, 67 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 102, 81, 1020, 68 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 103, 82, 1030, 69 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 105, 84, 1050, 70 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 106, 85, 1060, 71 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 108, 86, 1080, 72 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 109, 87, 1090, 73 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 111, 88, 1110, 74 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 112, 90, 1120, 75 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 114, 91, 1140, 76 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 115, 92, 1150, 77 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 117, 93, 1170, 78 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 118, 94, 1180, 79 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 120, 96, 1200, 80 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 121, 97, 1210, 81 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 123, 98, 1230, 82 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 124, 99, 1240, 83 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 126, 100, 1260, 84 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 127, 102, 1270, 85 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 129, 103, 1290, 86 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 130, 104, 1300, 87 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 132, 105, 1320, 88 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 133, 106, 1330, 89 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 135, 108, 1350, 90 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 136, 109, 1360, 91 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 138, 110, 1380, 92 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 139, 111, 1390, 93 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 141, 112, 1410, 94 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 142, 114, 1420, 95 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 144, 115, 1440, 96 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 145, 116, 1450, 97 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 147, 117, 1470, 98 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 148, 118, 1480, 99 });

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "MaxBlueprintCount", "MaxGemCount", "MaxScrapCount", "MinScrapCount" },
                values: new object[] { 150, 120, 1500, 100 });

            migrationBuilder.CreateIndex(
                name: "IX_ResearchNode_BuffId",
                table: "ResearchNode",
                column: "BuffId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroSkillLevel_BuffId",
                table: "HeroSkillLevel",
                column: "BuffId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroSkillLevel_Buff_BuffId",
                table: "HeroSkillLevel",
                column: "BuffId",
                principalTable: "Buff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchNode_Buff_BuffId",
                table: "ResearchNode",
                column: "BuffId",
                principalTable: "Buff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroSkillLevel_Buff_BuffId",
                table: "HeroSkillLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_ResearchNode_Buff_BuffId",
                table: "ResearchNode");

            migrationBuilder.DropIndex(
                name: "IX_ResearchNode_BuffId",
                table: "ResearchNode");

            migrationBuilder.DropIndex(
                name: "IX_HeroSkillLevel_BuffId",
                table: "HeroSkillLevel");

            migrationBuilder.DropColumn(
                name: "GainedResources",
                table: "PlayerHeroLoot");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PlayerHeroLoot");

            migrationBuilder.DropColumn(
                name: "MaxBlueprintCount",
                table: "LootLevel");

            migrationBuilder.DropColumn(
                name: "MaxGemCount",
                table: "LootLevel");

            migrationBuilder.DropColumn(
                name: "MaxScrapCount",
                table: "LootLevel");

            migrationBuilder.RenameColumn(
                name: "MinScrapCount",
                table: "LootLevel",
                newName: "ScrapCount");

            migrationBuilder.RenameColumn(
                name: "MinGemCount",
                table: "LootLevel",
                newName: "GemCount");

            migrationBuilder.RenameColumn(
                name: "MinBlueprintCount",
                table: "LootLevel",
                newName: "BlueprintCount");

            migrationBuilder.RenameColumn(
                name: "LootPerfectRunMultiplier",
                table: "Buff",
                newName: "LootScrapChance");

            migrationBuilder.AddColumn<double>(
                name: "LootBluePrintChance",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LootGemChance",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 1,
                column: "ScrapCount",
                value: 10);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 2,
                column: "ScrapCount",
                value: 20);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 3,
                column: "ScrapCount",
                value: 30);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 4,
                column: "ScrapCount",
                value: 40);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 5,
                column: "ScrapCount",
                value: 50);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 6,
                column: "ScrapCount",
                value: 60);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 7,
                column: "ScrapCount",
                value: 70);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 8,
                column: "ScrapCount",
                value: 80);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 9,
                column: "ScrapCount",
                value: 90);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 10,
                column: "ScrapCount",
                value: 100);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 11,
                column: "ScrapCount",
                value: 110);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 12,
                column: "ScrapCount",
                value: 120);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 13,
                column: "ScrapCount",
                value: 130);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 14,
                column: "ScrapCount",
                value: 140);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 15,
                column: "ScrapCount",
                value: 150);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 16,
                column: "ScrapCount",
                value: 160);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 17,
                column: "ScrapCount",
                value: 170);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 18,
                column: "ScrapCount",
                value: 180);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 19,
                column: "ScrapCount",
                value: 190);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 20,
                column: "ScrapCount",
                value: 200);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 21,
                column: "ScrapCount",
                value: 210);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 22,
                column: "ScrapCount",
                value: 220);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 23,
                column: "ScrapCount",
                value: 230);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 24,
                column: "ScrapCount",
                value: 240);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 25,
                column: "ScrapCount",
                value: 250);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 26,
                column: "ScrapCount",
                value: 260);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 27,
                column: "ScrapCount",
                value: 270);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 28,
                column: "ScrapCount",
                value: 280);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 29,
                column: "ScrapCount",
                value: 290);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 30,
                column: "ScrapCount",
                value: 300);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 31,
                column: "ScrapCount",
                value: 310);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 32,
                column: "ScrapCount",
                value: 320);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 33,
                column: "ScrapCount",
                value: 330);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 34,
                column: "ScrapCount",
                value: 340);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 35,
                column: "ScrapCount",
                value: 350);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 36,
                column: "ScrapCount",
                value: 360);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 37,
                column: "ScrapCount",
                value: 370);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 38,
                column: "ScrapCount",
                value: 380);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 39,
                column: "ScrapCount",
                value: 390);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 40,
                column: "ScrapCount",
                value: 400);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 41,
                column: "ScrapCount",
                value: 410);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 42,
                column: "ScrapCount",
                value: 420);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 43,
                column: "ScrapCount",
                value: 430);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 44,
                column: "ScrapCount",
                value: 440);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 45,
                column: "ScrapCount",
                value: 450);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 46,
                column: "ScrapCount",
                value: 460);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 47,
                column: "ScrapCount",
                value: 470);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 48,
                column: "ScrapCount",
                value: 480);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 49,
                column: "ScrapCount",
                value: 490);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 50,
                column: "ScrapCount",
                value: 500);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 51,
                column: "ScrapCount",
                value: 510);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 52,
                column: "ScrapCount",
                value: 520);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 53,
                column: "ScrapCount",
                value: 530);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 54,
                column: "ScrapCount",
                value: 540);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 55,
                column: "ScrapCount",
                value: 550);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 56,
                column: "ScrapCount",
                value: 560);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 57,
                column: "ScrapCount",
                value: 570);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 58,
                column: "ScrapCount",
                value: 580);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 59,
                column: "ScrapCount",
                value: 590);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 60,
                column: "ScrapCount",
                value: 600);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 61,
                column: "ScrapCount",
                value: 610);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 62,
                column: "ScrapCount",
                value: 620);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 63,
                column: "ScrapCount",
                value: 630);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 64,
                column: "ScrapCount",
                value: 640);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 65,
                column: "ScrapCount",
                value: 650);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 66,
                column: "ScrapCount",
                value: 660);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 67,
                column: "ScrapCount",
                value: 670);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 68,
                column: "ScrapCount",
                value: 680);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 69,
                column: "ScrapCount",
                value: 690);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 70,
                column: "ScrapCount",
                value: 700);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 71,
                column: "ScrapCount",
                value: 710);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 72,
                column: "ScrapCount",
                value: 720);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 73,
                column: "ScrapCount",
                value: 730);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 74,
                column: "ScrapCount",
                value: 740);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 75,
                column: "ScrapCount",
                value: 750);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 76,
                column: "ScrapCount",
                value: 760);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 77,
                column: "ScrapCount",
                value: 770);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 78,
                column: "ScrapCount",
                value: 780);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 79,
                column: "ScrapCount",
                value: 790);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 80,
                column: "ScrapCount",
                value: 800);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 81,
                column: "ScrapCount",
                value: 810);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 82,
                column: "ScrapCount",
                value: 820);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 83,
                column: "ScrapCount",
                value: 830);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 84,
                column: "ScrapCount",
                value: 840);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 85,
                column: "ScrapCount",
                value: 850);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 86,
                column: "ScrapCount",
                value: 860);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 87,
                column: "ScrapCount",
                value: 870);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 88,
                column: "ScrapCount",
                value: 880);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 89,
                column: "ScrapCount",
                value: 890);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 90,
                column: "ScrapCount",
                value: 900);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 91,
                column: "ScrapCount",
                value: 910);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 92,
                column: "ScrapCount",
                value: 920);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 93,
                column: "ScrapCount",
                value: 930);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 94,
                column: "ScrapCount",
                value: 940);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 95,
                column: "ScrapCount",
                value: 950);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 96,
                column: "ScrapCount",
                value: 960);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 97,
                column: "ScrapCount",
                value: 970);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 98,
                column: "ScrapCount",
                value: 980);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 99,
                column: "ScrapCount",
                value: 990);

            migrationBuilder.UpdateData(
                table: "LootLevel",
                keyColumn: "Id",
                keyValue: 100,
                column: "ScrapCount",
                value: 1000);
        }
    }
}
