using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class researchentitiesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ResearchNode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    ResearchTableId = table.Column<int>(type: "integer", nullable: false),
                    BuffId = table.Column<int>(type: "integer", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchNode_ResearchTable_ResearchTableId",
                        column: x => x.ResearchTableId,
                        principalTable: "ResearchTable",
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
                table: "ResearchNode",
                columns: new[] { "Id", "BuffId", "Capacity", "Description", "IsActive", "Name", "ResearchTableId", "ThumbnailUrl" },
                values: new object[,]
                {
                    { 1, 1, 5, "research description", true, "Node_1", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 2, 1, 5, "research description", true, "Node_2", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 3, 1, 5, "research description", true, "Node_3", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 4, 1, 5, "research description", true, "Node_4", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 5, 1, 5, "research description", true, "Node_5", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 6, 1, 5, "research description", true, "Node_1", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 7, 1, 5, "research description", true, "Node_2", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 8, 1, 5, "research description", true, "Node_3", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 9, 1, 5, "research description", true, "Node_4", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 10, 1, 5, "research description", true, "Node_5", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 11, 1, 5, "research description", true, "Node_1", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 12, 1, 5, "research description", true, "Node_2", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 13, 1, 5, "research description", true, "Node_3", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 14, 1, 5, "research description", true, "Node_4", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 15, 1, 5, "research description", true, "Node_5", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 16, 1, 5, "research description", true, "Node_1", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 17, 1, 5, "research description", true, "Node_2", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 18, 1, 5, "research description", true, "Node_3", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 19, 1, 5, "research description", true, "Node_4", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" },
                    { 20, 1, 5, "research description", true, "Node_5", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png" }
                });

            migrationBuilder.InsertData(
                table: "ResearchNodeUpgradeNecessaries",
                columns: new[] { "Id", "BluePrintCount", "Duration", "ResearchNodeId", "ScrapCount", "UpgradeLevel" },
                values: new object[,]
                {
                    { 1, 10, new TimeSpan(0, 0, 2, 0, 0), 1, 100, 1 },
                    { 2, 20, new TimeSpan(0, 0, 4, 0, 0), 1, 200, 2 },
                    { 3, 30, new TimeSpan(0, 0, 6, 0, 0), 1, 300, 3 },
                    { 4, 40, new TimeSpan(0, 0, 8, 0, 0), 1, 400, 4 },
                    { 5, 50, new TimeSpan(0, 0, 10, 0, 0), 1, 500, 5 },
                    { 6, 10, new TimeSpan(0, 0, 2, 0, 0), 2, 100, 1 },
                    { 7, 20, new TimeSpan(0, 0, 4, 0, 0), 2, 200, 2 },
                    { 8, 30, new TimeSpan(0, 0, 6, 0, 0), 2, 300, 3 },
                    { 9, 40, new TimeSpan(0, 0, 8, 0, 0), 2, 400, 4 },
                    { 10, 50, new TimeSpan(0, 0, 10, 0, 0), 2, 500, 5 },
                    { 11, 10, new TimeSpan(0, 0, 2, 0, 0), 3, 100, 1 },
                    { 12, 20, new TimeSpan(0, 0, 4, 0, 0), 3, 200, 2 },
                    { 13, 30, new TimeSpan(0, 0, 6, 0, 0), 3, 300, 3 },
                    { 14, 40, new TimeSpan(0, 0, 8, 0, 0), 3, 400, 4 },
                    { 15, 50, new TimeSpan(0, 0, 10, 0, 0), 3, 500, 5 },
                    { 16, 10, new TimeSpan(0, 0, 2, 0, 0), 4, 100, 1 },
                    { 17, 20, new TimeSpan(0, 0, 4, 0, 0), 4, 200, 2 },
                    { 18, 30, new TimeSpan(0, 0, 6, 0, 0), 4, 300, 3 },
                    { 19, 40, new TimeSpan(0, 0, 8, 0, 0), 4, 400, 4 },
                    { 20, 50, new TimeSpan(0, 0, 10, 0, 0), 4, 500, 5 },
                    { 21, 10, new TimeSpan(0, 0, 2, 0, 0), 5, 100, 1 },
                    { 22, 20, new TimeSpan(0, 0, 4, 0, 0), 5, 200, 2 },
                    { 23, 30, new TimeSpan(0, 0, 6, 0, 0), 5, 300, 3 },
                    { 24, 40, new TimeSpan(0, 0, 8, 0, 0), 5, 400, 4 },
                    { 25, 50, new TimeSpan(0, 0, 10, 0, 0), 5, 500, 5 },
                    { 26, 10, new TimeSpan(0, 0, 2, 0, 0), 6, 100, 1 },
                    { 27, 20, new TimeSpan(0, 0, 4, 0, 0), 6, 200, 2 },
                    { 28, 30, new TimeSpan(0, 0, 6, 0, 0), 6, 300, 3 },
                    { 29, 40, new TimeSpan(0, 0, 8, 0, 0), 6, 400, 4 },
                    { 30, 50, new TimeSpan(0, 0, 10, 0, 0), 6, 500, 5 },
                    { 31, 10, new TimeSpan(0, 0, 2, 0, 0), 7, 100, 1 },
                    { 32, 20, new TimeSpan(0, 0, 4, 0, 0), 7, 200, 2 },
                    { 33, 30, new TimeSpan(0, 0, 6, 0, 0), 7, 300, 3 },
                    { 34, 40, new TimeSpan(0, 0, 8, 0, 0), 7, 400, 4 },
                    { 35, 50, new TimeSpan(0, 0, 10, 0, 0), 7, 500, 5 },
                    { 36, 10, new TimeSpan(0, 0, 2, 0, 0), 8, 100, 1 },
                    { 37, 20, new TimeSpan(0, 0, 4, 0, 0), 8, 200, 2 },
                    { 38, 30, new TimeSpan(0, 0, 6, 0, 0), 8, 300, 3 },
                    { 39, 40, new TimeSpan(0, 0, 8, 0, 0), 8, 400, 4 },
                    { 40, 50, new TimeSpan(0, 0, 10, 0, 0), 8, 500, 5 },
                    { 41, 10, new TimeSpan(0, 0, 2, 0, 0), 9, 100, 1 },
                    { 42, 20, new TimeSpan(0, 0, 4, 0, 0), 9, 200, 2 },
                    { 43, 30, new TimeSpan(0, 0, 6, 0, 0), 9, 300, 3 },
                    { 44, 40, new TimeSpan(0, 0, 8, 0, 0), 9, 400, 4 },
                    { 45, 50, new TimeSpan(0, 0, 10, 0, 0), 9, 500, 5 },
                    { 46, 10, new TimeSpan(0, 0, 2, 0, 0), 10, 100, 1 },
                    { 47, 20, new TimeSpan(0, 0, 4, 0, 0), 10, 200, 2 },
                    { 48, 30, new TimeSpan(0, 0, 6, 0, 0), 10, 300, 3 },
                    { 49, 40, new TimeSpan(0, 0, 8, 0, 0), 10, 400, 4 },
                    { 50, 50, new TimeSpan(0, 0, 10, 0, 0), 10, 500, 5 },
                    { 51, 10, new TimeSpan(0, 0, 2, 0, 0), 11, 100, 1 },
                    { 52, 20, new TimeSpan(0, 0, 4, 0, 0), 11, 200, 2 },
                    { 53, 30, new TimeSpan(0, 0, 6, 0, 0), 11, 300, 3 },
                    { 54, 40, new TimeSpan(0, 0, 8, 0, 0), 11, 400, 4 },
                    { 55, 50, new TimeSpan(0, 0, 10, 0, 0), 11, 500, 5 },
                    { 56, 10, new TimeSpan(0, 0, 2, 0, 0), 12, 100, 1 },
                    { 57, 20, new TimeSpan(0, 0, 4, 0, 0), 12, 200, 2 },
                    { 58, 30, new TimeSpan(0, 0, 6, 0, 0), 12, 300, 3 },
                    { 59, 40, new TimeSpan(0, 0, 8, 0, 0), 12, 400, 4 },
                    { 60, 50, new TimeSpan(0, 0, 10, 0, 0), 12, 500, 5 },
                    { 61, 10, new TimeSpan(0, 0, 2, 0, 0), 13, 100, 1 },
                    { 62, 20, new TimeSpan(0, 0, 4, 0, 0), 13, 200, 2 },
                    { 63, 30, new TimeSpan(0, 0, 6, 0, 0), 13, 300, 3 },
                    { 64, 40, new TimeSpan(0, 0, 8, 0, 0), 13, 400, 4 },
                    { 65, 50, new TimeSpan(0, 0, 10, 0, 0), 13, 500, 5 },
                    { 66, 10, new TimeSpan(0, 0, 2, 0, 0), 14, 100, 1 },
                    { 67, 20, new TimeSpan(0, 0, 4, 0, 0), 14, 200, 2 },
                    { 68, 30, new TimeSpan(0, 0, 6, 0, 0), 14, 300, 3 },
                    { 69, 40, new TimeSpan(0, 0, 8, 0, 0), 14, 400, 4 },
                    { 70, 50, new TimeSpan(0, 0, 10, 0, 0), 14, 500, 5 },
                    { 71, 10, new TimeSpan(0, 0, 2, 0, 0), 15, 100, 1 },
                    { 72, 20, new TimeSpan(0, 0, 4, 0, 0), 15, 200, 2 },
                    { 73, 30, new TimeSpan(0, 0, 6, 0, 0), 15, 300, 3 },
                    { 74, 40, new TimeSpan(0, 0, 8, 0, 0), 15, 400, 4 },
                    { 75, 50, new TimeSpan(0, 0, 10, 0, 0), 15, 500, 5 },
                    { 76, 10, new TimeSpan(0, 0, 2, 0, 0), 16, 100, 1 },
                    { 77, 20, new TimeSpan(0, 0, 4, 0, 0), 16, 200, 2 },
                    { 78, 30, new TimeSpan(0, 0, 6, 0, 0), 16, 300, 3 },
                    { 79, 40, new TimeSpan(0, 0, 8, 0, 0), 16, 400, 4 },
                    { 80, 50, new TimeSpan(0, 0, 10, 0, 0), 16, 500, 5 },
                    { 81, 10, new TimeSpan(0, 0, 2, 0, 0), 17, 100, 1 },
                    { 82, 20, new TimeSpan(0, 0, 4, 0, 0), 17, 200, 2 },
                    { 83, 30, new TimeSpan(0, 0, 6, 0, 0), 17, 300, 3 },
                    { 84, 40, new TimeSpan(0, 0, 8, 0, 0), 17, 400, 4 },
                    { 85, 50, new TimeSpan(0, 0, 10, 0, 0), 17, 500, 5 },
                    { 86, 10, new TimeSpan(0, 0, 2, 0, 0), 18, 100, 1 },
                    { 87, 20, new TimeSpan(0, 0, 4, 0, 0), 18, 200, 2 },
                    { 88, 30, new TimeSpan(0, 0, 6, 0, 0), 18, 300, 3 },
                    { 89, 40, new TimeSpan(0, 0, 8, 0, 0), 18, 400, 4 },
                    { 90, 50, new TimeSpan(0, 0, 10, 0, 0), 18, 500, 5 },
                    { 91, 10, new TimeSpan(0, 0, 2, 0, 0), 19, 100, 1 },
                    { 92, 20, new TimeSpan(0, 0, 4, 0, 0), 19, 200, 2 },
                    { 93, 30, new TimeSpan(0, 0, 6, 0, 0), 19, 300, 3 },
                    { 94, 40, new TimeSpan(0, 0, 8, 0, 0), 19, 400, 4 },
                    { 95, 50, new TimeSpan(0, 0, 10, 0, 0), 19, 500, 5 },
                    { 96, 10, new TimeSpan(0, 0, 2, 0, 0), 20, 100, 1 },
                    { 97, 20, new TimeSpan(0, 0, 4, 0, 0), 20, 200, 2 },
                    { 98, 30, new TimeSpan(0, 0, 6, 0, 0), 20, 300, 3 },
                    { 99, 40, new TimeSpan(0, 0, 8, 0, 0), 20, 400, 4 },
                    { 100, 50, new TimeSpan(0, 0, 10, 0, 0), 20, 500, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResearchNode_ResearchTableId",
                table: "ResearchNode",
                column: "ResearchTableId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchNodeUpgradeNecessaries_ResearchNodeId",
                table: "ResearchNodeUpgradeNecessaries",
                column: "ResearchNodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResearchNodeUpgradeNecessaries");

            migrationBuilder.DropTable(
                name: "ResearchNode");

            migrationBuilder.DropTable(
                name: "ResearchTable");
        }
    }
}
