using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class marketadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarketItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    MaxCount = table.Column<int>(type: "integer", nullable: false),
                    GemPrice = table.Column<int>(type: "integer", nullable: false),
                    ScrapPrice = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMarketHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    MarketItemId = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    BeforeGemCount = table.Column<int>(type: "integer", nullable: false),
                    AfterGemCount = table.Column<int>(type: "integer", nullable: false),
                    BeforeScrapCount = table.Column<int>(type: "integer", nullable: false),
                    AfterScrapCount = table.Column<int>(type: "integer", nullable: false),
                    PurchaseDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMarketHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerMarketHistory_MarketItem_MarketItemId",
                        column: x => x.MarketItemId,
                        principalTable: "MarketItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketItem_ItemId",
                table: "MarketItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMarketHistory_MarketItemId",
                table: "PlayerMarketHistory",
                column: "MarketItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerMarketHistory");

            migrationBuilder.DropTable(
                name: "MarketItem");
        }
    }
}
