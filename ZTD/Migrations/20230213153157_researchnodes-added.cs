using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ZTD.Migrations
{
    public partial class researchnodesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResearchNode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PlaceId = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchNode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResearchNodeLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResearchNodeId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    BluePrintCount = table.Column<int>(type: "integer", nullable: false),
                    BuffValue = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchNodeLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchNodeLevel_ResearchNode_ResearchNodeId",
                        column: x => x.ResearchNodeId,
                        principalTable: "ResearchNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerResearchNodeLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ResearchNodeLevelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerResearchNodeLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerResearchNodeLevel_ResearchNodeLevel_ResearchNodeLevel~",
                        column: x => x.ResearchNodeLevelId,
                        principalTable: "ResearchNodeLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerResearchNodeLevel_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResearchNodeUpgradeCondition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResearchNodeId = table.Column<int>(type: "integer", nullable: false),
                    PrereqLevel = table.Column<int>(type: "integer", nullable: false),
                    ResearchNodeLevelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchNodeUpgradeCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchNodeUpgradeCondition_ResearchNode_ResearchNodeId",
                        column: x => x.ResearchNodeId,
                        principalTable: "ResearchNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResearchNodeUpgradeCondition_ResearchNodeLevel_ResearchNode~",
                        column: x => x.ResearchNodeLevelId,
                        principalTable: "ResearchNodeLevel",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 2, 13, 18, 31, 57, 576, DateTimeKind.Unspecified).AddTicks(5430), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 13, 18, 31, 57, 576, DateTimeKind.Unspecified).AddTicks(5490), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerResearchNodeLevel_ResearchNodeLevelId",
                table: "PlayerResearchNodeLevel",
                column: "ResearchNodeLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerResearchNodeLevel_UserId",
                table: "PlayerResearchNodeLevel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchNodeLevel_ResearchNodeId",
                table: "ResearchNodeLevel",
                column: "ResearchNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchNodeUpgradeCondition_ResearchNodeId",
                table: "ResearchNodeUpgradeCondition",
                column: "ResearchNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchNodeUpgradeCondition_ResearchNodeLevelId",
                table: "ResearchNodeUpgradeCondition",
                column: "ResearchNodeLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerResearchNodeLevel");

            migrationBuilder.DropTable(
                name: "ResearchNodeUpgradeCondition");

            migrationBuilder.DropTable(
                name: "ResearchNodeLevel");

            migrationBuilder.DropTable(
                name: "ResearchNode");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstLogInDate", "LastSeen" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 2, 10, 17, 22, 32, 137, DateTimeKind.Unspecified).AddTicks(1160), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 10, 17, 22, 32, 137, DateTimeKind.Unspecified).AddTicks(1210), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
