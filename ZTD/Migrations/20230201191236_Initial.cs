using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ZTD.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    OrderId = table.Column<string>(type: "text", nullable: false),
                    SceneId = table.Column<string>(type: "text", nullable: false),
                    TotalStar = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enemy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<string>(type: "text", nullable: true),
                    EventName = table.Column<string>(type: "text", nullable: true),
                    Ip = table.Column<string>(type: "text", nullable: false),
                    DeviceId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DeviceType = table.Column<string>(type: "text", nullable: true),
                    DeviceModel = table.Column<string>(type: "text", nullable: true),
                    OsVersion = table.Column<string>(type: "text", nullable: true),
                    AppVersion = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Duration = table.Column<double>(type: "double precision", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    Exception = table.Column<string>(type: "text", nullable: true),
                    InnerException = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogAction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<string>(type: "text", nullable: true),
                    EventName = table.Column<string>(type: "text", nullable: true),
                    Ip = table.Column<string>(type: "text", nullable: false),
                    DeviceId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DeviceType = table.Column<string>(type: "text", nullable: true),
                    DeviceModel = table.Column<string>(type: "text", nullable: true),
                    OsVersion = table.Column<string>(type: "text", nullable: true),
                    AppVersion = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Duration = table.Column<double>(type: "double precision", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogAction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tower",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tower", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastSeen = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    FirstLogInDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MobileUserId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    GooglePlayId = table.Column<string>(type: "text", nullable: true),
                    AppleId = table.Column<string>(type: "text", nullable: true),
                    FacebookId = table.Column<string>(type: "text", nullable: true),
                    IsTutorialDone = table.Column<bool>(type: "boolean", nullable: false),
                    IsAndroid = table.Column<bool>(type: "boolean", nullable: true),
                    IsApe = table.Column<bool>(type: "boolean", nullable: false),
                    TdSyncDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ChapterId = table.Column<int>(type: "integer", nullable: false),
                    LevelStarCondition = table.Column<int>(type: "integer", nullable: false),
                    Coin = table.Column<int>(type: "integer", nullable: false),
                    BarrierHealth = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Level_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnemyLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    EnemyId = table.Column<int>(type: "integer", nullable: false),
                    Health = table.Column<double>(type: "double precision", nullable: false),
                    Armor = table.Column<double>(type: "double precision", nullable: false),
                    Speed = table.Column<double>(type: "double precision", nullable: false),
                    Coin = table.Column<int>(type: "integer", nullable: false),
                    BarierDamageAmount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemyLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnemyLevel_Enemy_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TowerLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    TowerId = table.Column<int>(type: "integer", nullable: false),
                    Damage = table.Column<double>(type: "double precision", nullable: false),
                    FireRate = table.Column<double>(type: "double precision", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Range = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TowerLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TowerLevel_Tower_TowerId",
                        column: x => x.TowerId,
                        principalTable: "Tower",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProgressHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LevelId = table.Column<int>(type: "integer", nullable: false),
                    SpentCoin = table.Column<int>(type: "integer", nullable: false),
                    GainedCoin = table.Column<int>(type: "integer", nullable: false),
                    TotalCoin = table.Column<int>(type: "integer", nullable: false),
                    BarrierHealth = table.Column<int>(type: "integer", nullable: false),
                    WaveStartTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    WaveEndTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    GainedStar = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProgressHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProgressHistory_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProgressHistory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTdStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    GemCount = table.Column<int>(type: "integer", nullable: false),
                    TotalGainedGemCount = table.Column<long>(type: "bigint", nullable: false),
                    TotalGainedScrapCount = table.Column<long>(type: "bigint", nullable: false),
                    ResearchPoint = table.Column<int>(type: "integer", nullable: false),
                    TotalGainedResearchPoint = table.Column<long>(type: "bigint", nullable: false),
                    BuildedTowerCount = table.Column<long>(type: "bigint", nullable: false),
                    UpgradedTowerCount = table.Column<long>(type: "bigint", nullable: false),
                    RemovedTowerCount = table.Column<long>(type: "bigint", nullable: false),
                    KilledEnemyCount = table.Column<long>(type: "bigint", nullable: false),
                    TdLevelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTdStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTdStatus_Level_TdLevelId",
                        column: x => x.TdLevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTdStatus_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LevelId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    EntryTime = table.Column<double>(type: "double precision", nullable: false),
                    EntryInterval = table.Column<double>(type: "double precision", nullable: false),
                    EntryPoint = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wave_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnemyKill",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProgressHistoryId = table.Column<long>(type: "bigint", nullable: false),
                    EnemyLevelId = table.Column<int>(type: "integer", nullable: false),
                    DeadCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemyKill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnemyKill_EnemyLevel_EnemyLevelId",
                        column: x => x.EnemyLevelId,
                        principalTable: "EnemyLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnemyKill_UserProgressHistory_UserProgressHistoryId",
                        column: x => x.UserProgressHistoryId,
                        principalTable: "UserProgressHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TowerProgress",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TowerId = table.Column<int>(type: "integer", nullable: false),
                    UserProgressHistoryId = table.Column<long>(type: "bigint", nullable: false),
                    TowerCount = table.Column<int>(type: "integer", nullable: false),
                    TowerUpgradeNumber = table.Column<int>(type: "integer", nullable: false),
                    TowerFireCount = table.Column<int>(type: "integer", nullable: false),
                    TowerDamage = table.Column<double>(type: "double precision", nullable: false),
                    TowerDotDamage = table.Column<double>(type: "double precision", nullable: false),
                    TowerArmorDamage = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TowerProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TowerProgress_Tower_TowerId",
                        column: x => x.TowerId,
                        principalTable: "Tower",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TowerProgress_UserProgressHistory_UserProgressHistoryId",
                        column: x => x.UserProgressHistoryId,
                        principalTable: "UserProgressHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTowerPlaceHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProgressHistoryId = table.Column<long>(type: "bigint", nullable: false),
                    PlaceId = table.Column<int>(type: "integer", nullable: false),
                    TowerLevelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTowerPlaceHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTowerPlaceHistory_TowerLevel_TowerLevelId",
                        column: x => x.TowerLevelId,
                        principalTable: "TowerLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTowerPlaceHistory_UserProgressHistory_UserProgressHisto~",
                        column: x => x.UserProgressHistoryId,
                        principalTable: "UserProgressHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WavePart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WaveId = table.Column<int>(type: "integer", nullable: false),
                    EnemyLevelId = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WavePart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WavePart_Wave_WaveId",
                        column: x => x.WaveId,
                        principalTable: "Wave",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AppleId", "Email", "FacebookId", "FirstLogInDate", "GooglePlayId", "IsActive", "IsAndroid", "IsApe", "IsTutorialDone", "LastSeen", "MobileUserId", "PasswordHash", "TdSyncDate", "Username" },
                values: new object[] { 1L, null, "ugurcan.bagriyanik@ndgstudio.com.tr", null, new DateTimeOffset(new DateTime(2023, 2, 1, 22, 12, 36, 819, DateTimeKind.Unspecified).AddTicks(2120), new TimeSpan(0, 3, 0, 0, 0)), null, true, true, true, false, new DateTimeOffset(new DateTime(2023, 2, 1, 22, 12, 36, 819, DateTimeKind.Unspecified).AddTicks(2160), new TimeSpan(0, 3, 0, 0, 0)), "dummyMobileUserId1", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", null, "ugur" });

            migrationBuilder.CreateIndex(
                name: "IX_EnemyKill_EnemyLevelId",
                table: "EnemyKill",
                column: "EnemyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyKill_UserProgressHistoryId",
                table: "EnemyKill",
                column: "UserProgressHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyLevel_EnemyId",
                table: "EnemyLevel",
                column: "EnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_Level_ChapterId",
                table: "Level",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_TowerLevel_TowerId",
                table: "TowerLevel",
                column: "TowerId");

            migrationBuilder.CreateIndex(
                name: "IX_TowerProgress_TowerId",
                table: "TowerProgress",
                column: "TowerId");

            migrationBuilder.CreateIndex(
                name: "IX_TowerProgress_UserProgressHistoryId",
                table: "TowerProgress",
                column: "UserProgressHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgressHistory_LevelId",
                table: "UserProgressHistory",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgressHistory_UserId",
                table: "UserProgressHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTdStatus_TdLevelId",
                table: "UserTdStatus",
                column: "TdLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTdStatus_UserId",
                table: "UserTdStatus",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserId",
                table: "UserToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTowerPlaceHistory_TowerLevelId",
                table: "UserTowerPlaceHistory",
                column: "TowerLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTowerPlaceHistory_UserProgressHistoryId",
                table: "UserTowerPlaceHistory",
                column: "UserProgressHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Wave_LevelId",
                table: "Wave",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_WavePart_WaveId",
                table: "WavePart",
                column: "WaveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnemyKill");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "LogAction");

            migrationBuilder.DropTable(
                name: "TowerProgress");

            migrationBuilder.DropTable(
                name: "UserTdStatus");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "UserTowerPlaceHistory");

            migrationBuilder.DropTable(
                name: "WavePart");

            migrationBuilder.DropTable(
                name: "EnemyLevel");

            migrationBuilder.DropTable(
                name: "TowerLevel");

            migrationBuilder.DropTable(
                name: "UserProgressHistory");

            migrationBuilder.DropTable(
                name: "Wave");

            migrationBuilder.DropTable(
                name: "Enemy");

            migrationBuilder.DropTable(
                name: "Tower");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "Chapter");
        }
    }
}
