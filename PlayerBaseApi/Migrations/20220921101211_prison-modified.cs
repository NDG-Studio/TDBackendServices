using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class prisonmodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameConfig");

            migrationBuilder.DropColumn(
                name: "LastCollectDate",
                table: "PlayerPrison");

            migrationBuilder.AddColumn<int>(
                name: "InTrainingPrisonerCount",
                table: "PlayerPrison",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrisonLevelId",
                table: "PlayerPrison",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "TrainingDoneDate",
                table: "PlayerPrison",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PrisonLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    TrainingDurationPerUnit = table.Column<TimeSpan>(type: "interval", nullable: false),
                    TrainingCostPerUnit = table.Column<double>(type: "double precision", nullable: false),
                    ExecutionEarnPerUnit = table.Column<double>(type: "double precision", nullable: false),
                    MaxPrisonerCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrisonLevel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BuildingType",
                columns: new[] { "Id", "BuildUrl", "IsActive", "MaxLevel", "Name" },
                values: new object[] { 10, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", true, 1000, "Military Base" });

            migrationBuilder.InsertData(
                table: "PrisonLevel",
                columns: new[] { "Id", "ExecutionEarnPerUnit", "Level", "MaxPrisonerCount", "TrainingCostPerUnit", "TrainingDurationPerUnit" },
                values: new object[,]
                {
                    { 1, 1.2, 1, 4, 100.0, new TimeSpan(0, 0, 10, 0, 0) },
                    { 2, 2.3999999999999999, 2, 8, 50.0, new TimeSpan(0, 0, 5, 0, 0) },
                    { 3, 3.5999999999999996, 3, 12, 33.0, new TimeSpan(0, 0, 3, 20, 0) },
                    { 4, 4.7999999999999998, 4, 16, 25.0, new TimeSpan(0, 0, 2, 30, 0) },
                    { 5, 6.0, 5, 20, 20.0, new TimeSpan(0, 0, 2, 0, 0) },
                    { 6, 7.1999999999999993, 6, 24, 16.0, new TimeSpan(0, 0, 1, 40, 0) },
                    { 7, 8.4000000000000004, 7, 28, 14.0, new TimeSpan(857142857) },
                    { 8, 9.5999999999999996, 8, 32, 12.0, new TimeSpan(0, 0, 1, 15, 0) },
                    { 9, 10.799999999999999, 9, 36, 11.0, new TimeSpan(666666666) },
                    { 10, 12.0, 10, 40, 10.0, new TimeSpan(0, 0, 1, 0, 0) },
                    { 11, 13.199999999999999, 11, 44, 9.0, new TimeSpan(545454545) },
                    { 12, 14.399999999999999, 12, 48, 8.0, new TimeSpan(0, 0, 0, 50, 0) },
                    { 13, 15.6, 13, 52, 7.0, new TimeSpan(461538461) },
                    { 14, 16.800000000000001, 14, 56, 7.0, new TimeSpan(428571428) },
                    { 15, 18.0, 15, 60, 6.0, new TimeSpan(0, 0, 0, 40, 0) },
                    { 16, 19.199999999999999, 16, 64, 6.0, new TimeSpan(0, 0, 0, 37, 500) },
                    { 17, 20.399999999999999, 17, 68, 5.0, new TimeSpan(352941176) },
                    { 18, 21.599999999999998, 18, 72, 5.0, new TimeSpan(333333333) },
                    { 19, 22.800000000000001, 19, 76, 5.0, new TimeSpan(315789473) },
                    { 20, 24.0, 20, 80, 5.0, new TimeSpan(0, 0, 0, 30, 0) },
                    { 21, 25.199999999999999, 21, 84, 4.0, new TimeSpan(285714285) },
                    { 22, 26.399999999999999, 22, 88, 4.0, new TimeSpan(272727272) },
                    { 23, 27.599999999999998, 23, 92, 4.0, new TimeSpan(260869565) },
                    { 24, 28.799999999999997, 24, 96, 4.0, new TimeSpan(0, 0, 0, 25, 0) },
                    { 25, 30.0, 25, 100, 4.0, new TimeSpan(0, 0, 0, 24, 0) },
                    { 26, 31.199999999999999, 26, 104, 3.0, new TimeSpan(230769230) },
                    { 27, 32.399999999999999, 27, 108, 3.0, new TimeSpan(222222222) },
                    { 28, 33.600000000000001, 28, 112, 3.0, new TimeSpan(214285714) },
                    { 29, 34.799999999999997, 29, 116, 3.0, new TimeSpan(206896551) },
                    { 30, 36.0, 30, 120, 3.0, new TimeSpan(0, 0, 0, 20, 0) },
                    { 31, 37.199999999999996, 31, 124, 3.0, new TimeSpan(193548387) },
                    { 32, 38.399999999999999, 32, 128, 3.0, new TimeSpan(0, 0, 0, 18, 750) },
                    { 33, 39.600000000000001, 33, 132, 3.0, new TimeSpan(181818181) },
                    { 34, 40.799999999999997, 34, 136, 2.0, new TimeSpan(176470588) },
                    { 35, 42.0, 35, 140, 2.0, new TimeSpan(171428571) },
                    { 36, 43.199999999999996, 36, 144, 2.0, new TimeSpan(166666666) },
                    { 37, 44.399999999999999, 37, 148, 2.0, new TimeSpan(162162162) },
                    { 38, 45.600000000000001, 38, 152, 2.0, new TimeSpan(157894736) },
                    { 39, 46.799999999999997, 39, 156, 2.0, new TimeSpan(153846153) },
                    { 40, 48.0, 40, 160, 2.0, new TimeSpan(0, 0, 0, 15, 0) },
                    { 41, 49.199999999999996, 41, 164, 2.0, new TimeSpan(146341463) },
                    { 42, 50.399999999999999, 42, 168, 2.0, new TimeSpan(142857142) },
                    { 43, 51.600000000000001, 43, 172, 2.0, new TimeSpan(139534883) },
                    { 44, 52.799999999999997, 44, 176, 2.0, new TimeSpan(136363636) },
                    { 45, 54.0, 45, 180, 2.0, new TimeSpan(133333333) },
                    { 46, 55.199999999999996, 46, 184, 2.0, new TimeSpan(130434782) },
                    { 47, 56.399999999999999, 47, 188, 2.0, new TimeSpan(127659574) },
                    { 48, 57.599999999999994, 48, 192, 2.0, new TimeSpan(0, 0, 0, 12, 500) },
                    { 49, 58.799999999999997, 49, 196, 2.0, new TimeSpan(122448979) },
                    { 50, 60.0, 50, 200, 2.0, new TimeSpan(0, 0, 0, 12, 0) },
                    { 51, 61.199999999999996, 51, 204, 1.0, new TimeSpan(117647058) },
                    { 52, 62.399999999999999, 52, 208, 1.0, new TimeSpan(115384615) },
                    { 53, 63.599999999999994, 53, 212, 1.0, new TimeSpan(113207547) },
                    { 54, 64.799999999999997, 54, 216, 1.0, new TimeSpan(111111111) },
                    { 55, 66.0, 55, 220, 1.0, new TimeSpan(109090909) },
                    { 56, 67.200000000000003, 56, 224, 1.0, new TimeSpan(107142857) },
                    { 57, 68.399999999999991, 57, 228, 1.0, new TimeSpan(105263157) },
                    { 58, 69.599999999999994, 58, 232, 1.0, new TimeSpan(103448275) },
                    { 59, 70.799999999999997, 59, 236, 1.0, new TimeSpan(101694915) },
                    { 60, 72.0, 60, 240, 1.0, new TimeSpan(0, 0, 0, 10, 0) },
                    { 61, 73.200000000000003, 61, 244, 1.0, new TimeSpan(98360655) },
                    { 62, 74.399999999999991, 62, 248, 1.0, new TimeSpan(96774193) },
                    { 63, 75.599999999999994, 63, 252, 1.0, new TimeSpan(95238095) },
                    { 64, 76.799999999999997, 64, 256, 1.0, new TimeSpan(0, 0, 0, 9, 375) },
                    { 65, 78.0, 65, 260, 1.0, new TimeSpan(92307692) },
                    { 66, 79.200000000000003, 66, 264, 1.0, new TimeSpan(90909090) },
                    { 67, 80.399999999999991, 67, 268, 1.0, new TimeSpan(89552238) },
                    { 68, 81.599999999999994, 68, 272, 1.0, new TimeSpan(88235294) },
                    { 69, 82.799999999999997, 69, 276, 1.0, new TimeSpan(86956521) },
                    { 70, 84.0, 70, 280, 1.0, new TimeSpan(85714285) },
                    { 71, 85.200000000000003, 71, 284, 1.0, new TimeSpan(84507042) },
                    { 72, 86.399999999999991, 72, 288, 1.0, new TimeSpan(83333333) },
                    { 73, 87.599999999999994, 73, 292, 1.0, new TimeSpan(82191780) },
                    { 74, 88.799999999999997, 74, 296, 1.0, new TimeSpan(81081081) },
                    { 75, 90.0, 75, 300, 1.0, new TimeSpan(0, 0, 0, 8, 0) },
                    { 76, 91.200000000000003, 76, 304, 1.0, new TimeSpan(78947368) },
                    { 77, 92.399999999999991, 77, 308, 1.0, new TimeSpan(77922077) },
                    { 78, 93.599999999999994, 78, 312, 1.0, new TimeSpan(76923076) },
                    { 79, 94.799999999999997, 79, 316, 1.0, new TimeSpan(75949367) },
                    { 80, 96.0, 80, 320, 1.0, new TimeSpan(0, 0, 0, 7, 500) },
                    { 81, 97.200000000000003, 81, 324, 1.0, new TimeSpan(74074074) },
                    { 82, 98.399999999999991, 82, 328, 1.0, new TimeSpan(73170731) },
                    { 83, 99.599999999999994, 83, 332, 1.0, new TimeSpan(72289156) },
                    { 84, 100.8, 84, 336, 1.0, new TimeSpan(71428571) },
                    { 85, 102.0, 85, 340, 1.0, new TimeSpan(70588235) },
                    { 86, 103.2, 86, 344, 1.0, new TimeSpan(69767441) },
                    { 87, 104.39999999999999, 87, 348, 1.0, new TimeSpan(68965517) },
                    { 88, 105.59999999999999, 88, 352, 1.0, new TimeSpan(68181818) },
                    { 89, 106.8, 89, 356, 1.0, new TimeSpan(67415730) },
                    { 90, 108.0, 90, 360, 1.0, new TimeSpan(66666666) },
                    { 91, 109.2, 91, 364, 1.0, new TimeSpan(65934065) },
                    { 92, 110.39999999999999, 92, 368, 1.0, new TimeSpan(65217391) },
                    { 93, 111.59999999999999, 93, 372, 1.0, new TimeSpan(64516129) },
                    { 94, 112.8, 94, 376, 1.0, new TimeSpan(63829787) },
                    { 95, 114.0, 95, 380, 1.0, new TimeSpan(63157894) },
                    { 96, 115.19999999999999, 96, 384, 1.0, new TimeSpan(0, 0, 0, 6, 250) },
                    { 97, 116.39999999999999, 97, 388, 1.0, new TimeSpan(61855670) },
                    { 98, 117.59999999999999, 98, 392, 1.0, new TimeSpan(61224489) },
                    { 99, 118.8, 99, 396, 1.0, new TimeSpan(60606060) },
                    { 100, 120.0, 100, 400, 1.0, new TimeSpan(0, 0, 0, 6, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPrison_PrisonLevelId",
                table: "PlayerPrison",
                column: "PrisonLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPrison_PrisonLevel_PrisonLevelId",
                table: "PlayerPrison",
                column: "PrisonLevelId",
                principalTable: "PrisonLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPrison_PrisonLevel_PrisonLevelId",
                table: "PlayerPrison");

            migrationBuilder.DropTable(
                name: "PrisonLevel");

            migrationBuilder.DropIndex(
                name: "IX_PlayerPrison_PrisonLevelId",
                table: "PlayerPrison");

            migrationBuilder.DeleteData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "InTrainingPrisonerCount",
                table: "PlayerPrison");

            migrationBuilder.DropColumn(
                name: "PrisonLevelId",
                table: "PlayerPrison");

            migrationBuilder.DropColumn(
                name: "TrainingDoneDate",
                table: "PlayerPrison");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastCollectDate",
                table: "PlayerPrison",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "GameConfig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrisonerExecutionGainPerUnit = table.Column<double>(type: "double precision", nullable: false),
                    PrisonerMaxDuration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    PrisonerResorceDebuffPerHour = table.Column<double>(type: "double precision", nullable: false),
                    TroopProductionPerHour = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConfig", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GameConfig",
                columns: new[] { "Id", "PrisonerExecutionGainPerUnit", "PrisonerMaxDuration", "PrisonerResorceDebuffPerHour", "TroopProductionPerHour" },
                values: new object[] { 1, 1.2, new TimeSpan(0, 0, 2, 0, 0), 10.0, 1 });
        }
    }
}
