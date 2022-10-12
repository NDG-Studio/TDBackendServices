using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class initialmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    BuildingUpgradeDurationMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    BuildingUpgradeCostMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    LootGemMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    LootBluePrintMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    LootScrapMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    LootPerfectRunMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    LootDurationMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    LootCapacity = table.Column<double>(type: "double precision", nullable: false),
                    PrisonCapacityMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    PrisonCostMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    PrisonTrainingCostMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    PrisonTrainingDurationMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    PrisonExecutionEarnMultiplier = table.Column<double>(type: "double precision", nullable: false),
                    BaseResourceMultiplier = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BuildUrl = table.Column<string>(type: "text", nullable: false),
                    MaxLevel = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Story = table.Column<string>(type: "text", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: false),
                    BackgroundPictureUrl = table.Column<string>(type: "text", nullable: false),
                    ThemeColor = table.Column<string>(type: "text", nullable: false),
                    MaxLevel = table.Column<int>(type: "integer", nullable: false),
                    IsApe = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero", x => x.Id);
                });

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
                name: "LootLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MinScrapCount = table.Column<int>(type: "integer", nullable: false),
                    MaxScrapCount = table.Column<int>(type: "integer", nullable: false),
                    MinBlueprintCount = table.Column<int>(type: "integer", nullable: false),
                    MaxBlueprintCount = table.Column<int>(type: "integer", nullable: false),
                    MinGemCount = table.Column<int>(type: "integer", nullable: false),
                    MaxGemCount = table.Column<int>(type: "integer", nullable: false),
                    LootDuration = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LootLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerBaseInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    BaseLevel = table.Column<int>(type: "integer", nullable: false),
                    Scraps = table.Column<int>(type: "integer", nullable: false),
                    Gems = table.Column<int>(type: "integer", nullable: false),
                    HeroCards = table.Column<int>(type: "integer", nullable: false),
                    BluePrints = table.Column<int>(type: "integer", nullable: false),
                    Fuel = table.Column<int>(type: "integer", nullable: false),
                    LastBaseCollect = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    BaseFullDuration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    ResourceProductionPerHour = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerBaseInfo", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "ResearchTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TalentTree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BackgroundUrl = table.Column<string>(type: "text", nullable: false),
                    ThemeColor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentTree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrisonLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BuffId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    TrainingDurationPerUnit = table.Column<TimeSpan>(type: "interval", nullable: false),
                    TrainingCostPerUnit = table.Column<double>(type: "double precision", nullable: false),
                    ExecutionEarnPerUnit = table.Column<double>(type: "double precision", nullable: false),
                    MaxPrisonerCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrisonLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrisonLevel_Buff_BuffId",
                        column: x => x.BuffId,
                        principalTable: "Buff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingUpgradeTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BuildingTypeId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    UpgradeDuration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    ScrapCount = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "PlayerBasePlacement",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BuildingTypeId = table.Column<int>(type: "integer", nullable: false),
                    BuildingLevel = table.Column<int>(type: "integer", nullable: false),
                    UpdateEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CoordX = table.Column<int>(type: "integer", nullable: false),
                    CoordY = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerBasePlacement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerBasePlacement_BuildingType_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "BuildingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeroLevelThreshold",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeroId = table.Column<int>(type: "integer", nullable: false),
                    BuffId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Experience = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroLevelThreshold", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeroLevelThreshold_Buff_BuffId",
                        column: x => x.BuffId,
                        principalTable: "Buff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroLevelThreshold_Hero_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Hero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeroSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PlaceId = table.Column<int>(type: "integer", nullable: false),
                    HeroId = table.Column<int>(type: "integer", nullable: false),
                    MaksLevel = table.Column<int>(type: "integer", nullable: false),
                    IsPassiveSkill = table.Column<bool>(type: "boolean", nullable: false),
                    TumbnailUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeroSkill_Hero_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Hero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerHero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    HeroId = table.Column<int>(type: "integer", nullable: false),
                    Exp = table.Column<long>(type: "bigint", nullable: false),
                    CurrentLevel = table.Column<int>(type: "integer", nullable: false),
                    TalentPoint = table.Column<int>(type: "integer", nullable: false),
                    SkillPoint = table.Column<int>(type: "integer", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerHero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerHero_Hero_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Hero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "ResearchNode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    ResearchTableId = table.Column<int>(type: "integer", nullable: false),
                    PlaceId = table.Column<int>(type: "integer", nullable: false),
                    BuffId = table.Column<int>(type: "integer", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchNode_Buff_BuffId",
                        column: x => x.BuffId,
                        principalTable: "Buff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResearchNode_ResearchTable_ResearchTableId",
                        column: x => x.ResearchTableId,
                        principalTable: "ResearchTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TalentTreeNode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    HeroId = table.Column<int>(type: "integer", nullable: false),
                    TalentTreeId = table.Column<int>(type: "integer", nullable: false),
                    BuffId = table.Column<int>(type: "integer", nullable: false),
                    PlaceId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentTreeNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TalentTreeNode_Buff_BuffId",
                        column: x => x.BuffId,
                        principalTable: "Buff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TalentTreeNode_Hero_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Hero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TalentTreeNode_TalentTree_TalentTreeId",
                        column: x => x.TalentTreeId,
                        principalTable: "TalentTree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPrison",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    PrisonLevelId = table.Column<int>(type: "integer", nullable: false),
                    PrisonerCount = table.Column<int>(type: "integer", nullable: false),
                    TrainingDoneDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    InTrainingPrisonerCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPrison", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerPrison_PrisonLevel_PrisonLevelId",
                        column: x => x.PrisonLevelId,
                        principalTable: "PrisonLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeroSkillLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BuffId = table.Column<int>(type: "integer", nullable: false),
                    HeroSkillId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroSkillLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeroSkillLevel_Buff_BuffId",
                        column: x => x.BuffId,
                        principalTable: "Buff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroSkillLevel_HeroSkill_HeroSkillId",
                        column: x => x.HeroSkillId,
                        principalTable: "HeroSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerHeroLoot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerHeroId = table.Column<int>(type: "integer", nullable: false),
                    LootLevelId = table.Column<int>(type: "integer", nullable: false),
                    OperationStartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    OperationEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    GainedResources = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "PlayerResearchNode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ResearchNodeId = table.Column<int>(type: "integer", nullable: false),
                    CurrentLevel = table.Column<int>(type: "integer", nullable: false),
                    UpdateEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerResearchNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerResearchNode_ResearchNode_ResearchNodeId",
                        column: x => x.ResearchNodeId,
                        principalTable: "ResearchNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResearchNodeUpgradeNecessaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResearchNodeId = table.Column<int>(type: "integer", nullable: false),
                    UpgradeLevel = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    ScrapCount = table.Column<int>(type: "integer", nullable: false),
                    BluePrintCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchNodeUpgradeNecessaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchNodeUpgradeNecessaries_ResearchNode_ResearchNodeId",
                        column: x => x.ResearchNodeId,
                        principalTable: "ResearchNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTalentTreeNode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TalentTreeNodeId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTalentTreeNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerTalentTreeNode_TalentTreeNode_TalentTreeNodeId",
                        column: x => x.TalentTreeNodeId,
                        principalTable: "TalentTreeNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerHeroSkillLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    HeroSkillLevelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerHeroSkillLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerHeroSkillLevel_HeroSkillLevel_HeroSkillLevelId",
                        column: x => x.HeroSkillLevelId,
                        principalTable: "HeroSkillLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResearchNodeUpgradeCondition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResearchNodeUpgradeNecessariesId = table.Column<int>(type: "integer", nullable: false),
                    ResearchNodeId = table.Column<int>(type: "integer", nullable: true),
                    BuildingTypeId = table.Column<int>(type: "integer", nullable: true),
                    PrereqLevel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchNodeUpgradeCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchNodeUpgradeCondition_BuildingType_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "BuildingType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResearchNodeUpgradeCondition_ResearchNode_ResearchNodeId",
                        column: x => x.ResearchNodeId,
                        principalTable: "ResearchNode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResearchNodeUpgradeCondition_ResearchNodeUpgradeNecessaries~",
                        column: x => x.ResearchNodeUpgradeNecessariesId,
                        principalTable: "ResearchNodeUpgradeNecessaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buff",
                columns: new[] { "Id", "BaseResourceMultiplier", "BuildingUpgradeCostMultiplier", "BuildingUpgradeDurationMultiplier", "Description", "LootBluePrintMultiplier", "LootCapacity", "LootDurationMultiplier", "LootGemMultiplier", "LootPerfectRunMultiplier", "LootScrapMultiplier", "Name", "PrisonCapacityMultiplier", "PrisonCostMultiplier", "PrisonExecutionEarnMultiplier", "PrisonTrainingCostMultiplier", "PrisonTrainingDurationMultiplier" },
                values: new object[] { 1, 0.0, 0.0, 0.0, "", 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, "0-Buff", 0.0, 0.0, 0.0, 0.0, 0.0 });

            migrationBuilder.InsertData(
                table: "BuildingType",
                columns: new[] { "Id", "BuildUrl", "IsActive", "MaxLevel", "Name" },
                values: new object[,]
                {
                    { 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-5.png", true, 1000, "Base" },
                    { 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", true, 1000, "Gang Tower" },
                    { 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", true, 1000, "Wall" },
                    { 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", true, 1000, "Hospital" },
                    { 5, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", true, 1000, "Prison" },
                    { 6, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png", true, 1000, "Market" },
                    { 7, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", true, 1000, "Altar" },
                    { 8, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", true, 1000, "Watch Tower" },
                    { 9, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", true, 1000, "Research Laboratory" },
                    { 10, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", true, 1000, "Military Base" }
                });

            migrationBuilder.InsertData(
                table: "Hero",
                columns: new[] { "Id", "BackgroundPictureUrl", "Description", "IsActive", "IsApe", "MaxLevel", "Name", "Story", "ThemeColor", "ThumbnailUrl" },
                values: new object[,]
                {
                    { 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg", "dummydescription", true, false, 30, "Zeus", "Dummyherostory", "#993333", "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg", "Hadesdescription", true, false, 30, "Hades", "Hadesherostory", "#2F4F4F", "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-2-100x100.png" },
                    { 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg", "Poseidondescription", true, false, 30, "Poseidon", "Poseidonherostory", "#00FFFF", "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-3-100x100.png" },
                    { 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg", "Odindescription", true, false, 30, "Odin", "Odinherostory", "#993333", "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 5, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg", "Thordescription", true, false, 30, "Thor", "Thorherostory", "#993333", "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 6, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg", "Smasher", true, true, 30, "Hulk", "Hulkherostory", "#006400", "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 7, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg", "Abominationdescription", true, true, 30, "Abomination", "Abominationherostory", "#7CFC00", "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 8, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg", "octopusdescription", true, true, 30, "Dr. Octopus", "Octopusherostory", "#778899", "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 9, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg", "Just Joker", true, true, 30, "Joker", "Dramatic Hero Story", "#FF8C00", "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 10, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg", "Black Noir description", true, true, 30, "Black Noir", "Black Noir herostory", "#000000", "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 11, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg", "Invinsible Gauntlet Lover", false, true, 30, "Thanos", "Long Story", "#8A2BE2", "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" }
                });

            migrationBuilder.InsertData(
                table: "ResearchTable",
                columns: new[] { "Id", "Name", "ThumbnailUrl" },
                values: new object[,]
                {
                    { 1, "Military Research", "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png" },
                    { 2, "Economical Research", "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png" },
                    { 3, "General Research", "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png" },
                    { 4, "Tower Defense Research", "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png" }
                });

            migrationBuilder.InsertData(
                table: "PlayerBasePlacement",
                columns: new[] { "Id", "BuildingLevel", "BuildingTypeId", "CoordX", "CoordY", "UpdateEndDate", "UserId" },
                values: new object[] { 1L, 1, 1, 1, 1, null, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingUpgradeTime_BuildingTypeId",
                table: "BuildingUpgradeTime",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroLevelThreshold_BuffId",
                table: "HeroLevelThreshold",
                column: "BuffId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroLevelThreshold_HeroId",
                table: "HeroLevelThreshold",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroSkill_HeroId",
                table: "HeroSkill",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroSkillLevel_BuffId",
                table: "HeroSkillLevel",
                column: "BuffId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroSkillLevel_HeroSkillId",
                table: "HeroSkillLevel",
                column: "HeroSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBasePlacement_BuildingTypeId",
                table: "PlayerBasePlacement",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerHero_HeroId",
                table: "PlayerHero",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerHeroLoot_LootLevelId",
                table: "PlayerHeroLoot",
                column: "LootLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerHeroLoot_PlayerHeroId",
                table: "PlayerHeroLoot",
                column: "PlayerHeroId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerHeroSkillLevel_HeroSkillLevelId",
                table: "PlayerHeroSkillLevel",
                column: "HeroSkillLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerHospital_HospitalLevelId",
                table: "PlayerHospital",
                column: "HospitalLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPrison_PrisonLevelId",
                table: "PlayerPrison",
                column: "PrisonLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerResearchNode_ResearchNodeId",
                table: "PlayerResearchNode",
                column: "ResearchNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTalentTreeNode_TalentTreeNodeId",
                table: "PlayerTalentTreeNode",
                column: "TalentTreeNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PrisonLevel_BuffId",
                table: "PrisonLevel",
                column: "BuffId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchNode_BuffId",
                table: "ResearchNode",
                column: "BuffId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchNode_ResearchTableId",
                table: "ResearchNode",
                column: "ResearchTableId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchNodeUpgradeCondition_BuildingTypeId",
                table: "ResearchNodeUpgradeCondition",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchNodeUpgradeCondition_ResearchNodeId",
                table: "ResearchNodeUpgradeCondition",
                column: "ResearchNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchNodeUpgradeCondition_ResearchNodeUpgradeNecessaries~",
                table: "ResearchNodeUpgradeCondition",
                column: "ResearchNodeUpgradeNecessariesId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchNodeUpgradeNecessaries_ResearchNodeId",
                table: "ResearchNodeUpgradeNecessaries",
                column: "ResearchNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TalentTreeNode_BuffId",
                table: "TalentTreeNode",
                column: "BuffId");

            migrationBuilder.CreateIndex(
                name: "IX_TalentTreeNode_HeroId",
                table: "TalentTreeNode",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_TalentTreeNode_TalentTreeId",
                table: "TalentTreeNode",
                column: "TalentTreeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingUpgradeTime");

            migrationBuilder.DropTable(
                name: "HeroLevelThreshold");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "LogAction");

            migrationBuilder.DropTable(
                name: "PlayerBaseInfo");

            migrationBuilder.DropTable(
                name: "PlayerBasePlacement");

            migrationBuilder.DropTable(
                name: "PlayerHeroLoot");

            migrationBuilder.DropTable(
                name: "PlayerHeroSkillLevel");

            migrationBuilder.DropTable(
                name: "PlayerHospital");

            migrationBuilder.DropTable(
                name: "PlayerPrison");

            migrationBuilder.DropTable(
                name: "PlayerResearchNode");

            migrationBuilder.DropTable(
                name: "PlayerTalentTreeNode");

            migrationBuilder.DropTable(
                name: "PlayerTroop");

            migrationBuilder.DropTable(
                name: "ResearchNodeUpgradeCondition");

            migrationBuilder.DropTable(
                name: "LootLevel");

            migrationBuilder.DropTable(
                name: "PlayerHero");

            migrationBuilder.DropTable(
                name: "HeroSkillLevel");

            migrationBuilder.DropTable(
                name: "HospitalLevel");

            migrationBuilder.DropTable(
                name: "PrisonLevel");

            migrationBuilder.DropTable(
                name: "TalentTreeNode");

            migrationBuilder.DropTable(
                name: "BuildingType");

            migrationBuilder.DropTable(
                name: "ResearchNodeUpgradeNecessaries");

            migrationBuilder.DropTable(
                name: "HeroSkill");

            migrationBuilder.DropTable(
                name: "TalentTree");

            migrationBuilder.DropTable(
                name: "ResearchNode");

            migrationBuilder.DropTable(
                name: "Hero");

            migrationBuilder.DropTable(
                name: "Buff");

            migrationBuilder.DropTable(
                name: "ResearchTable");
        }
    }
}
