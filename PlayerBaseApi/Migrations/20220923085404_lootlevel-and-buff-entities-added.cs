using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class lootlevelandbuffentitiesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuffId",
                table: "HeroLevelThreshold",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Buff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LootGemChance = table.Column<double>(type: "double precision", nullable: false),
                    LootBluePrintChance = table.Column<double>(type: "double precision", nullable: false),
                    LootScrapChance = table.Column<double>(type: "double precision", nullable: false),
                    LootGemMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    LootBluePrintMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    LootScrapMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    LootDurationMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    LootCapacity = table.Column<double>(type: "double precision", nullable: false),
                    PrisonCapacityMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    PrisonCostMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    PrisonTrainingCostMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    PrisonTrainingDurationMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    PrisonExecutionEarnMultiplier = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LootLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScrapCount = table.Column<int>(type: "integer", nullable: false),
                    BlueprintCount = table.Column<int>(type: "integer", nullable: false),
                    GemCount = table.Column<int>(type: "integer", nullable: false),
                    LootDuration = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LootLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerHeroLoot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerHeroId = table.Column<int>(type: "integer", nullable: false),
                    LootLevelId = table.Column<int>(type: "integer", nullable: false),
                    OperationEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerHeroLoot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerHeroLoot_LootLevel_LootLevelId",
                        column: x => x.LootLevelId,
                        principalTable: "LootLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerHeroLoot_PlayerHero_PlayerHeroId",
                        column: x => x.PlayerHeroId,
                        principalTable: "PlayerHero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buff",
                columns: new[] { "Id", "Description", "LootBluePrintChance", "LootBluePrintMultiplier", "LootCapacity", "LootDurationMultiplier", "LootGemChance", "LootGemMultiplier", "LootScrapChance", "LootScrapMultiplier", "Name", "PrisonCapacityMultiplier", "PrisonCostMultiplier", "PrisonExecutionEarnMultiplier", "PrisonTrainingCostMultiplier", "PrisonTrainingDurationMultiplier" },
                values: new object[] { 1, "", 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, "0-Buff", 0.0, 0.0, 0.0, 0.0, 0.0 });

            migrationBuilder.InsertData(
                table: "LootLevel",
                columns: new[] { "Id", "BlueprintCount", "GemCount", "LootDuration", "ScrapCount" },
                values: new object[,]
                {
                    { 1, 1, 1, new TimeSpan(0, 0, 0, 30, 0), 10 },
                    { 2, 2, 2, new TimeSpan(0, 0, 1, 0, 0), 20 },
                    { 3, 3, 3, new TimeSpan(0, 0, 1, 30, 0), 30 },
                    { 4, 4, 4, new TimeSpan(0, 0, 2, 0, 0), 40 },
                    { 5, 5, 5, new TimeSpan(0, 0, 2, 30, 0), 50 },
                    { 6, 6, 6, new TimeSpan(0, 0, 3, 0, 0), 60 },
                    { 7, 7, 7, new TimeSpan(0, 0, 3, 30, 0), 70 },
                    { 8, 8, 8, new TimeSpan(0, 0, 4, 0, 0), 80 },
                    { 9, 9, 9, new TimeSpan(0, 0, 4, 30, 0), 90 },
                    { 10, 10, 10, new TimeSpan(0, 0, 5, 0, 0), 100 },
                    { 11, 11, 11, new TimeSpan(0, 0, 5, 30, 0), 110 },
                    { 12, 12, 12, new TimeSpan(0, 0, 6, 0, 0), 120 },
                    { 13, 13, 13, new TimeSpan(0, 0, 6, 30, 0), 130 },
                    { 14, 14, 14, new TimeSpan(0, 0, 7, 0, 0), 140 },
                    { 15, 15, 15, new TimeSpan(0, 0, 7, 30, 0), 150 },
                    { 16, 16, 16, new TimeSpan(0, 0, 8, 0, 0), 160 },
                    { 17, 17, 17, new TimeSpan(0, 0, 8, 30, 0), 170 },
                    { 18, 18, 18, new TimeSpan(0, 0, 9, 0, 0), 180 },
                    { 19, 19, 19, new TimeSpan(0, 0, 9, 30, 0), 190 },
                    { 20, 20, 20, new TimeSpan(0, 0, 10, 0, 0), 200 },
                    { 21, 21, 21, new TimeSpan(0, 0, 10, 30, 0), 210 },
                    { 22, 22, 22, new TimeSpan(0, 0, 11, 0, 0), 220 },
                    { 23, 23, 23, new TimeSpan(0, 0, 11, 30, 0), 230 },
                    { 24, 24, 24, new TimeSpan(0, 0, 12, 0, 0), 240 },
                    { 25, 25, 25, new TimeSpan(0, 0, 12, 30, 0), 250 },
                    { 26, 26, 26, new TimeSpan(0, 0, 13, 0, 0), 260 },
                    { 27, 27, 27, new TimeSpan(0, 0, 13, 30, 0), 270 },
                    { 28, 28, 28, new TimeSpan(0, 0, 14, 0, 0), 280 },
                    { 29, 29, 29, new TimeSpan(0, 0, 14, 30, 0), 290 },
                    { 30, 30, 30, new TimeSpan(0, 0, 15, 0, 0), 300 },
                    { 31, 31, 31, new TimeSpan(0, 0, 15, 30, 0), 310 },
                    { 32, 32, 32, new TimeSpan(0, 0, 16, 0, 0), 320 },
                    { 33, 33, 33, new TimeSpan(0, 0, 16, 30, 0), 330 },
                    { 34, 34, 34, new TimeSpan(0, 0, 17, 0, 0), 340 },
                    { 35, 35, 35, new TimeSpan(0, 0, 17, 30, 0), 350 },
                    { 36, 36, 36, new TimeSpan(0, 0, 18, 0, 0), 360 },
                    { 37, 37, 37, new TimeSpan(0, 0, 18, 30, 0), 370 },
                    { 38, 38, 38, new TimeSpan(0, 0, 19, 0, 0), 380 },
                    { 39, 39, 39, new TimeSpan(0, 0, 19, 30, 0), 390 },
                    { 40, 40, 40, new TimeSpan(0, 0, 20, 0, 0), 400 },
                    { 41, 41, 41, new TimeSpan(0, 0, 20, 30, 0), 410 },
                    { 42, 42, 42, new TimeSpan(0, 0, 21, 0, 0), 420 },
                    { 43, 43, 43, new TimeSpan(0, 0, 21, 30, 0), 430 },
                    { 44, 44, 44, new TimeSpan(0, 0, 22, 0, 0), 440 },
                    { 45, 45, 45, new TimeSpan(0, 0, 22, 30, 0), 450 },
                    { 46, 46, 46, new TimeSpan(0, 0, 23, 0, 0), 460 },
                    { 47, 47, 47, new TimeSpan(0, 0, 23, 30, 0), 470 },
                    { 48, 48, 48, new TimeSpan(0, 0, 24, 0, 0), 480 },
                    { 49, 49, 49, new TimeSpan(0, 0, 24, 30, 0), 490 },
                    { 50, 50, 50, new TimeSpan(0, 0, 25, 0, 0), 500 },
                    { 51, 51, 51, new TimeSpan(0, 0, 25, 30, 0), 510 },
                    { 52, 52, 52, new TimeSpan(0, 0, 26, 0, 0), 520 },
                    { 53, 53, 53, new TimeSpan(0, 0, 26, 30, 0), 530 },
                    { 54, 54, 54, new TimeSpan(0, 0, 27, 0, 0), 540 },
                    { 55, 55, 55, new TimeSpan(0, 0, 27, 30, 0), 550 },
                    { 56, 56, 56, new TimeSpan(0, 0, 28, 0, 0), 560 },
                    { 57, 57, 57, new TimeSpan(0, 0, 28, 30, 0), 570 },
                    { 58, 58, 58, new TimeSpan(0, 0, 29, 0, 0), 580 },
                    { 59, 59, 59, new TimeSpan(0, 0, 29, 30, 0), 590 },
                    { 60, 60, 60, new TimeSpan(0, 0, 30, 0, 0), 600 },
                    { 61, 61, 61, new TimeSpan(0, 0, 30, 30, 0), 610 },
                    { 62, 62, 62, new TimeSpan(0, 0, 31, 0, 0), 620 },
                    { 63, 63, 63, new TimeSpan(0, 0, 31, 30, 0), 630 },
                    { 64, 64, 64, new TimeSpan(0, 0, 32, 0, 0), 640 },
                    { 65, 65, 65, new TimeSpan(0, 0, 32, 30, 0), 650 },
                    { 66, 66, 66, new TimeSpan(0, 0, 33, 0, 0), 660 },
                    { 67, 67, 67, new TimeSpan(0, 0, 33, 30, 0), 670 },
                    { 68, 68, 68, new TimeSpan(0, 0, 34, 0, 0), 680 },
                    { 69, 69, 69, new TimeSpan(0, 0, 34, 30, 0), 690 },
                    { 70, 70, 70, new TimeSpan(0, 0, 35, 0, 0), 700 },
                    { 71, 71, 71, new TimeSpan(0, 0, 35, 30, 0), 710 },
                    { 72, 72, 72, new TimeSpan(0, 0, 36, 0, 0), 720 },
                    { 73, 73, 73, new TimeSpan(0, 0, 36, 30, 0), 730 },
                    { 74, 74, 74, new TimeSpan(0, 0, 37, 0, 0), 740 },
                    { 75, 75, 75, new TimeSpan(0, 0, 37, 30, 0), 750 },
                    { 76, 76, 76, new TimeSpan(0, 0, 38, 0, 0), 760 },
                    { 77, 77, 77, new TimeSpan(0, 0, 38, 30, 0), 770 },
                    { 78, 78, 78, new TimeSpan(0, 0, 39, 0, 0), 780 },
                    { 79, 79, 79, new TimeSpan(0, 0, 39, 30, 0), 790 },
                    { 80, 80, 80, new TimeSpan(0, 0, 40, 0, 0), 800 },
                    { 81, 81, 81, new TimeSpan(0, 0, 40, 30, 0), 810 },
                    { 82, 82, 82, new TimeSpan(0, 0, 41, 0, 0), 820 },
                    { 83, 83, 83, new TimeSpan(0, 0, 41, 30, 0), 830 },
                    { 84, 84, 84, new TimeSpan(0, 0, 42, 0, 0), 840 },
                    { 85, 85, 85, new TimeSpan(0, 0, 42, 30, 0), 850 },
                    { 86, 86, 86, new TimeSpan(0, 0, 43, 0, 0), 860 },
                    { 87, 87, 87, new TimeSpan(0, 0, 43, 30, 0), 870 },
                    { 88, 88, 88, new TimeSpan(0, 0, 44, 0, 0), 880 },
                    { 89, 89, 89, new TimeSpan(0, 0, 44, 30, 0), 890 },
                    { 90, 90, 90, new TimeSpan(0, 0, 45, 0, 0), 900 },
                    { 91, 91, 91, new TimeSpan(0, 0, 45, 30, 0), 910 },
                    { 92, 92, 92, new TimeSpan(0, 0, 46, 0, 0), 920 },
                    { 93, 93, 93, new TimeSpan(0, 0, 46, 30, 0), 930 },
                    { 94, 94, 94, new TimeSpan(0, 0, 47, 0, 0), 940 },
                    { 95, 95, 95, new TimeSpan(0, 0, 47, 30, 0), 950 },
                    { 96, 96, 96, new TimeSpan(0, 0, 48, 0, 0), 960 },
                    { 97, 97, 97, new TimeSpan(0, 0, 48, 30, 0), 970 },
                    { 98, 98, 98, new TimeSpan(0, 0, 49, 0, 0), 980 },
                    { 99, 99, 99, new TimeSpan(0, 0, 49, 30, 0), 990 },
                    { 100, 100, 100, new TimeSpan(0, 0, 50, 0, 0), 1000 }
                });

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 1,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 2,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 3,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 4,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 5,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 6,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 7,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 8,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 9,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 10,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 11,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 12,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 13,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 14,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 15,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 16,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 17,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 18,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 19,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 20,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 21,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 22,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 23,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 24,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 25,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 26,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 27,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 28,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 29,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 30,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 31,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 32,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 33,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 34,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 35,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 36,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 37,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 38,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 39,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 40,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 41,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 42,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 43,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 44,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 45,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 46,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 47,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 48,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 49,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 50,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 51,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 52,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 53,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 54,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 55,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 56,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 57,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 58,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 59,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 60,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 61,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 62,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 63,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 64,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 65,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 66,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 67,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 68,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 69,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 70,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 71,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 72,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 73,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 74,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 75,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 76,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 77,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 78,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 79,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 80,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 81,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 82,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 83,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 84,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 85,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 86,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 87,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 88,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 89,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 90,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 91,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 92,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 93,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 94,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 95,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 96,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 97,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 98,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 99,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 100,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 101,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 102,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 103,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 104,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 105,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 106,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 107,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 108,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 109,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 110,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 111,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 112,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 113,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 114,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 115,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 116,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 117,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 118,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 119,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 120,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 121,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 122,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 123,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 124,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 125,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 126,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 127,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 128,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 129,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 130,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 131,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 132,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 133,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 134,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 135,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 136,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 137,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 138,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 139,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 140,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 141,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 142,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 143,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 144,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 145,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 146,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 147,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 148,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 149,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 150,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 151,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 152,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 153,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 154,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 155,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 156,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 157,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 158,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 159,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 160,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 161,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 162,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 163,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 164,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 165,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 166,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 167,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 168,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 169,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 170,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 171,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 172,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 173,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 174,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 175,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 176,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 177,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 178,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 179,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 180,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 181,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 182,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 183,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 184,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 185,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 186,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 187,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 188,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 189,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 190,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 191,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 192,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 193,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 194,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 195,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 196,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 197,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 198,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 199,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 200,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 201,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 202,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 203,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 204,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 205,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 206,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 207,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 208,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 209,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 210,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 211,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 212,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 213,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 214,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 215,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 216,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 217,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 218,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 219,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 220,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 221,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 222,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 223,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 224,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 225,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 226,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 227,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 228,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 229,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 230,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 231,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 232,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 233,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 234,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 235,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 236,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 237,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 238,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 239,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 240,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 241,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 242,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 243,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 244,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 245,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 246,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 247,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 248,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 249,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 250,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 251,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 252,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 253,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 254,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 255,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 256,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 257,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 258,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 259,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 260,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 261,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 262,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 263,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 264,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 265,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 266,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 267,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 268,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 269,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 270,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 271,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 272,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 273,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 274,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 275,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 276,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 277,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 278,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 279,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 280,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 281,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 282,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 283,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 284,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 285,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 286,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 287,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 288,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 289,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 290,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 291,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 292,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 293,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 294,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 295,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 296,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 297,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 298,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 299,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 300,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 301,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 302,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 303,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 304,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 305,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 306,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 307,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 308,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 309,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 310,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 311,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 312,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 313,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 314,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 315,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 316,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 317,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 318,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 319,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 320,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 321,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 322,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 323,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 324,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 325,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 326,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 327,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 328,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 329,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 330,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 331,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 332,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 333,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 334,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 335,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 336,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 337,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 338,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 339,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 340,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 341,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 342,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 343,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 344,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 345,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 346,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 347,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 348,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 349,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 350,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 351,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 352,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 353,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 354,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 355,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 356,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 357,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 358,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 359,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 360,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 361,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 362,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 363,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 364,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 365,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 366,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 367,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 368,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 369,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 370,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 371,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 372,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 373,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 374,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 375,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 376,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 377,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 378,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 379,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 380,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 381,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 382,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 383,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 384,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 385,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 386,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 387,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 388,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 389,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 390,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 391,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 392,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 393,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 394,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 395,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 396,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 397,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 398,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 399,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 400,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 401,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 402,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 403,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 404,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 405,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 406,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 407,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 408,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 409,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 410,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 411,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 412,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 413,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 414,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 415,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 416,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 417,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 418,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 419,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 420,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 421,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 422,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 423,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 424,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 425,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 426,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 427,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 428,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 429,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 430,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 431,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 432,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 433,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 434,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 435,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 436,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 437,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 438,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 439,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 440,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 441,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 442,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 443,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 444,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 445,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 446,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 447,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 448,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 449,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 450,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 451,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 452,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 453,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 454,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 455,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 456,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 457,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 458,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 459,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 460,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 461,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 462,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 463,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 464,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 465,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 466,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 467,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 468,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 469,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 470,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 471,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 472,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 473,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 474,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 475,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 476,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 477,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 478,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 479,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 480,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 481,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 482,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 483,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 484,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 485,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 486,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 487,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 488,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 489,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 490,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 491,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 492,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 493,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 494,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 495,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 496,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 497,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 498,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 499,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 500,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 501,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 502,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 503,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 504,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 505,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 506,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 507,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 508,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 509,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 510,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 511,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 512,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 513,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 514,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 515,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 516,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 517,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 518,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 519,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 520,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 521,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 522,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 523,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 524,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 525,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 526,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 527,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 528,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 529,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 530,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 531,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 532,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 533,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 534,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 535,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 536,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 537,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 538,
                column: "BuffId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HeroLevelThreshold",
                keyColumn: "Id",
                keyValue: 539,
                column: "BuffId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_HeroLevelThreshold_BuffId",
                table: "HeroLevelThreshold",
                column: "BuffId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerHeroLoot_LootLevelId",
                table: "PlayerHeroLoot",
                column: "LootLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerHeroLoot_PlayerHeroId",
                table: "PlayerHeroLoot",
                column: "PlayerHeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroLevelThreshold_Buff_BuffId",
                table: "HeroLevelThreshold",
                column: "BuffId",
                principalTable: "Buff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroLevelThreshold_Buff_BuffId",
                table: "HeroLevelThreshold");

            migrationBuilder.DropTable(
                name: "Buff");

            migrationBuilder.DropTable(
                name: "PlayerHeroLoot");

            migrationBuilder.DropTable(
                name: "LootLevel");

            migrationBuilder.DropIndex(
                name: "IX_HeroLevelThreshold_BuffId",
                table: "HeroLevelThreshold");

            migrationBuilder.DropColumn(
                name: "BuffId",
                table: "HeroLevelThreshold");
        }
    }
}
