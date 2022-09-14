using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class heroentitiesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "PlayerHero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Exp = table.Column<long>(type: "bigint", nullable: false),
                    CurrentLevel = table.Column<int>(type: "integer", nullable: false),
                    TalentPoint = table.Column<int>(type: "integer", nullable: false),
                    SkillPoint = table.Column<int>(type: "integer", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerHero", x => x.Id);
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
                name: "TalentTreeNode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    HeroId = table.Column<int>(type: "integer", nullable: false),
                    TalentTreeId = table.Column<int>(type: "integer", nullable: false),
                    BuffId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentTreeNode", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTalentTreeNode_TalentTreeNodeId",
                table: "PlayerTalentTreeNode",
                column: "TalentTreeNodeId");

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
                name: "PlayerHero");

            migrationBuilder.DropTable(
                name: "PlayerTalentTreeNode");

            migrationBuilder.DropTable(
                name: "TalentTreeNode");

            migrationBuilder.DropTable(
                name: "Hero");

            migrationBuilder.DropTable(
                name: "TalentTree");
        }
    }
}
