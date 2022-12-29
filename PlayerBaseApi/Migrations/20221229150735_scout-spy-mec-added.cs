using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class scoutspymecadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScoutLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    TrainingDurationPerUnit = table.Column<TimeSpan>(type: "interval", nullable: false),
                    TrainingCostPerUnit = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoutLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerScout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ScoutLevelId = table.Column<int>(type: "integer", nullable: false),
                    SpyCount = table.Column<int>(type: "integer", nullable: false),
                    TrainingDoneDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    InTrainingCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerScout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerScout_ScoutLevel_ScoutLevelId",
                        column: x => x.ScoutLevelId,
                        principalTable: "ScoutLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerScout_ScoutLevelId",
                table: "PlayerScout",
                column: "ScoutLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerScout");

            migrationBuilder.DropTable(
                name: "ScoutLevel");
        }
    }
}
