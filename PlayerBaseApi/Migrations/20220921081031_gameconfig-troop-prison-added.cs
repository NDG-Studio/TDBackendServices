using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class gameconfigtroopprisonadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameConfig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrisonerExecutionGainPerUnit = table.Column<double>(type: "double precision", nullable: false),
                    PrisonerResorceDebuffPerHour = table.Column<double>(type: "double precision", nullable: false),
                    PrisonerMaxDuration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    TroopProductionPerHour = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConfig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPrison",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    PrisonerCount = table.Column<int>(type: "integer", nullable: false),
                    LastCollectDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPrison", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTroop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TroopCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTroop", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GameConfig",
                columns: new[] { "Id", "PrisonerExecutionGainPerUnit", "PrisonerMaxDuration", "PrisonerResorceDebuffPerHour", "TroopProductionPerHour" },
                values: new object[] { 1, 1.2, new TimeSpan(0, 0, 2, 0, 0), 10.0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameConfig");

            migrationBuilder.DropTable(
                name: "PlayerPrison");

            migrationBuilder.DropTable(
                name: "PlayerTroop");
        }
    }
}
