using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class tutorialquestentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TutorialQuest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StageId = table.Column<int>(type: "integer", nullable: false),
                    StageOrderId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorialQuest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTutorialQuest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TutorialQuestId = table.Column<int>(type: "integer", nullable: false),
                    IsDone = table.Column<bool>(type: "boolean", nullable: false),
                    IsClaim = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTutorialQuest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerTutorialQuest_TutorialQuest_TutorialQuestId",
                        column: x => x.TutorialQuestId,
                        principalTable: "TutorialQuest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TutorialQuestsGift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TutorialQuestId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorialQuestsGift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TutorialQuestsGift_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorialQuestsGift_TutorialQuest_TutorialQuestId",
                        column: x => x.TutorialQuestId,
                        principalTable: "TutorialQuest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTutorialQuest_TutorialQuestId",
                table: "PlayerTutorialQuest",
                column: "TutorialQuestId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorialQuestsGift_ItemId",
                table: "TutorialQuestsGift",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorialQuestsGift_TutorialQuestId",
                table: "TutorialQuestsGift",
                column: "TutorialQuestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerTutorialQuest");

            migrationBuilder.DropTable(
                name: "TutorialQuestsGift");

            migrationBuilder.DropTable(
                name: "TutorialQuest");
        }
    }
}
