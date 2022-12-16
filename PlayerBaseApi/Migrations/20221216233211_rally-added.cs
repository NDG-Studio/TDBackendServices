using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class rallyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rally",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TargetUserId = table.Column<long>(type: "bigint", nullable: false),
                    TargetGangId = table.Column<string>(type: "text", nullable: true),
                    TargetGangAvatarId = table.Column<int>(type: "integer", nullable: true),
                    TargetGangName = table.Column<string>(type: "text", nullable: true),
                    LeaderGangId = table.Column<string>(type: "text", nullable: true),
                    LeaderGangAvatarId = table.Column<int>(type: "integer", nullable: true),
                    LeaderGangName = table.Column<string>(type: "text", nullable: true),
                    TargetAvatarId = table.Column<int>(type: "integer", nullable: false),
                    LeaderAvatarId = table.Column<int>(type: "integer", nullable: false),
                    LeaderUserId = table.Column<long>(type: "bigint", nullable: false),
                    TargetUsername = table.Column<string>(type: "text", nullable: true),
                    LeaderUsername = table.Column<string>(type: "text", nullable: true),
                    TargetUserCoord = table.Column<string>(type: "text", nullable: true),
                    LeaderUserCoord = table.Column<string>(type: "text", nullable: true),
                    TargetTroopCount = table.Column<int>(type: "integer", nullable: true),
                    TargetsWoundedTroop = table.Column<int>(type: "integer", nullable: true),
                    TargetBarracksLevel = table.Column<int>(type: "integer", nullable: true),
                    LootedScrap = table.Column<int>(type: "integer", nullable: true),
                    TargetScrap = table.Column<int>(type: "integer", nullable: true),
                    TargetsTroop = table.Column<int>(type: "integer", nullable: true),
                    PrisonerCount = table.Column<int>(type: "integer", nullable: true),
                    TargetWallLevel = table.Column<int>(type: "integer", nullable: true),
                    TargetsDeadTroop = table.Column<int>(type: "integer", nullable: true),
                    WinnerSide = table.Column<byte>(type: "smallint", nullable: true),
                    RallyStartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    WarDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ComeBackDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rally", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RallyPart",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RallyId = table.Column<long>(type: "bigint", nullable: false),
                    TroopCount = table.Column<int>(type: "integer", nullable: false),
                    HeroId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    ArriveDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ComeBackDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    WoundedTroop = table.Column<int>(type: "integer", nullable: false),
                    DeadTroop = table.Column<int>(type: "integer", nullable: false),
                    SenderAvatarId = table.Column<int>(type: "integer", nullable: false),
                    BarracksLevel = table.Column<int>(type: "integer", nullable: false),
                    WallLevel = table.Column<int>(type: "integer", nullable: false),
                    LootedScrap = table.Column<int>(type: "integer", nullable: false),
                    PrisonerCount = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RallyPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RallyPart_Rally_RallyId",
                        column: x => x.RallyId,
                        principalTable: "Rally",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RallyPart_RallyId",
                table: "RallyPart",
                column: "RallyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RallyPart");

            migrationBuilder.DropTable(
                name: "Rally");
        }
    }
}
