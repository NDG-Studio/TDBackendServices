using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class updateupgradefixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingUpdateTime");

            migrationBuilder.CreateTable(
                name: "BuildingUpgradeTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BuildingTypeId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    UpgradeDuration = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingUpgradeTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingUpgradeTime_BuildingType_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "BuildingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BuildingUpgradeTime",
                columns: new[] { "Id", "BuildingTypeId", "Level", "UpgradeDuration" },
                values: new object[,]
                {
                    { 1, 1, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 2, 2, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 3, 3, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 4, 4, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 5, 5, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 6, 6, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 7, 7, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 8, 8, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 9, 9, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 10, 1, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 11, 2, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 12, 3, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 13, 4, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 14, 5, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 15, 6, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 16, 7, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 17, 8, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 18, 9, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 19, 1, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 20, 2, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 21, 3, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 22, 4, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 23, 5, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 24, 6, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 25, 7, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 26, 8, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 27, 9, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 28, 1, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 29, 2, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 30, 3, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 31, 4, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 32, 5, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 33, 6, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 34, 7, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 35, 8, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 36, 9, 5, new TimeSpan(0, 0, 30, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingUpgradeTime_BuildingTypeId",
                table: "BuildingUpgradeTime",
                column: "BuildingTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingUpgradeTime");

            migrationBuilder.CreateTable(
                name: "BuildingUpdateTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BuildingTypeId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    UpdateDuration = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingUpdateTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingUpdateTime_BuildingType_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "BuildingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BuildingUpdateTime",
                columns: new[] { "Id", "BuildingTypeId", "Level", "UpdateDuration" },
                values: new object[,]
                {
                    { 1, 1, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 2, 2, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 3, 3, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 4, 4, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 5, 5, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 6, 6, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 7, 7, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 8, 8, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 9, 9, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 10, 1, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 11, 2, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 12, 3, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 13, 4, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 14, 5, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 15, 6, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 16, 7, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 17, 8, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 18, 9, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 19, 1, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 20, 2, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 21, 3, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 22, 4, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 23, 5, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 24, 6, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 25, 7, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 26, 8, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 27, 9, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 28, 1, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 29, 2, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 30, 3, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 31, 4, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 32, 5, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 33, 6, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 34, 7, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 35, 8, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 36, 9, 5, new TimeSpan(0, 0, 30, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingUpdateTime_BuildingTypeId",
                table: "BuildingUpdateTime",
                column: "BuildingTypeId");
        }
    }
}
