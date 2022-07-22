using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProgressApi.Migrations
{
    public partial class progress_classes_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProcess_Stage_StageId",
                table: "UserProcess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProcess",
                table: "UserProcess");

            migrationBuilder.DeleteData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "UserProcess",
                newName: "UserProgress");

            migrationBuilder.RenameIndex(
                name: "IX_UserProcess_StageId",
                table: "UserProgress",
                newName: "IX_UserProgress_StageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProgress",
                table: "UserProgress",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tower",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tower", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zombie",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zombie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TowerProgress",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TowerId = table.Column<long>(type: "bigint", nullable: false),
                    UserProgressId = table.Column<long>(type: "bigint", nullable: false),
                    TowerName = table.Column<long>(type: "bigint", nullable: false),
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
                        name: "FK_TowerProgress_UserProgress_UserProgressId",
                        column: x => x.UserProgressId,
                        principalTable: "UserProgress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZombieKill",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProgressId = table.Column<long>(type: "bigint", nullable: false),
                    ZombieId = table.Column<long>(type: "bigint", nullable: false),
                    DeadCount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZombieKill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZombieKill_UserProgress_UserProgressId",
                        column: x => x.UserProgressId,
                        principalTable: "UserProgress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZombieKill_Zombie_ZombieId",
                        column: x => x.ZombieId,
                        principalTable: "Zombie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tower",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1L, true, "StandartTower" },
                    { 2L, true, "ShortRangeAOETower" },
                    { 3L, true, "MeleeTower" },
                    { 4L, true, "SlowTower" },
                    { 5L, true, "SniperTower" },
                    { 6L, true, "LongRangeAOETower" },
                    { 7L, true, "ShortRangeAOEStackingDamageTower" },
                    { 8L, true, "PiercingMediumRangeTower" },
                    { 9L, true, "CommandTower" }
                });

            migrationBuilder.InsertData(
                table: "Zombie",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1L, true, "z1" },
                    { 2L, true, "z2" },
                    { 3L, true, "z3" },
                    { 4L, true, "z4" },
                    { 5L, true, "z5" },
                    { 6L, true, "z6" },
                    { 7L, true, "z7" },
                    { 8L, true, "z8" },
                    { 9L, true, "z9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TowerProgress_TowerId",
                table: "TowerProgress",
                column: "TowerId");

            migrationBuilder.CreateIndex(
                name: "IX_TowerProgress_UserProgressId",
                table: "TowerProgress",
                column: "UserProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_ZombieKill_UserProgressId",
                table: "ZombieKill",
                column: "UserProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_ZombieKill_ZombieId",
                table: "ZombieKill",
                column: "ZombieId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProgress_Stage_StageId",
                table: "UserProgress",
                column: "StageId",
                principalTable: "Stage",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProgress_Stage_StageId",
                table: "UserProgress");

            migrationBuilder.DropTable(
                name: "TowerProgress");

            migrationBuilder.DropTable(
                name: "ZombieKill");

            migrationBuilder.DropTable(
                name: "Tower");

            migrationBuilder.DropTable(
                name: "Zombie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProgress",
                table: "UserProgress");

            migrationBuilder.RenameTable(
                name: "UserProgress",
                newName: "UserProcess");

            migrationBuilder.RenameIndex(
                name: "IX_UserProgress_StageId",
                table: "UserProcess",
                newName: "IX_UserProcess_StageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProcess",
                table: "UserProcess",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Stage",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[] { 1, "", true, "FirstStage" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserProcess_Stage_StageId",
                table: "UserProcess",
                column: "StageId",
                principalTable: "Stage",
                principalColumn: "Id");
        }
    }
}
