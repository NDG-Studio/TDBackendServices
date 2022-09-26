using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class hospitalentitiesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HospitalLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    HealingDurationPerUnit = table.Column<TimeSpan>(type: "interval", nullable: false),
                    HealingCostPerUnit = table.Column<double>(type: "double precision", nullable: false),
                    HospitalCapacity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerHospital",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    HospitalLevelId = table.Column<int>(type: "integer", nullable: false),
                    InjuredCount = table.Column<int>(type: "integer", nullable: false),
                    HealingDoneDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    InHealingCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerHospital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerHospital_HospitalLevel_HospitalLevelId",
                        column: x => x.HospitalLevelId,
                        principalTable: "HospitalLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HospitalLevel",
                columns: new[] { "Id", "HealingCostPerUnit", "HealingDurationPerUnit", "HospitalCapacity", "Level" },
                values: new object[,]
                {
                    { 1, 100.0, new TimeSpan(0, 0, 10, 0, 0), 10, 1 },
                    { 2, 50.0, new TimeSpan(0, 0, 5, 0, 0), 20, 2 },
                    { 3, 33.0, new TimeSpan(0, 0, 3, 20, 0), 30, 3 },
                    { 4, 25.0, new TimeSpan(0, 0, 2, 30, 0), 40, 4 },
                    { 5, 20.0, new TimeSpan(0, 0, 2, 0, 0), 50, 5 },
                    { 6, 16.0, new TimeSpan(0, 0, 1, 40, 0), 60, 6 },
                    { 7, 14.0, new TimeSpan(857142857), 70, 7 },
                    { 8, 12.0, new TimeSpan(0, 0, 1, 15, 0), 80, 8 },
                    { 9, 11.0, new TimeSpan(666666666), 90, 9 },
                    { 10, 10.0, new TimeSpan(0, 0, 1, 0, 0), 100, 10 },
                    { 11, 9.0, new TimeSpan(545454545), 110, 11 },
                    { 12, 8.0, new TimeSpan(0, 0, 0, 50, 0), 120, 12 },
                    { 13, 7.0, new TimeSpan(461538461), 130, 13 },
                    { 14, 7.0, new TimeSpan(428571428), 140, 14 },
                    { 15, 6.0, new TimeSpan(0, 0, 0, 40, 0), 150, 15 },
                    { 16, 6.0, new TimeSpan(0, 0, 0, 37, 500), 160, 16 },
                    { 17, 5.0, new TimeSpan(352941176), 170, 17 },
                    { 18, 5.0, new TimeSpan(333333333), 180, 18 },
                    { 19, 5.0, new TimeSpan(315789473), 190, 19 },
                    { 20, 5.0, new TimeSpan(0, 0, 0, 30, 0), 200, 20 },
                    { 21, 4.0, new TimeSpan(285714285), 210, 21 },
                    { 22, 4.0, new TimeSpan(272727272), 220, 22 },
                    { 23, 4.0, new TimeSpan(260869565), 230, 23 },
                    { 24, 4.0, new TimeSpan(0, 0, 0, 25, 0), 240, 24 },
                    { 25, 4.0, new TimeSpan(0, 0, 0, 24, 0), 250, 25 },
                    { 26, 3.0, new TimeSpan(230769230), 260, 26 },
                    { 27, 3.0, new TimeSpan(222222222), 270, 27 },
                    { 28, 3.0, new TimeSpan(214285714), 280, 28 },
                    { 29, 3.0, new TimeSpan(206896551), 290, 29 },
                    { 30, 3.0, new TimeSpan(0, 0, 0, 20, 0), 300, 30 },
                    { 31, 3.0, new TimeSpan(193548387), 310, 31 },
                    { 32, 3.0, new TimeSpan(0, 0, 0, 18, 750), 320, 32 },
                    { 33, 3.0, new TimeSpan(181818181), 330, 33 },
                    { 34, 2.0, new TimeSpan(176470588), 340, 34 },
                    { 35, 2.0, new TimeSpan(171428571), 350, 35 },
                    { 36, 2.0, new TimeSpan(166666666), 360, 36 },
                    { 37, 2.0, new TimeSpan(162162162), 370, 37 },
                    { 38, 2.0, new TimeSpan(157894736), 380, 38 },
                    { 39, 2.0, new TimeSpan(153846153), 390, 39 },
                    { 40, 2.0, new TimeSpan(0, 0, 0, 15, 0), 400, 40 },
                    { 41, 2.0, new TimeSpan(146341463), 410, 41 },
                    { 42, 2.0, new TimeSpan(142857142), 420, 42 },
                    { 43, 2.0, new TimeSpan(139534883), 430, 43 },
                    { 44, 2.0, new TimeSpan(136363636), 440, 44 },
                    { 45, 2.0, new TimeSpan(133333333), 450, 45 },
                    { 46, 2.0, new TimeSpan(130434782), 460, 46 },
                    { 47, 2.0, new TimeSpan(127659574), 470, 47 },
                    { 48, 2.0, new TimeSpan(0, 0, 0, 12, 500), 480, 48 },
                    { 49, 2.0, new TimeSpan(122448979), 490, 49 },
                    { 50, 2.0, new TimeSpan(0, 0, 0, 12, 0), 500, 50 },
                    { 51, 1.0, new TimeSpan(117647058), 510, 51 },
                    { 52, 1.0, new TimeSpan(115384615), 520, 52 },
                    { 53, 1.0, new TimeSpan(113207547), 530, 53 },
                    { 54, 1.0, new TimeSpan(111111111), 540, 54 },
                    { 55, 1.0, new TimeSpan(109090909), 550, 55 },
                    { 56, 1.0, new TimeSpan(107142857), 560, 56 },
                    { 57, 1.0, new TimeSpan(105263157), 570, 57 },
                    { 58, 1.0, new TimeSpan(103448275), 580, 58 },
                    { 59, 1.0, new TimeSpan(101694915), 590, 59 },
                    { 60, 1.0, new TimeSpan(0, 0, 0, 10, 0), 600, 60 },
                    { 61, 1.0, new TimeSpan(98360655), 610, 61 },
                    { 62, 1.0, new TimeSpan(96774193), 620, 62 },
                    { 63, 1.0, new TimeSpan(95238095), 630, 63 },
                    { 64, 1.0, new TimeSpan(0, 0, 0, 9, 375), 640, 64 },
                    { 65, 1.0, new TimeSpan(92307692), 650, 65 },
                    { 66, 1.0, new TimeSpan(90909090), 660, 66 },
                    { 67, 1.0, new TimeSpan(89552238), 670, 67 },
                    { 68, 1.0, new TimeSpan(88235294), 680, 68 },
                    { 69, 1.0, new TimeSpan(86956521), 690, 69 },
                    { 70, 1.0, new TimeSpan(85714285), 700, 70 },
                    { 71, 1.0, new TimeSpan(84507042), 710, 71 },
                    { 72, 1.0, new TimeSpan(83333333), 720, 72 },
                    { 73, 1.0, new TimeSpan(82191780), 730, 73 },
                    { 74, 1.0, new TimeSpan(81081081), 740, 74 },
                    { 75, 1.0, new TimeSpan(0, 0, 0, 8, 0), 750, 75 },
                    { 76, 1.0, new TimeSpan(78947368), 760, 76 },
                    { 77, 1.0, new TimeSpan(77922077), 770, 77 },
                    { 78, 1.0, new TimeSpan(76923076), 780, 78 },
                    { 79, 1.0, new TimeSpan(75949367), 790, 79 },
                    { 80, 1.0, new TimeSpan(0, 0, 0, 7, 500), 800, 80 },
                    { 81, 1.0, new TimeSpan(74074074), 810, 81 },
                    { 82, 1.0, new TimeSpan(73170731), 820, 82 },
                    { 83, 1.0, new TimeSpan(72289156), 830, 83 },
                    { 84, 1.0, new TimeSpan(71428571), 840, 84 },
                    { 85, 1.0, new TimeSpan(70588235), 850, 85 },
                    { 86, 1.0, new TimeSpan(69767441), 860, 86 },
                    { 87, 1.0, new TimeSpan(68965517), 870, 87 },
                    { 88, 1.0, new TimeSpan(68181818), 880, 88 },
                    { 89, 1.0, new TimeSpan(67415730), 890, 89 },
                    { 90, 1.0, new TimeSpan(66666666), 900, 90 },
                    { 91, 1.0, new TimeSpan(65934065), 910, 91 },
                    { 92, 1.0, new TimeSpan(65217391), 920, 92 },
                    { 93, 1.0, new TimeSpan(64516129), 930, 93 },
                    { 94, 1.0, new TimeSpan(63829787), 940, 94 },
                    { 95, 1.0, new TimeSpan(63157894), 950, 95 },
                    { 96, 1.0, new TimeSpan(0, 0, 0, 6, 250), 960, 96 },
                    { 97, 1.0, new TimeSpan(61855670), 970, 97 },
                    { 98, 1.0, new TimeSpan(61224489), 980, 98 },
                    { 99, 1.0, new TimeSpan(60606060), 990, 99 },
                    { 100, 1.0, new TimeSpan(0, 0, 0, 6, 0), 1000, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerHospital_HospitalLevelId",
                table: "PlayerHospital",
                column: "HospitalLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerHospital");

            migrationBuilder.DropTable(
                name: "HospitalLevel");
        }
    }
}
