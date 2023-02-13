using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ZTD.Migrations
{
    public partial class chestsystemadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChestType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MainItemType = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChestType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Value1 = table.Column<int>(type: "integer", nullable: true),
                    ItemTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerVariable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    GemCount = table.Column<int>(type: "integer", nullable: false),
                    ResearchPoint = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerVariable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerVariable_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChestTypeId = table.Column<int>(type: "integer", nullable: false),
                    Rarity = table.Column<int>(type: "integer", nullable: false),
                    MainItemMinCount = table.Column<int>(type: "integer", nullable: false),
                    MainItemMaxCount = table.Column<int>(type: "integer", nullable: false),
                    OtherItemMaxCount = table.Column<int>(type: "integer", nullable: false),
                    OtherItemMimCount = table.Column<int>(type: "integer", nullable: false),
                    OpenDuration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    InstantOpenGemCount = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chest_ChestType_ChestTypeId",
                        column: x => x.ChestTypeId,
                        principalTable: "ChestType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LevelGift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    LevelId = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelGift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelGift_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LevelGift_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerItem_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LevelChestChance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChestId = table.Column<int>(type: "integer", nullable: false),
                    LevelId = table.Column<int>(type: "integer", nullable: false),
                    ChanceMultiplier = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelChestChance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelChestChance_Chest_ChestId",
                        column: x => x.ChestId,
                        principalTable: "Chest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LevelChestChance_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerChest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ChestId = table.Column<int>(type: "integer", nullable: false),
                    OpenStartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    OpenFinishDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UsedGem = table.Column<int>(type: "integer", nullable: false),
                    GainedItems = table.Column<string>(type: "text", nullable: true),
                    SlotPlace = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerChest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerChest_Chest_ChestId",
                        column: x => x.ChestId,
                        principalTable: "Chest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerChest_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 2, 10, 17, 22, 32, 137, DateTimeKind.Unspecified).AddTicks(1160), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 10, 17, 22, 32, 137, DateTimeKind.Unspecified).AddTicks(1210), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Chest_ChestTypeId",
                table: "Chest",
                column: "ChestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelChestChance_ChestId",
                table: "LevelChestChance",
                column: "ChestId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelChestChance_LevelId",
                table: "LevelChestChance",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelGift_ItemId",
                table: "LevelGift",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelGift_LevelId",
                table: "LevelGift",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerChest_ChestId",
                table: "PlayerChest",
                column: "ChestId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerChest_UserId",
                table: "PlayerChest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerItem_ItemId",
                table: "PlayerItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerItem_UserId",
                table: "PlayerItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerVariable_UserId",
                table: "PlayerVariable",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LevelChestChance");

            migrationBuilder.DropTable(
                name: "LevelGift");

            migrationBuilder.DropTable(
                name: "PlayerChest");

            migrationBuilder.DropTable(
                name: "PlayerItem");

            migrationBuilder.DropTable(
                name: "PlayerVariable");

            migrationBuilder.DropTable(
                name: "Chest");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ChestType");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 2, 6, 1, 4, 2, 428, DateTimeKind.Unspecified).AddTicks(6630), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 6, 1, 4, 2, 428, DateTimeKind.Unspecified).AddTicks(6680), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
