using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class heroskillentitiesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        name: "FK_HeroSkillLevel_HeroSkill_HeroSkillId",
                        column: x => x.HeroSkillId,
                        principalTable: "HeroSkill",
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

            migrationBuilder.InsertData(
                table: "HeroSkill",
                columns: new[] { "Id", "Description", "HeroId", "IsPassiveSkill", "MaksLevel", "Name", "PlaceId", "TumbnailUrl" },
                values: new object[,]
                {
                    { 1, "dummy hero description", 1, false, 5, "HeroSkill_1", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 2, "dummy hero description", 1, true, 5, "HeroSkill_2", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 3, "dummy hero description", 1, true, 5, "HeroSkill_3", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 4, "dummy hero description", 1, true, 5, "HeroSkill_4", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 5, "dummy hero description", 2, false, 5, "HeroSkill_1", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 6, "dummy hero description", 2, true, 5, "HeroSkill_2", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 7, "dummy hero description", 2, true, 5, "HeroSkill_3", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 8, "dummy hero description", 2, true, 5, "HeroSkill_4", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 9, "dummy hero description", 3, false, 5, "HeroSkill_1", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 10, "dummy hero description", 3, true, 5, "HeroSkill_2", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 11, "dummy hero description", 3, true, 5, "HeroSkill_3", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 12, "dummy hero description", 3, true, 5, "HeroSkill_4", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 13, "dummy hero description", 4, false, 5, "HeroSkill_1", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 14, "dummy hero description", 4, true, 5, "HeroSkill_2", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 15, "dummy hero description", 4, true, 5, "HeroSkill_3", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 16, "dummy hero description", 4, true, 5, "HeroSkill_4", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 17, "dummy hero description", 5, false, 5, "HeroSkill_1", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 18, "dummy hero description", 5, true, 5, "HeroSkill_2", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 19, "dummy hero description", 5, true, 5, "HeroSkill_3", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 20, "dummy hero description", 5, true, 5, "HeroSkill_4", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 21, "dummy hero description", 6, false, 5, "HeroSkill_1", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 22, "dummy hero description", 6, true, 5, "HeroSkill_2", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 23, "dummy hero description", 6, true, 5, "HeroSkill_3", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 24, "dummy hero description", 6, true, 5, "HeroSkill_4", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 25, "dummy hero description", 7, false, 5, "HeroSkill_1", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 26, "dummy hero description", 7, true, 5, "HeroSkill_2", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 27, "dummy hero description", 7, true, 5, "HeroSkill_3", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 28, "dummy hero description", 7, true, 5, "HeroSkill_4", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 29, "dummy hero description", 8, false, 5, "HeroSkill_1", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 30, "dummy hero description", 8, true, 5, "HeroSkill_2", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 31, "dummy hero description", 8, true, 5, "HeroSkill_3", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 32, "dummy hero description", 8, true, 5, "HeroSkill_4", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 33, "dummy hero description", 9, false, 5, "HeroSkill_1", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 34, "dummy hero description", 9, true, 5, "HeroSkill_2", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 35, "dummy hero description", 9, true, 5, "HeroSkill_3", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 36, "dummy hero description", 9, true, 5, "HeroSkill_4", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 37, "dummy hero description", 10, false, 5, "HeroSkill_1", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 38, "dummy hero description", 10, true, 5, "HeroSkill_2", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 39, "dummy hero description", 10, true, 5, "HeroSkill_3", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 40, "dummy hero description", 10, true, 5, "HeroSkill_4", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 41, "dummy hero description", 11, false, 5, "HeroSkill_1", 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 42, "dummy hero description", 11, true, 5, "HeroSkill_2", 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 43, "dummy hero description", 11, true, 5, "HeroSkill_3", 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" },
                    { 44, "dummy hero description", 11, true, 5, "HeroSkill_4", 4, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png" }
                });

            migrationBuilder.InsertData(
                table: "HeroSkillLevel",
                columns: new[] { "Id", "BuffId", "HeroSkillId", "Level" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 1, 2 },
                    { 3, 1, 1, 3 },
                    { 4, 1, 1, 4 },
                    { 5, 1, 1, 5 },
                    { 6, 1, 2, 1 },
                    { 7, 1, 2, 2 },
                    { 8, 1, 2, 3 },
                    { 9, 1, 2, 4 },
                    { 10, 1, 2, 5 },
                    { 11, 1, 3, 1 },
                    { 12, 1, 3, 2 },
                    { 13, 1, 3, 3 },
                    { 14, 1, 3, 4 },
                    { 15, 1, 3, 5 },
                    { 16, 1, 4, 1 },
                    { 17, 1, 4, 2 },
                    { 18, 1, 4, 3 },
                    { 19, 1, 4, 4 },
                    { 20, 1, 4, 5 },
                    { 21, 1, 5, 1 },
                    { 22, 1, 5, 2 },
                    { 23, 1, 5, 3 },
                    { 24, 1, 5, 4 },
                    { 25, 1, 5, 5 },
                    { 26, 1, 6, 1 },
                    { 27, 1, 6, 2 },
                    { 28, 1, 6, 3 },
                    { 29, 1, 6, 4 },
                    { 30, 1, 6, 5 },
                    { 31, 1, 7, 1 },
                    { 32, 1, 7, 2 },
                    { 33, 1, 7, 3 },
                    { 34, 1, 7, 4 },
                    { 35, 1, 7, 5 },
                    { 36, 1, 8, 1 },
                    { 37, 1, 8, 2 },
                    { 38, 1, 8, 3 },
                    { 39, 1, 8, 4 },
                    { 40, 1, 8, 5 },
                    { 41, 1, 9, 1 },
                    { 42, 1, 9, 2 },
                    { 43, 1, 9, 3 },
                    { 44, 1, 9, 4 },
                    { 45, 1, 9, 5 },
                    { 46, 1, 10, 1 },
                    { 47, 1, 10, 2 },
                    { 48, 1, 10, 3 },
                    { 49, 1, 10, 4 },
                    { 50, 1, 10, 5 },
                    { 51, 1, 11, 1 },
                    { 52, 1, 11, 2 },
                    { 53, 1, 11, 3 },
                    { 54, 1, 11, 4 },
                    { 55, 1, 11, 5 },
                    { 56, 1, 12, 1 },
                    { 57, 1, 12, 2 },
                    { 58, 1, 12, 3 },
                    { 59, 1, 12, 4 },
                    { 60, 1, 12, 5 },
                    { 61, 1, 13, 1 },
                    { 62, 1, 13, 2 },
                    { 63, 1, 13, 3 },
                    { 64, 1, 13, 4 },
                    { 65, 1, 13, 5 },
                    { 66, 1, 14, 1 },
                    { 67, 1, 14, 2 },
                    { 68, 1, 14, 3 },
                    { 69, 1, 14, 4 },
                    { 70, 1, 14, 5 },
                    { 71, 1, 15, 1 },
                    { 72, 1, 15, 2 },
                    { 73, 1, 15, 3 },
                    { 74, 1, 15, 4 },
                    { 75, 1, 15, 5 },
                    { 76, 1, 16, 1 },
                    { 77, 1, 16, 2 },
                    { 78, 1, 16, 3 },
                    { 79, 1, 16, 4 },
                    { 80, 1, 16, 5 },
                    { 81, 1, 17, 1 },
                    { 82, 1, 17, 2 },
                    { 83, 1, 17, 3 },
                    { 84, 1, 17, 4 },
                    { 85, 1, 17, 5 },
                    { 86, 1, 18, 1 },
                    { 87, 1, 18, 2 },
                    { 88, 1, 18, 3 },
                    { 89, 1, 18, 4 },
                    { 90, 1, 18, 5 },
                    { 91, 1, 19, 1 },
                    { 92, 1, 19, 2 },
                    { 93, 1, 19, 3 },
                    { 94, 1, 19, 4 },
                    { 95, 1, 19, 5 },
                    { 96, 1, 20, 1 },
                    { 97, 1, 20, 2 },
                    { 98, 1, 20, 3 },
                    { 99, 1, 20, 4 },
                    { 100, 1, 20, 5 },
                    { 101, 1, 21, 1 },
                    { 102, 1, 21, 2 },
                    { 103, 1, 21, 3 },
                    { 104, 1, 21, 4 },
                    { 105, 1, 21, 5 },
                    { 106, 1, 22, 1 },
                    { 107, 1, 22, 2 },
                    { 108, 1, 22, 3 },
                    { 109, 1, 22, 4 },
                    { 110, 1, 22, 5 },
                    { 111, 1, 23, 1 },
                    { 112, 1, 23, 2 },
                    { 113, 1, 23, 3 },
                    { 114, 1, 23, 4 },
                    { 115, 1, 23, 5 },
                    { 116, 1, 24, 1 },
                    { 117, 1, 24, 2 },
                    { 118, 1, 24, 3 },
                    { 119, 1, 24, 4 },
                    { 120, 1, 24, 5 },
                    { 121, 1, 25, 1 },
                    { 122, 1, 25, 2 },
                    { 123, 1, 25, 3 },
                    { 124, 1, 25, 4 },
                    { 125, 1, 25, 5 },
                    { 126, 1, 26, 1 },
                    { 127, 1, 26, 2 },
                    { 128, 1, 26, 3 },
                    { 129, 1, 26, 4 },
                    { 130, 1, 26, 5 },
                    { 131, 1, 27, 1 },
                    { 132, 1, 27, 2 },
                    { 133, 1, 27, 3 },
                    { 134, 1, 27, 4 },
                    { 135, 1, 27, 5 },
                    { 136, 1, 28, 1 },
                    { 137, 1, 28, 2 },
                    { 138, 1, 28, 3 },
                    { 139, 1, 28, 4 },
                    { 140, 1, 28, 5 },
                    { 141, 1, 29, 1 },
                    { 142, 1, 29, 2 },
                    { 143, 1, 29, 3 },
                    { 144, 1, 29, 4 },
                    { 145, 1, 29, 5 },
                    { 146, 1, 30, 1 },
                    { 147, 1, 30, 2 },
                    { 148, 1, 30, 3 },
                    { 149, 1, 30, 4 },
                    { 150, 1, 30, 5 },
                    { 151, 1, 31, 1 },
                    { 152, 1, 31, 2 },
                    { 153, 1, 31, 3 },
                    { 154, 1, 31, 4 },
                    { 155, 1, 31, 5 },
                    { 156, 1, 32, 1 },
                    { 157, 1, 32, 2 },
                    { 158, 1, 32, 3 },
                    { 159, 1, 32, 4 },
                    { 160, 1, 32, 5 },
                    { 161, 1, 33, 1 },
                    { 162, 1, 33, 2 },
                    { 163, 1, 33, 3 },
                    { 164, 1, 33, 4 },
                    { 165, 1, 33, 5 },
                    { 166, 1, 34, 1 },
                    { 167, 1, 34, 2 },
                    { 168, 1, 34, 3 },
                    { 169, 1, 34, 4 },
                    { 170, 1, 34, 5 },
                    { 171, 1, 35, 1 },
                    { 172, 1, 35, 2 },
                    { 173, 1, 35, 3 },
                    { 174, 1, 35, 4 },
                    { 175, 1, 35, 5 },
                    { 176, 1, 36, 1 },
                    { 177, 1, 36, 2 },
                    { 178, 1, 36, 3 },
                    { 179, 1, 36, 4 },
                    { 180, 1, 36, 5 },
                    { 181, 1, 37, 1 },
                    { 182, 1, 37, 2 },
                    { 183, 1, 37, 3 },
                    { 184, 1, 37, 4 },
                    { 185, 1, 37, 5 },
                    { 186, 1, 38, 1 },
                    { 187, 1, 38, 2 },
                    { 188, 1, 38, 3 },
                    { 189, 1, 38, 4 },
                    { 190, 1, 38, 5 },
                    { 191, 1, 39, 1 },
                    { 192, 1, 39, 2 },
                    { 193, 1, 39, 3 },
                    { 194, 1, 39, 4 },
                    { 195, 1, 39, 5 },
                    { 196, 1, 40, 1 },
                    { 197, 1, 40, 2 },
                    { 198, 1, 40, 3 },
                    { 199, 1, 40, 4 },
                    { 200, 1, 40, 5 },
                    { 201, 1, 41, 1 },
                    { 202, 1, 41, 2 },
                    { 203, 1, 41, 3 },
                    { 204, 1, 41, 4 },
                    { 205, 1, 41, 5 },
                    { 206, 1, 42, 1 },
                    { 207, 1, 42, 2 },
                    { 208, 1, 42, 3 },
                    { 209, 1, 42, 4 },
                    { 210, 1, 42, 5 },
                    { 211, 1, 43, 1 },
                    { 212, 1, 43, 2 },
                    { 213, 1, 43, 3 },
                    { 214, 1, 43, 4 },
                    { 215, 1, 43, 5 },
                    { 216, 1, 44, 1 },
                    { 217, 1, 44, 2 },
                    { 218, 1, 44, 3 },
                    { 219, 1, 44, 4 },
                    { 220, 1, 44, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroSkill_HeroId",
                table: "HeroSkill",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroSkillLevel_HeroSkillId",
                table: "HeroSkillLevel",
                column: "HeroSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerHeroSkillLevel_HeroSkillLevelId",
                table: "PlayerHeroSkillLevel",
                column: "HeroSkillLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerHeroSkillLevel");

            migrationBuilder.DropTable(
                name: "HeroSkillLevel");

            migrationBuilder.DropTable(
                name: "HeroSkill");
        }
    }
}
