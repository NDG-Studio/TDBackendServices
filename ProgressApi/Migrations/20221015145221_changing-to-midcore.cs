using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProgressApi.Migrations
{
    public partial class changingtomidcore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TowerProgress_UserProgress_UserProgressId",
                table: "TowerProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProgress_Stage_StageId",
                table: "UserProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_ZombieKill_Zombie_ZombieId",
                table: "ZombieKill");

            migrationBuilder.DropIndex(
                name: "IX_ZombieKill_ZombieId",
                table: "ZombieKill");

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DropColumn(
                name: "ZombieId",
                table: "ZombieKill");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "UserProgress");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserProgress");

            migrationBuilder.DropColumn(
                name: "Ip",
                table: "UserProgress");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "UserProgress");

            migrationBuilder.DropColumn(
                name: "StarCount",
                table: "UserProgress");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "UserProgress");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "UserProgress");

            migrationBuilder.DropColumn(
                name: "TowerName",
                table: "TowerProgress");

            migrationBuilder.RenameColumn(
                name: "StageStartTime",
                table: "UserProgress",
                newName: "WaveStartTime");

            migrationBuilder.RenameColumn(
                name: "StageId",
                table: "UserProgress",
                newName: "WaveId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProgress_StageId",
                table: "UserProgress",
                newName: "IX_UserProgress_WaveId");

            migrationBuilder.RenameColumn(
                name: "UserProgressId",
                table: "TowerProgress",
                newName: "UserProgressHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_TowerProgress_UserProgressId",
                table: "TowerProgress",
                newName: "IX_TowerProgress_UserProgressHistoryId");

            migrationBuilder.AddColumn<int>(
                name: "EnemyId",
                table: "ZombieKill",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Zombie",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "WaveEndTime",
                table: "UserProgress",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "TowerId",
                table: "TowerProgress",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tower",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Coin",
                table: "Stage",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SceneId",
                table: "Stage",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Wave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StageId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wave_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "01,1", "01,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "01,2", "01,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "01,3", "01,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "01,4", "01,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "01,5", "01,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "01,6", "01,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "01,7", "01,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "01,8", "01,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "01,9", "01,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 20,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "02,1", "02,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "02,2", "02,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "02,3", "02,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "02,4", "02,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "02,5", "02,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "02,6", "02,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "02,7", "02,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "02,8", "02,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "02,9", "02,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 30,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "03,1", "03,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "03,2", "03,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "03,3", "03,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "03,4", "03,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "03,5", "03,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "03,6", "03,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "03,7", "03,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "03,8", "03,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "03,9", "03,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 40,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "04,1", "04,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "04,2", "04,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "04,3", "04,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "04,4", "04,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "04,5", "04,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "04,6", "04,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "04,7", "04,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "04,8", "04,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "04,9", "04,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 50,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "05,1", "05,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "05,2", "05,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "05,3", "05,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "05,4", "05,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "05,5", "05,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "05,6", "05,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "05,7", "05,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "05,8", "05,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "05,9", "05,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 60,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "06,1", "06,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "06,2", "06,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "06,3", "06,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "06,4", "06,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "06,5", "06,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "06,6", "06,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "06,7", "06,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "06,8", "06,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "06,9", "06,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 70,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "07,1", "07,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "07,2", "07,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "07,3", "07,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "07,4", "07,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "07,5", "07,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "07,6", "07,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "07,7", "07,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "07,8", "07,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "07,9", "07,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 80,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "08,1", "08,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "08,2", "08,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "08,3", "08,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "08,4", "08,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "08,5", "08,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "08,6", "08,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "08,7", "08,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "08,8", "08,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "08,9", "08,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 90,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "09,1", "09,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "09,2", "09,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "09,3", "09,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "09,4", "09,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "09,5", "09,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "09,6", "09,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "09,7", "09,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "09,8", "09,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "09,9", "09,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 100,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "10,1", "10,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "10,2", "10,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "10,3", "10,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "10,4", "10,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "10,5", "10,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "10,6", "10,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "10,7", "10,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "10,8", "10,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "10,9", "10,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 110,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "11,1", "11,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "11,2", "11,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "11,3", "11,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "11,4", "11,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "11,5", "11,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "11,6", "11,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "11,7", "11,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "11,8", "11,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "11,9", "11,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 120,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "12,1", "12,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "12,2", "12,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "12,3", "12,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "12,4", "12,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "12,5", "12,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "12,6", "12,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "12,7", "12,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "12,8", "12,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "12,9", "12,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 130,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "13,1", "13,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "13,2", "13,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "13,3", "13,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "13,4", "13,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "13,5", "13,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "13,6", "13,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "13,7", "13,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "13,8", "13,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "13,9", "13,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 140,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "14,1", "14,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "14,2", "14,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "14,3", "14,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "14,4", "14,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "14,5", "14,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "14,6", "14,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "14,7", "14,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "14,8", "14,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "14,9", "14,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 150,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "15,1", "15,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "15,2", "15,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "15,3", "15,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "15,4", "15,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "15,5", "15,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "15,6", "15,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "15,7", "15,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "15,8", "15,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "15,9", "15,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 160,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "16,1", "16,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "16,2", "16,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "16,3", "16,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "16,4", "16,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "16,5", "16,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "16,6", "16,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "16,7", "16,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "16,8", "16,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "16,9", "16,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 170,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "17,1", "17,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "17,2", "17,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "17,3", "17,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "17,4", "17,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "17,5", "17,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "17,6", "17,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "17,7", "17,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "17,8", "17,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "17,9", "17,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 180,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "18,1", "18,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "18,2", "18,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "18,3", "18,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "18,4", "18,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "18,5", "18,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "18,6", "18,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "18,7", "18,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "18,8", "18,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "18,9", "18,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 190,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "19,1", "19,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "19,2", "19,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "19,3", "19,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "19,4", "19,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "19,5", "19,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "19,6", "19,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "19,7", "19,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "19,8", "19,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "19,9", "19,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 200,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "20,1", "20,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "20,2", "20,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "20,3", "20,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "20,4", "20,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "20,5", "20,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "20,6", "20,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "20,7", "20,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "20,8", "20,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "20,9", "20,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 210,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "21,1", "21,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "21,2", "21,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "21,3", "21,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "21,4", "21,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "21,5", "21,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "21,6", "21,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "21,7", "21,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "21,8", "21,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "21,9", "21,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 220,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "22,1", "22,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "22,2", "22,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "22,3", "22,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "22,4", "22,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "22,5", "22,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "22,6", "22,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "22,7", "22,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "22,8", "22,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "22,9", "22,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 230,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "23,1", "23,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "23,2", "23,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "23,3", "23,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "23,4", "23,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "23,5", "23,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "23,6", "23,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "23,7", "23,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "23,8", "23,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "23,9", "23,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 240,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "24,1", "24,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "24,2", "24,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "24,3", "24,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "24,4", "24,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "24,5", "24,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "24,6", "24,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "24,7", "24,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "24,8", "24,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "24,9", "24,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 250,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "25,1", "25,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "25,2", "25,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "25,3", "25,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "25,4", "25,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "25,5", "25,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "25,6", "25,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "25,7", "25,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "25,8", "25,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "25,9", "25,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 260,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "26,1", "26,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "26,2", "26,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "26,3", "26,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "26,4", "26,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "26,5", "26,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "26,6", "26,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "26,7", "26,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "26,8", "26,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "26,9", "26,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 270,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "27,1", "27,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "27,2", "27,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "27,3", "27,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "27,4", "27,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "27,5", "27,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "27,6", "27,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "27,7", "27,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "27,8", "27,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "27,9", "27,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 280,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "28,1", "28,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "28,2", "28,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "28,3", "28,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "28,4", "28,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "28,5", "28,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "28,6", "28,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "28,7", "28,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "28,8", "28,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "28,9", "28,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 290,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "29,1", "29,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "29,2", "29,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "29,3", "29,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "29,4", "29,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "29,5", "29,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "29,6", "29,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "29,7", "29,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "29,8", "29,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "29,9", "29,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 300,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "30,1", "30,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "30,2", "30,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "30,3", "30,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "30,4", "30,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "30,5", "30,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 306,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "30,6", "30,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 307,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "30,7", "30,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 308,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "30,8", "30,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 309,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "30,9", "30,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 310,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 311,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "31,1", "31,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 312,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "31,2", "31,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 313,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "31,3", "31,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 314,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "31,4", "31,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 315,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "31,5", "31,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 316,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "31,6", "31,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 317,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "31,7", "31,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 318,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "31,8", "31,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 319,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "31,9", "31,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 320,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 321,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "32,1", "32,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 322,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "32,2", "32,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 323,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "32,3", "32,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 324,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "32,4", "32,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 325,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "32,5", "32,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 326,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "32,6", "32,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 327,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "32,7", "32,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 328,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "32,8", "32,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 329,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "32,9", "32,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 330,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 331,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "33,1", "33,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 332,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "33,2", "33,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 333,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "33,3", "33,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 334,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "33,4", "33,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 335,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "33,5", "33,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 336,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "33,6", "33,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 337,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "33,7", "33,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 338,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "33,8", "33,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 339,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "33,9", "33,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 340,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 341,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "34,1", "34,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 342,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "34,2", "34,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 343,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "34,3", "34,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 344,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "34,4", "34,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 345,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "34,5", "34,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 346,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "34,6", "34,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 347,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "34,7", "34,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 348,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "34,8", "34,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 349,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "34,9", "34,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 350,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 351,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "35,1", "35,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 352,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "35,2", "35,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 353,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "35,3", "35,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 354,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "35,4", "35,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 355,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "35,5", "35,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 356,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "35,6", "35,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 357,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "35,7", "35,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 358,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "35,8", "35,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 359,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "35,9", "35,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 360,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 361,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "36,1", "36,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 362,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "36,2", "36,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 363,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "36,3", "36,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 364,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "36,4", "36,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 365,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "36,5", "36,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 366,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "36,6", "36,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 367,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "36,7", "36,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 368,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "36,8", "36,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 369,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "36,9", "36,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 370,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 371,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "37,1", "37,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 372,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "37,2", "37,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 373,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "37,3", "37,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 374,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "37,4", "37,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 375,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "37,5", "37,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 376,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "37,6", "37,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 377,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "37,7", "37,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 378,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "37,8", "37,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 379,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "37,9", "37,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 380,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 381,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "38,1", "38,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 382,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "38,2", "38,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 383,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "38,3", "38,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 384,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "38,4", "38,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 385,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "38,5", "38,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 386,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "38,6", "38,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 387,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "38,7", "38,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 388,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "38,8", "38,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 389,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "38,9", "38,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 390,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 391,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "39,1", "39,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 392,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "39,2", "39,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 393,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "39,3", "39,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 394,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "39,4", "39,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 395,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "39,5", "39,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 396,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "39,6", "39,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 397,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "39,7", "39,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 398,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "39,8", "39,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 399,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "39,9", "39,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 400,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 401,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "40,1", "40,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 402,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "40,2", "40,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 403,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "40,3", "40,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 404,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "40,4", "40,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 405,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "40,5", "40,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 406,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "40,6", "40,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 407,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "40,7", "40,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 408,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "40,8", "40,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 409,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "40,9", "40,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 410,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 411,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "41,1", "41,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 412,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "41,2", "41,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 413,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "41,3", "41,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 414,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "41,4", "41,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 415,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "41,5", "41,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 416,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "41,6", "41,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 417,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "41,7", "41,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 418,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "41,8", "41,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 419,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "41,9", "41,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 420,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 421,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "42,1", "42,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 422,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "42,2", "42,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 423,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "42,3", "42,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 424,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "42,4", "42,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 425,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "42,5", "42,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 426,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "42,6", "42,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 427,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "42,7", "42,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 428,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "42,8", "42,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 429,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "42,9", "42,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 430,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 431,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "43,1", "43,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 432,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "43,2", "43,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 433,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "43,3", "43,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 434,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "43,4", "43,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 435,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "43,5", "43,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 436,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "43,6", "43,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 437,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "43,7", "43,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 438,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "43,8", "43,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 439,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "43,9", "43,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 440,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 441,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "44,1", "44,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 442,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "44,2", "44,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 443,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "44,3", "44,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 444,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "44,4", "44,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 445,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "44,5", "44,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 446,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "44,6", "44,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 447,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "44,7", "44,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 448,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "44,8", "44,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 449,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "44,9", "44,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 450,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 451,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "45,1", "45,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 452,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "45,2", "45,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 453,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "45,3", "45,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 454,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "45,4", "45,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 455,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "45,5", "45,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 456,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "45,6", "45,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 457,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "45,7", "45,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 458,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "45,8", "45,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 459,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "45,9", "45,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 460,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 461,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "46,1", "46,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 462,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "46,2", "46,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 463,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "46,3", "46,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 464,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "46,4", "46,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 465,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "46,5", "46,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 466,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "46,6", "46,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 467,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "46,7", "46,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 468,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "46,8", "46,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 469,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "46,9", "46,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 470,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 471,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "47,1", "47,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 472,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "47,2", "47,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 473,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "47,3", "47,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 474,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "47,4", "47,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 475,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "47,5", "47,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 476,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "47,6", "47,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 477,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "47,7", "47,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 478,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "47,8", "47,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 479,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "47,9", "47,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 480,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 481,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "48,1", "48,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 482,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "48,2", "48,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 483,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "48,3", "48,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 484,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "48,4", "48,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 485,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "48,5", "48,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 486,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "48,6", "48,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 487,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "48,7", "48,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 488,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "48,8", "48,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 489,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "48,9", "48,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 490,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 491,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "49,1", "49,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 492,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "49,2", "49,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 493,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "49,3", "49,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 494,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "49,4", "49,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 495,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "49,5", "49,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 496,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "49,6", "49,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 497,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "49,7", "49,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 498,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "49,8", "49,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 499,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "49,9", "49,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 500,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 501,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "50,1", "50,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 502,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "50,2", "50,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 503,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "50,3", "50,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 504,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "50,4", "50,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 505,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "50,5", "50,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 506,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "50,6", "50,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 507,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "50,7", "50,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 508,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "50,8", "50,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 509,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "50,9", "50,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 510,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 511,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "51,1", "51,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 512,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "51,2", "51,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 513,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "51,3", "51,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 514,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "51,4", "51,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 515,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "51,5", "51,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 516,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "51,6", "51,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 517,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "51,7", "51,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 518,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "51,8", "51,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 519,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "51,9", "51,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 520,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 521,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "52,1", "52,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 522,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "52,2", "52,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 523,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "52,3", "52,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 524,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "52,4", "52,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 525,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "52,5", "52,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 526,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "52,6", "52,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 527,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "52,7", "52,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 528,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "52,8", "52,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 529,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "52,9", "52,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 530,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 531,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "53,1", "53,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 532,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "53,2", "53,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 533,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "53,3", "53,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 534,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "53,4", "53,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 535,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "53,5", "53,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 536,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "53,6", "53,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 537,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "53,7", "53,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 538,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "53,8", "53,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 539,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "53,9", "53,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 540,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 541,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "54,1", "54,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 542,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "54,2", "54,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 543,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "54,3", "54,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 544,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "54,4", "54,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 545,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "54,5", "54,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 546,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "54,6", "54,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 547,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "54,7", "54,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 548,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "54,8", "54,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 549,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "54,9", "54,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 550,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 551,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "55,1", "55,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 552,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "55,2", "55,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 553,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "55,3", "55,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 554,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "55,4", "55,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 555,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "55,5", "55,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 556,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "55,6", "55,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 557,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "55,7", "55,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 558,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "55,8", "55,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 559,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "55,9", "55,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 560,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 561,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "56,1", "56,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 562,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "56,2", "56,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 563,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "56,3", "56,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 564,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "56,4", "56,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 565,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "56,5", "56,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 566,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "56,6", "56,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 567,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "56,7", "56,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 568,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "56,8", "56,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 569,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "56,9", "56,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 570,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 571,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "57,1", "57,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 572,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "57,2", "57,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 573,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "57,3", "57,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 574,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "57,4", "57,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 575,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "57,5", "57,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 576,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "57,6", "57,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 577,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "57,7", "57,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 578,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "57,8", "57,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 579,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "57,9", "57,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 580,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 581,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "58,1", "58,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 582,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "58,2", "58,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 583,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "58,3", "58,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 584,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "58,4", "58,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 585,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "58,5", "58,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 586,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "58,6", "58,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 587,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "58,7", "58,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 588,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "58,8", "58,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 589,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "58,9", "58,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 590,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 591,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "59,1", "59,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 592,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "59,2", "59,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 593,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "59,3", "59,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 594,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "59,4", "59,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 595,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "59,5", "59,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 596,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "59,6", "59,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 597,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "59,7", "59,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 598,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "59,8", "59,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 599,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "59,9", "59,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 600,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 601,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "60,1", "60,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 602,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "60,2", "60,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 603,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "60,3", "60,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 604,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "60,4", "60,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 605,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "60,5", "60,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 606,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "60,6", "60,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 607,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "60,7", "60,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 608,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "60,8", "60,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 609,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "60,9", "60,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 610,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 611,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "61,1", "61,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 612,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "61,2", "61,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 613,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "61,3", "61,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 614,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "61,4", "61,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 615,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "61,5", "61,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 616,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "61,6", "61,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 617,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "61,7", "61,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 618,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "61,8", "61,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 619,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "61,9", "61,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 620,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 621,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "62,1", "62,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 622,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "62,2", "62,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 623,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "62,3", "62,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 624,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "62,4", "62,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 625,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "62,5", "62,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 626,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "62,6", "62,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 627,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "62,7", "62,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 628,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "62,8", "62,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 629,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "62,9", "62,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 630,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 631,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "63,1", "63,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 632,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "63,2", "63,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 633,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "63,3", "63,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 634,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "63,4", "63,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 635,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "63,5", "63,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 636,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "63,6", "63,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 637,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "63,7", "63,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 638,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "63,8", "63,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 639,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "63,9", "63,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 640,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 641,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "64,1", "64,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 642,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "64,2", "64,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 643,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "64,3", "64,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 644,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "64,4", "64,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 645,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "64,5", "64,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 646,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "64,6", "64,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 647,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "64,7", "64,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 648,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "64,8", "64,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 649,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "64,9", "64,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 650,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 651,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "65,1", "65,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 652,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "65,2", "65,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 653,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "65,3", "65,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 654,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "65,4", "65,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 655,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "65,5", "65,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 656,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "65,6", "65,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 657,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "65,7", "65,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 658,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "65,8", "65,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 659,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "65,9", "65,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 660,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 661,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "66,1", "66,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 662,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "66,2", "66,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 663,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "66,3", "66,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 664,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "66,4", "66,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 665,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "66,5", "66,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 666,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "66,6", "66,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 667,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "66,7", "66,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 668,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "66,8", "66,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 669,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "66,9", "66,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 670,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 671,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "67,1", "67,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 672,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "67,2", "67,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 673,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "67,3", "67,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 674,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "67,4", "67,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 675,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "67,5", "67,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 676,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "67,6", "67,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 677,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "67,7", "67,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 678,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "67,8", "67,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 679,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "67,9", "67,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 680,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 681,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "68,1", "68,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 682,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "68,2", "68,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 683,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "68,3", "68,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 684,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "68,4", "68,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 685,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "68,5", "68,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 686,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "68,6", "68,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 687,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "68,7", "68,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 688,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "68,8", "68,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 689,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "68,9", "68,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 690,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 691,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "69,1", "69,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 692,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "69,2", "69,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 693,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "69,3", "69,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 694,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "69,4", "69,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 695,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "69,5", "69,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 696,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "69,6", "69,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 697,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "69,7", "69,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 698,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "69,8", "69,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 699,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "69,9", "69,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 700,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 701,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "70,1", "70,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 702,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "70,2", "70,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 703,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "70,3", "70,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 704,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "70,4", "70,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 705,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "70,5", "70,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 706,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "70,6", "70,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 707,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "70,7", "70,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 708,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "70,8", "70,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 709,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "70,9", "70,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 710,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 711,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "71,1", "71,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 712,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "71,2", "71,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 713,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "71,3", "71,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 714,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "71,4", "71,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 715,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "71,5", "71,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 716,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "71,6", "71,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 717,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "71,7", "71,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 718,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "71,8", "71,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 719,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "71,9", "71,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 720,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 721,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "72,1", "72,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 722,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "72,2", "72,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 723,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "72,3", "72,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 724,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "72,4", "72,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 725,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "72,5", "72,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 726,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "72,6", "72,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 727,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "72,7", "72,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 728,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "72,8", "72,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 729,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "72,9", "72,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 730,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 731,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "73,1", "73,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 732,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "73,2", "73,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 733,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "73,3", "73,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 734,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "73,4", "73,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 735,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "73,5", "73,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 736,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "73,6", "73,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 737,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "73,7", "73,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 738,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "73,8", "73,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 739,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "73,9", "73,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 740,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 741,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "74,1", "74,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 742,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "74,2", "74,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 743,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "74,3", "74,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 744,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "74,4", "74,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 745,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "74,5", "74,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 746,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "74,6", "74,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 747,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "74,7", "74,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 748,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "74,8", "74,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 749,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "74,9", "74,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 750,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 751,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "75,1", "75,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 752,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "75,2", "75,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 753,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "75,3", "75,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 754,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "75,4", "75,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 755,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "75,5", "75,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 756,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "75,6", "75,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 757,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "75,7", "75,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 758,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "75,8", "75,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 759,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "75,9", "75,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 760,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 761,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "76,1", "76,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 762,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "76,2", "76,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 763,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "76,3", "76,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 764,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "76,4", "76,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 765,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "76,5", "76,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 766,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "76,6", "76,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 767,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "76,7", "76,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 768,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "76,8", "76,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 769,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "76,9", "76,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 770,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 771,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "77,1", "77,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 772,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "77,2", "77,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 773,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "77,3", "77,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 774,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "77,4", "77,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 775,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "77,5", "77,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 776,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "77,6", "77,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 777,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "77,7", "77,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 778,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "77,8", "77,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 779,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "77,9", "77,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 780,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 781,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "78,1", "78,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 782,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "78,2", "78,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 783,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "78,3", "78,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 784,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "78,4", "78,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 785,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "78,5", "78,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 786,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "78,6", "78,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 787,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "78,7", "78,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 788,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "78,8", "78,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 789,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "78,9", "78,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 790,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 791,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "79,1", "79,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 792,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "79,2", "79,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 793,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "79,3", "79,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 794,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "79,4", "79,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 795,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "79,5", "79,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 796,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "79,6", "79,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 797,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "79,7", "79,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 798,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "79,8", "79,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 799,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "79,9", "79,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 800,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 801,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "80,1", "80,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 802,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "80,2", "80,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 803,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "80,3", "80,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 804,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "80,4", "80,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 805,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "80,5", "80,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 806,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "80,6", "80,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 807,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "80,7", "80,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 808,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "80,8", "80,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 809,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "80,9", "80,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 810,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 811,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "81,1", "81,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 812,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "81,2", "81,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 813,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "81,3", "81,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 814,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "81,4", "81,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 815,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "81,5", "81,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 816,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "81,6", "81,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 817,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "81,7", "81,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 818,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "81,8", "81,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 819,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "81,9", "81,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 820,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 821,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "82,1", "82,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 822,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "82,2", "82,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 823,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "82,3", "82,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 824,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "82,4", "82,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 825,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "82,5", "82,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 826,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "82,6", "82,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 827,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "82,7", "82,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 828,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "82,8", "82,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 829,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "82,9", "82,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 830,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 831,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "83,1", "83,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 832,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "83,2", "83,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 833,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "83,3", "83,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 834,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "83,4", "83,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 835,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "83,5", "83,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 836,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "83,6", "83,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 837,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "83,7", "83,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 838,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "83,8", "83,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 839,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "83,9", "83,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 840,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 841,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "84,1", "84,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 842,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "84,2", "84,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 843,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "84,3", "84,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 844,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "84,4", "84,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 845,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "84,5", "84,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 846,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "84,6", "84,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 847,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "84,7", "84,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 848,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "84,8", "84,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 849,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "84,9", "84,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 850,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 851,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "85,1", "85,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 852,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "85,2", "85,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 853,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "85,3", "85,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 854,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "85,4", "85,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 855,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "85,5", "85,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 856,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "85,6", "85,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 857,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "85,7", "85,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 858,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "85,8", "85,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 859,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "85,9", "85,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 860,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 861,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "86,1", "86,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 862,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "86,2", "86,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 863,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "86,3", "86,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 864,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "86,4", "86,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 865,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "86,5", "86,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 866,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "86,6", "86,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 867,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "86,7", "86,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 868,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "86,8", "86,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 869,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "86,9", "86,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 870,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 871,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "87,1", "87,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 872,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "87,2", "87,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 873,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "87,3", "87,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 874,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "87,4", "87,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 875,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "87,5", "87,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 876,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "87,6", "87,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 877,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "87,7", "87,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 878,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "87,8", "87,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 879,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "87,9", "87,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 880,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 881,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "88,1", "88,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 882,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "88,2", "88,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 883,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "88,3", "88,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 884,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "88,4", "88,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 885,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "88,5", "88,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 886,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "88,6", "88,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 887,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "88,7", "88,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 888,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "88,8", "88,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 889,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "88,9", "88,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 890,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 891,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "89,1", "89,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 892,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "89,2", "89,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 893,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "89,3", "89,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 894,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "89,4", "89,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 895,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "89,5", "89,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 896,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "89,6", "89,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 897,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "89,7", "89,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 898,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "89,8", "89,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 899,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "89,9", "89,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 900,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 901,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "90,1", "90,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 902,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "90,2", "90,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 903,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "90,3", "90,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 904,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "90,4", "90,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 905,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "90,5", "90,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 906,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "90,6", "90,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 907,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "90,7", "90,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 908,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "90,8", "90,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 909,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "90,9", "90,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 910,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 911,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "91,1", "91,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 912,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "91,2", "91,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 913,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "91,3", "91,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 914,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "91,4", "91,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 915,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "91,5", "91,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 916,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "91,6", "91,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 917,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "91,7", "91,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 918,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "91,8", "91,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 919,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "91,9", "91,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 920,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 921,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "92,1", "92,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 922,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "92,2", "92,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 923,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "92,3", "92,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 924,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "92,4", "92,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 925,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "92,5", "92,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 926,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "92,6", "92,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 927,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "92,7", "92,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 928,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "92,8", "92,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 929,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "92,9", "92,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 930,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 931,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "93,1", "93,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 932,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "93,2", "93,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 933,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "93,3", "93,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 934,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "93,4", "93,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 935,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "93,5", "93,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 936,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "93,6", "93,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 937,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "93,7", "93,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 938,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "93,8", "93,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 939,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "93,9", "93,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 940,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 941,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "94,1", "94,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 942,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "94,2", "94,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 943,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "94,3", "94,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 944,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "94,4", "94,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 945,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "94,5", "94,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 946,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "94,6", "94,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 947,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "94,7", "94,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 948,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "94,8", "94,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 949,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "94,9", "94,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 950,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 951,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "95,1", "95,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 952,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "95,2", "95,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 953,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "95,3", "95,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 954,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "95,4", "95,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 955,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "95,5", "95,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 956,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "95,6", "95,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 957,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "95,7", "95,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 958,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "95,8", "95,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 959,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "95,9", "95,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 960,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 961,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "96,1", "96,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 962,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "96,2", "96,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 963,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "96,3", "96,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 964,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "96,4", "96,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 965,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "96,5", "96,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 966,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "96,6", "96,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 967,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "96,7", "96,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 968,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "96,8", "96,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 969,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "96,9", "96,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 970,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 971,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "97,1", "97,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 972,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "97,2", "97,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 973,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "97,3", "97,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 974,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "97,4", "97,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 975,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "97,5", "97,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 976,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "97,6", "97,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 977,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "97,7", "97,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 978,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "97,8", "97,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 979,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "97,9", "97,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 980,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 981,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "98,1", "98,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 982,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "98,2", "98,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 983,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "98,3", "98,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 984,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "98,4", "98,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 985,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "98,5", "98,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 986,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "98,6", "98,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 987,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "98,7", "98,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 988,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "98,8", "98,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 989,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "98,9", "98,9", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 990,
                column: "SceneId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 991,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "99,1", "99,1", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 992,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "99,2", "99,2", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 993,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "99,3", "99,3", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 994,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "99,4", "99,4", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 995,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "99,5", "99,5", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 996,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "99,6", "99,6", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 997,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "99,7", "99,7", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 998,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "99,8", "99,8", "" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 999,
                columns: new[] { "Code", "Name", "SceneId" },
                values: new object[] { "99,9", "99,9", "" });

            migrationBuilder.InsertData(
                table: "Tower",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "StandartTower" },
                    { 2, true, "ShortRangeAOETower" },
                    { 3, true, "MeleeTower" },
                    { 4, true, "SlowTower" },
                    { 5, true, "SniperTower" },
                    { 6, true, "LongRangeAOETower" },
                    { 7, true, "ShortRangeAOEStackingDamageTower" },
                    { 8, true, "PiercingMediumRangeTower" },
                    { 9, true, "CommandTower" }
                });

            migrationBuilder.InsertData(
                table: "Zombie",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "z1" },
                    { 2, true, "z2" }
                });

            migrationBuilder.InsertData(
                table: "Zombie",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 3, true, "z3" },
                    { 4, true, "z4" },
                    { 5, true, "z5" },
                    { 6, true, "z6" },
                    { 7, true, "z7" },
                    { 8, true, "z8" },
                    { 9, true, "z9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZombieKill_EnemyId",
                table: "ZombieKill",
                column: "EnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_Wave_StageId",
                table: "Wave",
                column: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TowerProgress_UserProgress_UserProgressHistoryId",
                table: "TowerProgress",
                column: "UserProgressHistoryId",
                principalTable: "UserProgress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProgress_Wave_WaveId",
                table: "UserProgress",
                column: "WaveId",
                principalTable: "Wave",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ZombieKill_Zombie_EnemyId",
                table: "ZombieKill",
                column: "EnemyId",
                principalTable: "Zombie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TowerProgress_UserProgress_UserProgressHistoryId",
                table: "TowerProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProgress_Wave_WaveId",
                table: "UserProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_ZombieKill_Zombie_EnemyId",
                table: "ZombieKill");

            migrationBuilder.DropTable(
                name: "Wave");

            migrationBuilder.DropIndex(
                name: "IX_ZombieKill_EnemyId",
                table: "ZombieKill");

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tower",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Zombie",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "EnemyId",
                table: "ZombieKill");

            migrationBuilder.DropColumn(
                name: "WaveEndTime",
                table: "UserProgress");

            migrationBuilder.DropColumn(
                name: "Coin",
                table: "Stage");

            migrationBuilder.DropColumn(
                name: "SceneId",
                table: "Stage");

            migrationBuilder.RenameColumn(
                name: "WaveStartTime",
                table: "UserProgress",
                newName: "StageStartTime");

            migrationBuilder.RenameColumn(
                name: "WaveId",
                table: "UserProgress",
                newName: "StageId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProgress_WaveId",
                table: "UserProgress",
                newName: "IX_UserProgress_StageId");

            migrationBuilder.RenameColumn(
                name: "UserProgressHistoryId",
                table: "TowerProgress",
                newName: "UserProgressId");

            migrationBuilder.RenameIndex(
                name: "IX_TowerProgress_UserProgressHistoryId",
                table: "TowerProgress",
                newName: "IX_TowerProgress_UserProgressId");

            migrationBuilder.AddColumn<long>(
                name: "ZombieId",
                table: "ZombieKill",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Zombie",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "DeviceId",
                table: "UserProgress",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserProgress",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "UserProgress",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "UserProgress",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "StarCount",
                table: "UserProgress",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Time",
                table: "UserProgress",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "UserProgress",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TowerId",
                table: "TowerProgress",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<long>(
                name: "TowerName",
                table: "TowerProgress",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Tower",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Code", "Name" },
                values: new object[] { "01.1", "01.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Code", "Name" },
                values: new object[] { "01.2", "01.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Code", "Name" },
                values: new object[] { "01.3", "01.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Code", "Name" },
                values: new object[] { "01.4", "01.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Code", "Name" },
                values: new object[] { "01.5", "01.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Code", "Name" },
                values: new object[] { "01.6", "01.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Code", "Name" },
                values: new object[] { "01.7", "01.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Code", "Name" },
                values: new object[] { "01.8", "01.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Code", "Name" },
                values: new object[] { "01.9", "01.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Code", "Name" },
                values: new object[] { "02.1", "02.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Code", "Name" },
                values: new object[] { "02.2", "02.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Code", "Name" },
                values: new object[] { "02.3", "02.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Code", "Name" },
                values: new object[] { "02.4", "02.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Code", "Name" },
                values: new object[] { "02.5", "02.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Code", "Name" },
                values: new object[] { "02.6", "02.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Code", "Name" },
                values: new object[] { "02.7", "02.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Code", "Name" },
                values: new object[] { "02.8", "02.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Code", "Name" },
                values: new object[] { "02.9", "02.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Code", "Name" },
                values: new object[] { "03.1", "03.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Code", "Name" },
                values: new object[] { "03.2", "03.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Code", "Name" },
                values: new object[] { "03.3", "03.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Code", "Name" },
                values: new object[] { "03.4", "03.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Code", "Name" },
                values: new object[] { "03.5", "03.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Code", "Name" },
                values: new object[] { "03.6", "03.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Code", "Name" },
                values: new object[] { "03.7", "03.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Code", "Name" },
                values: new object[] { "03.8", "03.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Code", "Name" },
                values: new object[] { "03.9", "03.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Code", "Name" },
                values: new object[] { "04.1", "04.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Code", "Name" },
                values: new object[] { "04.2", "04.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Code", "Name" },
                values: new object[] { "04.3", "04.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Code", "Name" },
                values: new object[] { "04.4", "04.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Code", "Name" },
                values: new object[] { "04.5", "04.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Code", "Name" },
                values: new object[] { "04.6", "04.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Code", "Name" },
                values: new object[] { "04.7", "04.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Code", "Name" },
                values: new object[] { "04.8", "04.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Code", "Name" },
                values: new object[] { "04.9", "04.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Code", "Name" },
                values: new object[] { "05.1", "05.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Code", "Name" },
                values: new object[] { "05.2", "05.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Code", "Name" },
                values: new object[] { "05.3", "05.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Code", "Name" },
                values: new object[] { "05.4", "05.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Code", "Name" },
                values: new object[] { "05.5", "05.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Code", "Name" },
                values: new object[] { "05.6", "05.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Code", "Name" },
                values: new object[] { "05.7", "05.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Code", "Name" },
                values: new object[] { "05.8", "05.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Code", "Name" },
                values: new object[] { "05.9", "05.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Code", "Name" },
                values: new object[] { "06.1", "06.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Code", "Name" },
                values: new object[] { "06.2", "06.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Code", "Name" },
                values: new object[] { "06.3", "06.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Code", "Name" },
                values: new object[] { "06.4", "06.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Code", "Name" },
                values: new object[] { "06.5", "06.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Code", "Name" },
                values: new object[] { "06.6", "06.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Code", "Name" },
                values: new object[] { "06.7", "06.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Code", "Name" },
                values: new object[] { "06.8", "06.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Code", "Name" },
                values: new object[] { "06.9", "06.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Code", "Name" },
                values: new object[] { "07.1", "07.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Code", "Name" },
                values: new object[] { "07.2", "07.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Code", "Name" },
                values: new object[] { "07.3", "07.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Code", "Name" },
                values: new object[] { "07.4", "07.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Code", "Name" },
                values: new object[] { "07.5", "07.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Code", "Name" },
                values: new object[] { "07.6", "07.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Code", "Name" },
                values: new object[] { "07.7", "07.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Code", "Name" },
                values: new object[] { "07.8", "07.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Code", "Name" },
                values: new object[] { "07.9", "07.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "Code", "Name" },
                values: new object[] { "08.1", "08.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "Code", "Name" },
                values: new object[] { "08.2", "08.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "Code", "Name" },
                values: new object[] { "08.3", "08.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "Code", "Name" },
                values: new object[] { "08.4", "08.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "Code", "Name" },
                values: new object[] { "08.5", "08.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Code", "Name" },
                values: new object[] { "08.6", "08.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Code", "Name" },
                values: new object[] { "08.7", "08.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "Code", "Name" },
                values: new object[] { "08.8", "08.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "Code", "Name" },
                values: new object[] { "08.9", "08.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "Code", "Name" },
                values: new object[] { "09.1", "09.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Code", "Name" },
                values: new object[] { "09.2", "09.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Code", "Name" },
                values: new object[] { "09.3", "09.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Code", "Name" },
                values: new object[] { "09.4", "09.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Code", "Name" },
                values: new object[] { "09.5", "09.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Code", "Name" },
                values: new object[] { "09.6", "09.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Code", "Name" },
                values: new object[] { "09.7", "09.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "Code", "Name" },
                values: new object[] { "09.8", "09.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "Code", "Name" },
                values: new object[] { "09.9", "09.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Code", "Name" },
                values: new object[] { "10.1", "10.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Code", "Name" },
                values: new object[] { "10.2", "10.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Code", "Name" },
                values: new object[] { "10.3", "10.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Code", "Name" },
                values: new object[] { "10.4", "10.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Code", "Name" },
                values: new object[] { "10.5", "10.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "Code", "Name" },
                values: new object[] { "10.6", "10.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "Code", "Name" },
                values: new object[] { "10.7", "10.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "Code", "Name" },
                values: new object[] { "10.8", "10.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Code", "Name" },
                values: new object[] { "10.9", "10.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Code", "Name" },
                values: new object[] { "11.1", "11.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "Code", "Name" },
                values: new object[] { "11.2", "11.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "Code", "Name" },
                values: new object[] { "11.3", "11.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "Code", "Name" },
                values: new object[] { "11.4", "11.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "Code", "Name" },
                values: new object[] { "11.5", "11.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "Code", "Name" },
                values: new object[] { "11.6", "11.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "Code", "Name" },
                values: new object[] { "11.7", "11.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "Code", "Name" },
                values: new object[] { "11.8", "11.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "Code", "Name" },
                values: new object[] { "11.9", "11.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "Code", "Name" },
                values: new object[] { "12.1", "12.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "Code", "Name" },
                values: new object[] { "12.2", "12.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "Code", "Name" },
                values: new object[] { "12.3", "12.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "Code", "Name" },
                values: new object[] { "12.4", "12.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "Code", "Name" },
                values: new object[] { "12.5", "12.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "Code", "Name" },
                values: new object[] { "12.6", "12.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "Code", "Name" },
                values: new object[] { "12.7", "12.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "Code", "Name" },
                values: new object[] { "12.8", "12.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "Code", "Name" },
                values: new object[] { "12.9", "12.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "Code", "Name" },
                values: new object[] { "13.1", "13.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "Code", "Name" },
                values: new object[] { "13.2", "13.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "Code", "Name" },
                values: new object[] { "13.3", "13.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "Code", "Name" },
                values: new object[] { "13.4", "13.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "Code", "Name" },
                values: new object[] { "13.5", "13.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "Code", "Name" },
                values: new object[] { "13.6", "13.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "Code", "Name" },
                values: new object[] { "13.7", "13.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "Code", "Name" },
                values: new object[] { "13.8", "13.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "Code", "Name" },
                values: new object[] { "13.9", "13.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "Code", "Name" },
                values: new object[] { "14.1", "14.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "Code", "Name" },
                values: new object[] { "14.2", "14.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "Code", "Name" },
                values: new object[] { "14.3", "14.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "Code", "Name" },
                values: new object[] { "14.4", "14.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "Code", "Name" },
                values: new object[] { "14.5", "14.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "Code", "Name" },
                values: new object[] { "14.6", "14.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "Code", "Name" },
                values: new object[] { "14.7", "14.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "Code", "Name" },
                values: new object[] { "14.8", "14.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "Code", "Name" },
                values: new object[] { "14.9", "14.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "Code", "Name" },
                values: new object[] { "15.1", "15.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "Code", "Name" },
                values: new object[] { "15.2", "15.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "Code", "Name" },
                values: new object[] { "15.3", "15.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "Code", "Name" },
                values: new object[] { "15.4", "15.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "Code", "Name" },
                values: new object[] { "15.5", "15.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "Code", "Name" },
                values: new object[] { "15.6", "15.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "Code", "Name" },
                values: new object[] { "15.7", "15.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "Code", "Name" },
                values: new object[] { "15.8", "15.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "Code", "Name" },
                values: new object[] { "15.9", "15.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "Code", "Name" },
                values: new object[] { "16.1", "16.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "Code", "Name" },
                values: new object[] { "16.2", "16.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "Code", "Name" },
                values: new object[] { "16.3", "16.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "Code", "Name" },
                values: new object[] { "16.4", "16.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "Code", "Name" },
                values: new object[] { "16.5", "16.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "Code", "Name" },
                values: new object[] { "16.6", "16.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "Code", "Name" },
                values: new object[] { "16.7", "16.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "Code", "Name" },
                values: new object[] { "16.8", "16.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "Code", "Name" },
                values: new object[] { "16.9", "16.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "Code", "Name" },
                values: new object[] { "17.1", "17.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "Code", "Name" },
                values: new object[] { "17.2", "17.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "Code", "Name" },
                values: new object[] { "17.3", "17.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "Code", "Name" },
                values: new object[] { "17.4", "17.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "Code", "Name" },
                values: new object[] { "17.5", "17.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "Code", "Name" },
                values: new object[] { "17.6", "17.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "Code", "Name" },
                values: new object[] { "17.7", "17.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "Code", "Name" },
                values: new object[] { "17.8", "17.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "Code", "Name" },
                values: new object[] { "17.9", "17.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "Code", "Name" },
                values: new object[] { "18.1", "18.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "Code", "Name" },
                values: new object[] { "18.2", "18.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "Code", "Name" },
                values: new object[] { "18.3", "18.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "Code", "Name" },
                values: new object[] { "18.4", "18.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "Code", "Name" },
                values: new object[] { "18.5", "18.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "Code", "Name" },
                values: new object[] { "18.6", "18.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "Code", "Name" },
                values: new object[] { "18.7", "18.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "Code", "Name" },
                values: new object[] { "18.8", "18.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "Code", "Name" },
                values: new object[] { "18.9", "18.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "Code", "Name" },
                values: new object[] { "19.1", "19.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "Code", "Name" },
                values: new object[] { "19.2", "19.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "Code", "Name" },
                values: new object[] { "19.3", "19.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "Code", "Name" },
                values: new object[] { "19.4", "19.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "Code", "Name" },
                values: new object[] { "19.5", "19.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "Code", "Name" },
                values: new object[] { "19.6", "19.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "Code", "Name" },
                values: new object[] { "19.7", "19.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "Code", "Name" },
                values: new object[] { "19.8", "19.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "Code", "Name" },
                values: new object[] { "19.9", "19.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "Code", "Name" },
                values: new object[] { "20.1", "20.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "Code", "Name" },
                values: new object[] { "20.2", "20.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "Code", "Name" },
                values: new object[] { "20.3", "20.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "Code", "Name" },
                values: new object[] { "20.4", "20.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "Code", "Name" },
                values: new object[] { "20.5", "20.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "Code", "Name" },
                values: new object[] { "20.6", "20.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "Code", "Name" },
                values: new object[] { "20.7", "20.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "Code", "Name" },
                values: new object[] { "20.8", "20.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "Code", "Name" },
                values: new object[] { "20.9", "20.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "Code", "Name" },
                values: new object[] { "21.1", "21.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "Code", "Name" },
                values: new object[] { "21.2", "21.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "Code", "Name" },
                values: new object[] { "21.3", "21.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "Code", "Name" },
                values: new object[] { "21.4", "21.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "Code", "Name" },
                values: new object[] { "21.5", "21.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "Code", "Name" },
                values: new object[] { "21.6", "21.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "Code", "Name" },
                values: new object[] { "21.7", "21.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "Code", "Name" },
                values: new object[] { "21.8", "21.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "Code", "Name" },
                values: new object[] { "21.9", "21.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "Code", "Name" },
                values: new object[] { "22.1", "22.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "Code", "Name" },
                values: new object[] { "22.2", "22.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "Code", "Name" },
                values: new object[] { "22.3", "22.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "Code", "Name" },
                values: new object[] { "22.4", "22.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "Code", "Name" },
                values: new object[] { "22.5", "22.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "Code", "Name" },
                values: new object[] { "22.6", "22.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "Code", "Name" },
                values: new object[] { "22.7", "22.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "Code", "Name" },
                values: new object[] { "22.8", "22.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "Code", "Name" },
                values: new object[] { "22.9", "22.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "Code", "Name" },
                values: new object[] { "23.1", "23.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "Code", "Name" },
                values: new object[] { "23.2", "23.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "Code", "Name" },
                values: new object[] { "23.3", "23.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "Code", "Name" },
                values: new object[] { "23.4", "23.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "Code", "Name" },
                values: new object[] { "23.5", "23.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "Code", "Name" },
                values: new object[] { "23.6", "23.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "Code", "Name" },
                values: new object[] { "23.7", "23.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "Code", "Name" },
                values: new object[] { "23.8", "23.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "Code", "Name" },
                values: new object[] { "23.9", "23.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "Code", "Name" },
                values: new object[] { "24.1", "24.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "Code", "Name" },
                values: new object[] { "24.2", "24.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "Code", "Name" },
                values: new object[] { "24.3", "24.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "Code", "Name" },
                values: new object[] { "24.4", "24.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "Code", "Name" },
                values: new object[] { "24.5", "24.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "Code", "Name" },
                values: new object[] { "24.6", "24.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "Code", "Name" },
                values: new object[] { "24.7", "24.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "Code", "Name" },
                values: new object[] { "24.8", "24.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "Code", "Name" },
                values: new object[] { "24.9", "24.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "Code", "Name" },
                values: new object[] { "25.1", "25.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "Code", "Name" },
                values: new object[] { "25.2", "25.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "Code", "Name" },
                values: new object[] { "25.3", "25.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "Code", "Name" },
                values: new object[] { "25.4", "25.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "Code", "Name" },
                values: new object[] { "25.5", "25.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "Code", "Name" },
                values: new object[] { "25.6", "25.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "Code", "Name" },
                values: new object[] { "25.7", "25.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "Code", "Name" },
                values: new object[] { "25.8", "25.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "Code", "Name" },
                values: new object[] { "25.9", "25.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "Code", "Name" },
                values: new object[] { "26.1", "26.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "Code", "Name" },
                values: new object[] { "26.2", "26.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "Code", "Name" },
                values: new object[] { "26.3", "26.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "Code", "Name" },
                values: new object[] { "26.4", "26.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "Code", "Name" },
                values: new object[] { "26.5", "26.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "Code", "Name" },
                values: new object[] { "26.6", "26.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "Code", "Name" },
                values: new object[] { "26.7", "26.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "Code", "Name" },
                values: new object[] { "26.8", "26.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "Code", "Name" },
                values: new object[] { "26.9", "26.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "Code", "Name" },
                values: new object[] { "27.1", "27.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "Code", "Name" },
                values: new object[] { "27.2", "27.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "Code", "Name" },
                values: new object[] { "27.3", "27.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "Code", "Name" },
                values: new object[] { "27.4", "27.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "Code", "Name" },
                values: new object[] { "27.5", "27.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "Code", "Name" },
                values: new object[] { "27.6", "27.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "Code", "Name" },
                values: new object[] { "27.7", "27.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "Code", "Name" },
                values: new object[] { "27.8", "27.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "Code", "Name" },
                values: new object[] { "27.9", "27.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "Code", "Name" },
                values: new object[] { "28.1", "28.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "Code", "Name" },
                values: new object[] { "28.2", "28.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "Code", "Name" },
                values: new object[] { "28.3", "28.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "Code", "Name" },
                values: new object[] { "28.4", "28.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "Code", "Name" },
                values: new object[] { "28.5", "28.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "Code", "Name" },
                values: new object[] { "28.6", "28.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "Code", "Name" },
                values: new object[] { "28.7", "28.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "Code", "Name" },
                values: new object[] { "28.8", "28.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "Code", "Name" },
                values: new object[] { "28.9", "28.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "Code", "Name" },
                values: new object[] { "29.1", "29.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "Code", "Name" },
                values: new object[] { "29.2", "29.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "Code", "Name" },
                values: new object[] { "29.3", "29.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "Code", "Name" },
                values: new object[] { "29.4", "29.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "Code", "Name" },
                values: new object[] { "29.5", "29.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "Code", "Name" },
                values: new object[] { "29.6", "29.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "Code", "Name" },
                values: new object[] { "29.7", "29.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "Code", "Name" },
                values: new object[] { "29.8", "29.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "Code", "Name" },
                values: new object[] { "29.9", "29.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "Code", "Name" },
                values: new object[] { "30.1", "30.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "Code", "Name" },
                values: new object[] { "30.2", "30.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "Code", "Name" },
                values: new object[] { "30.3", "30.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "Code", "Name" },
                values: new object[] { "30.4", "30.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "Code", "Name" },
                values: new object[] { "30.5", "30.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 306,
                columns: new[] { "Code", "Name" },
                values: new object[] { "30.6", "30.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 307,
                columns: new[] { "Code", "Name" },
                values: new object[] { "30.7", "30.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 308,
                columns: new[] { "Code", "Name" },
                values: new object[] { "30.8", "30.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 309,
                columns: new[] { "Code", "Name" },
                values: new object[] { "30.9", "30.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 311,
                columns: new[] { "Code", "Name" },
                values: new object[] { "31.1", "31.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 312,
                columns: new[] { "Code", "Name" },
                values: new object[] { "31.2", "31.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 313,
                columns: new[] { "Code", "Name" },
                values: new object[] { "31.3", "31.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 314,
                columns: new[] { "Code", "Name" },
                values: new object[] { "31.4", "31.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 315,
                columns: new[] { "Code", "Name" },
                values: new object[] { "31.5", "31.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 316,
                columns: new[] { "Code", "Name" },
                values: new object[] { "31.6", "31.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 317,
                columns: new[] { "Code", "Name" },
                values: new object[] { "31.7", "31.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 318,
                columns: new[] { "Code", "Name" },
                values: new object[] { "31.8", "31.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 319,
                columns: new[] { "Code", "Name" },
                values: new object[] { "31.9", "31.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 321,
                columns: new[] { "Code", "Name" },
                values: new object[] { "32.1", "32.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 322,
                columns: new[] { "Code", "Name" },
                values: new object[] { "32.2", "32.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 323,
                columns: new[] { "Code", "Name" },
                values: new object[] { "32.3", "32.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 324,
                columns: new[] { "Code", "Name" },
                values: new object[] { "32.4", "32.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 325,
                columns: new[] { "Code", "Name" },
                values: new object[] { "32.5", "32.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 326,
                columns: new[] { "Code", "Name" },
                values: new object[] { "32.6", "32.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 327,
                columns: new[] { "Code", "Name" },
                values: new object[] { "32.7", "32.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 328,
                columns: new[] { "Code", "Name" },
                values: new object[] { "32.8", "32.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 329,
                columns: new[] { "Code", "Name" },
                values: new object[] { "32.9", "32.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 331,
                columns: new[] { "Code", "Name" },
                values: new object[] { "33.1", "33.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 332,
                columns: new[] { "Code", "Name" },
                values: new object[] { "33.2", "33.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 333,
                columns: new[] { "Code", "Name" },
                values: new object[] { "33.3", "33.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 334,
                columns: new[] { "Code", "Name" },
                values: new object[] { "33.4", "33.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 335,
                columns: new[] { "Code", "Name" },
                values: new object[] { "33.5", "33.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 336,
                columns: new[] { "Code", "Name" },
                values: new object[] { "33.6", "33.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 337,
                columns: new[] { "Code", "Name" },
                values: new object[] { "33.7", "33.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 338,
                columns: new[] { "Code", "Name" },
                values: new object[] { "33.8", "33.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 339,
                columns: new[] { "Code", "Name" },
                values: new object[] { "33.9", "33.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 341,
                columns: new[] { "Code", "Name" },
                values: new object[] { "34.1", "34.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 342,
                columns: new[] { "Code", "Name" },
                values: new object[] { "34.2", "34.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 343,
                columns: new[] { "Code", "Name" },
                values: new object[] { "34.3", "34.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 344,
                columns: new[] { "Code", "Name" },
                values: new object[] { "34.4", "34.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 345,
                columns: new[] { "Code", "Name" },
                values: new object[] { "34.5", "34.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 346,
                columns: new[] { "Code", "Name" },
                values: new object[] { "34.6", "34.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 347,
                columns: new[] { "Code", "Name" },
                values: new object[] { "34.7", "34.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 348,
                columns: new[] { "Code", "Name" },
                values: new object[] { "34.8", "34.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 349,
                columns: new[] { "Code", "Name" },
                values: new object[] { "34.9", "34.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 351,
                columns: new[] { "Code", "Name" },
                values: new object[] { "35.1", "35.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 352,
                columns: new[] { "Code", "Name" },
                values: new object[] { "35.2", "35.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 353,
                columns: new[] { "Code", "Name" },
                values: new object[] { "35.3", "35.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 354,
                columns: new[] { "Code", "Name" },
                values: new object[] { "35.4", "35.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 355,
                columns: new[] { "Code", "Name" },
                values: new object[] { "35.5", "35.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 356,
                columns: new[] { "Code", "Name" },
                values: new object[] { "35.6", "35.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 357,
                columns: new[] { "Code", "Name" },
                values: new object[] { "35.7", "35.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 358,
                columns: new[] { "Code", "Name" },
                values: new object[] { "35.8", "35.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 359,
                columns: new[] { "Code", "Name" },
                values: new object[] { "35.9", "35.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 361,
                columns: new[] { "Code", "Name" },
                values: new object[] { "36.1", "36.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 362,
                columns: new[] { "Code", "Name" },
                values: new object[] { "36.2", "36.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 363,
                columns: new[] { "Code", "Name" },
                values: new object[] { "36.3", "36.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 364,
                columns: new[] { "Code", "Name" },
                values: new object[] { "36.4", "36.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 365,
                columns: new[] { "Code", "Name" },
                values: new object[] { "36.5", "36.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 366,
                columns: new[] { "Code", "Name" },
                values: new object[] { "36.6", "36.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 367,
                columns: new[] { "Code", "Name" },
                values: new object[] { "36.7", "36.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 368,
                columns: new[] { "Code", "Name" },
                values: new object[] { "36.8", "36.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 369,
                columns: new[] { "Code", "Name" },
                values: new object[] { "36.9", "36.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 371,
                columns: new[] { "Code", "Name" },
                values: new object[] { "37.1", "37.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 372,
                columns: new[] { "Code", "Name" },
                values: new object[] { "37.2", "37.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 373,
                columns: new[] { "Code", "Name" },
                values: new object[] { "37.3", "37.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 374,
                columns: new[] { "Code", "Name" },
                values: new object[] { "37.4", "37.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 375,
                columns: new[] { "Code", "Name" },
                values: new object[] { "37.5", "37.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 376,
                columns: new[] { "Code", "Name" },
                values: new object[] { "37.6", "37.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 377,
                columns: new[] { "Code", "Name" },
                values: new object[] { "37.7", "37.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 378,
                columns: new[] { "Code", "Name" },
                values: new object[] { "37.8", "37.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 379,
                columns: new[] { "Code", "Name" },
                values: new object[] { "37.9", "37.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 381,
                columns: new[] { "Code", "Name" },
                values: new object[] { "38.1", "38.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 382,
                columns: new[] { "Code", "Name" },
                values: new object[] { "38.2", "38.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 383,
                columns: new[] { "Code", "Name" },
                values: new object[] { "38.3", "38.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 384,
                columns: new[] { "Code", "Name" },
                values: new object[] { "38.4", "38.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 385,
                columns: new[] { "Code", "Name" },
                values: new object[] { "38.5", "38.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 386,
                columns: new[] { "Code", "Name" },
                values: new object[] { "38.6", "38.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 387,
                columns: new[] { "Code", "Name" },
                values: new object[] { "38.7", "38.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 388,
                columns: new[] { "Code", "Name" },
                values: new object[] { "38.8", "38.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 389,
                columns: new[] { "Code", "Name" },
                values: new object[] { "38.9", "38.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 391,
                columns: new[] { "Code", "Name" },
                values: new object[] { "39.1", "39.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 392,
                columns: new[] { "Code", "Name" },
                values: new object[] { "39.2", "39.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 393,
                columns: new[] { "Code", "Name" },
                values: new object[] { "39.3", "39.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 394,
                columns: new[] { "Code", "Name" },
                values: new object[] { "39.4", "39.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 395,
                columns: new[] { "Code", "Name" },
                values: new object[] { "39.5", "39.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 396,
                columns: new[] { "Code", "Name" },
                values: new object[] { "39.6", "39.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 397,
                columns: new[] { "Code", "Name" },
                values: new object[] { "39.7", "39.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 398,
                columns: new[] { "Code", "Name" },
                values: new object[] { "39.8", "39.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 399,
                columns: new[] { "Code", "Name" },
                values: new object[] { "39.9", "39.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 401,
                columns: new[] { "Code", "Name" },
                values: new object[] { "40.1", "40.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 402,
                columns: new[] { "Code", "Name" },
                values: new object[] { "40.2", "40.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 403,
                columns: new[] { "Code", "Name" },
                values: new object[] { "40.3", "40.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 404,
                columns: new[] { "Code", "Name" },
                values: new object[] { "40.4", "40.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 405,
                columns: new[] { "Code", "Name" },
                values: new object[] { "40.5", "40.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 406,
                columns: new[] { "Code", "Name" },
                values: new object[] { "40.6", "40.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 407,
                columns: new[] { "Code", "Name" },
                values: new object[] { "40.7", "40.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 408,
                columns: new[] { "Code", "Name" },
                values: new object[] { "40.8", "40.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 409,
                columns: new[] { "Code", "Name" },
                values: new object[] { "40.9", "40.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 411,
                columns: new[] { "Code", "Name" },
                values: new object[] { "41.1", "41.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 412,
                columns: new[] { "Code", "Name" },
                values: new object[] { "41.2", "41.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 413,
                columns: new[] { "Code", "Name" },
                values: new object[] { "41.3", "41.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 414,
                columns: new[] { "Code", "Name" },
                values: new object[] { "41.4", "41.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 415,
                columns: new[] { "Code", "Name" },
                values: new object[] { "41.5", "41.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 416,
                columns: new[] { "Code", "Name" },
                values: new object[] { "41.6", "41.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 417,
                columns: new[] { "Code", "Name" },
                values: new object[] { "41.7", "41.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 418,
                columns: new[] { "Code", "Name" },
                values: new object[] { "41.8", "41.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 419,
                columns: new[] { "Code", "Name" },
                values: new object[] { "41.9", "41.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 421,
                columns: new[] { "Code", "Name" },
                values: new object[] { "42.1", "42.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 422,
                columns: new[] { "Code", "Name" },
                values: new object[] { "42.2", "42.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 423,
                columns: new[] { "Code", "Name" },
                values: new object[] { "42.3", "42.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 424,
                columns: new[] { "Code", "Name" },
                values: new object[] { "42.4", "42.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 425,
                columns: new[] { "Code", "Name" },
                values: new object[] { "42.5", "42.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 426,
                columns: new[] { "Code", "Name" },
                values: new object[] { "42.6", "42.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 427,
                columns: new[] { "Code", "Name" },
                values: new object[] { "42.7", "42.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 428,
                columns: new[] { "Code", "Name" },
                values: new object[] { "42.8", "42.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 429,
                columns: new[] { "Code", "Name" },
                values: new object[] { "42.9", "42.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 431,
                columns: new[] { "Code", "Name" },
                values: new object[] { "43.1", "43.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 432,
                columns: new[] { "Code", "Name" },
                values: new object[] { "43.2", "43.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 433,
                columns: new[] { "Code", "Name" },
                values: new object[] { "43.3", "43.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 434,
                columns: new[] { "Code", "Name" },
                values: new object[] { "43.4", "43.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 435,
                columns: new[] { "Code", "Name" },
                values: new object[] { "43.5", "43.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 436,
                columns: new[] { "Code", "Name" },
                values: new object[] { "43.6", "43.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 437,
                columns: new[] { "Code", "Name" },
                values: new object[] { "43.7", "43.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 438,
                columns: new[] { "Code", "Name" },
                values: new object[] { "43.8", "43.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 439,
                columns: new[] { "Code", "Name" },
                values: new object[] { "43.9", "43.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 441,
                columns: new[] { "Code", "Name" },
                values: new object[] { "44.1", "44.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 442,
                columns: new[] { "Code", "Name" },
                values: new object[] { "44.2", "44.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 443,
                columns: new[] { "Code", "Name" },
                values: new object[] { "44.3", "44.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 444,
                columns: new[] { "Code", "Name" },
                values: new object[] { "44.4", "44.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 445,
                columns: new[] { "Code", "Name" },
                values: new object[] { "44.5", "44.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 446,
                columns: new[] { "Code", "Name" },
                values: new object[] { "44.6", "44.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 447,
                columns: new[] { "Code", "Name" },
                values: new object[] { "44.7", "44.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 448,
                columns: new[] { "Code", "Name" },
                values: new object[] { "44.8", "44.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 449,
                columns: new[] { "Code", "Name" },
                values: new object[] { "44.9", "44.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 451,
                columns: new[] { "Code", "Name" },
                values: new object[] { "45.1", "45.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 452,
                columns: new[] { "Code", "Name" },
                values: new object[] { "45.2", "45.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 453,
                columns: new[] { "Code", "Name" },
                values: new object[] { "45.3", "45.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 454,
                columns: new[] { "Code", "Name" },
                values: new object[] { "45.4", "45.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 455,
                columns: new[] { "Code", "Name" },
                values: new object[] { "45.5", "45.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 456,
                columns: new[] { "Code", "Name" },
                values: new object[] { "45.6", "45.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 457,
                columns: new[] { "Code", "Name" },
                values: new object[] { "45.7", "45.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 458,
                columns: new[] { "Code", "Name" },
                values: new object[] { "45.8", "45.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 459,
                columns: new[] { "Code", "Name" },
                values: new object[] { "45.9", "45.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 461,
                columns: new[] { "Code", "Name" },
                values: new object[] { "46.1", "46.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 462,
                columns: new[] { "Code", "Name" },
                values: new object[] { "46.2", "46.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 463,
                columns: new[] { "Code", "Name" },
                values: new object[] { "46.3", "46.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 464,
                columns: new[] { "Code", "Name" },
                values: new object[] { "46.4", "46.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 465,
                columns: new[] { "Code", "Name" },
                values: new object[] { "46.5", "46.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 466,
                columns: new[] { "Code", "Name" },
                values: new object[] { "46.6", "46.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 467,
                columns: new[] { "Code", "Name" },
                values: new object[] { "46.7", "46.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 468,
                columns: new[] { "Code", "Name" },
                values: new object[] { "46.8", "46.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 469,
                columns: new[] { "Code", "Name" },
                values: new object[] { "46.9", "46.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 471,
                columns: new[] { "Code", "Name" },
                values: new object[] { "47.1", "47.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 472,
                columns: new[] { "Code", "Name" },
                values: new object[] { "47.2", "47.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 473,
                columns: new[] { "Code", "Name" },
                values: new object[] { "47.3", "47.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 474,
                columns: new[] { "Code", "Name" },
                values: new object[] { "47.4", "47.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 475,
                columns: new[] { "Code", "Name" },
                values: new object[] { "47.5", "47.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 476,
                columns: new[] { "Code", "Name" },
                values: new object[] { "47.6", "47.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 477,
                columns: new[] { "Code", "Name" },
                values: new object[] { "47.7", "47.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 478,
                columns: new[] { "Code", "Name" },
                values: new object[] { "47.8", "47.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 479,
                columns: new[] { "Code", "Name" },
                values: new object[] { "47.9", "47.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 481,
                columns: new[] { "Code", "Name" },
                values: new object[] { "48.1", "48.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 482,
                columns: new[] { "Code", "Name" },
                values: new object[] { "48.2", "48.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 483,
                columns: new[] { "Code", "Name" },
                values: new object[] { "48.3", "48.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 484,
                columns: new[] { "Code", "Name" },
                values: new object[] { "48.4", "48.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 485,
                columns: new[] { "Code", "Name" },
                values: new object[] { "48.5", "48.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 486,
                columns: new[] { "Code", "Name" },
                values: new object[] { "48.6", "48.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 487,
                columns: new[] { "Code", "Name" },
                values: new object[] { "48.7", "48.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 488,
                columns: new[] { "Code", "Name" },
                values: new object[] { "48.8", "48.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 489,
                columns: new[] { "Code", "Name" },
                values: new object[] { "48.9", "48.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 491,
                columns: new[] { "Code", "Name" },
                values: new object[] { "49.1", "49.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 492,
                columns: new[] { "Code", "Name" },
                values: new object[] { "49.2", "49.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 493,
                columns: new[] { "Code", "Name" },
                values: new object[] { "49.3", "49.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 494,
                columns: new[] { "Code", "Name" },
                values: new object[] { "49.4", "49.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 495,
                columns: new[] { "Code", "Name" },
                values: new object[] { "49.5", "49.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 496,
                columns: new[] { "Code", "Name" },
                values: new object[] { "49.6", "49.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 497,
                columns: new[] { "Code", "Name" },
                values: new object[] { "49.7", "49.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 498,
                columns: new[] { "Code", "Name" },
                values: new object[] { "49.8", "49.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 499,
                columns: new[] { "Code", "Name" },
                values: new object[] { "49.9", "49.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 501,
                columns: new[] { "Code", "Name" },
                values: new object[] { "50.1", "50.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 502,
                columns: new[] { "Code", "Name" },
                values: new object[] { "50.2", "50.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 503,
                columns: new[] { "Code", "Name" },
                values: new object[] { "50.3", "50.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 504,
                columns: new[] { "Code", "Name" },
                values: new object[] { "50.4", "50.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 505,
                columns: new[] { "Code", "Name" },
                values: new object[] { "50.5", "50.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 506,
                columns: new[] { "Code", "Name" },
                values: new object[] { "50.6", "50.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 507,
                columns: new[] { "Code", "Name" },
                values: new object[] { "50.7", "50.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 508,
                columns: new[] { "Code", "Name" },
                values: new object[] { "50.8", "50.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 509,
                columns: new[] { "Code", "Name" },
                values: new object[] { "50.9", "50.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 511,
                columns: new[] { "Code", "Name" },
                values: new object[] { "51.1", "51.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 512,
                columns: new[] { "Code", "Name" },
                values: new object[] { "51.2", "51.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 513,
                columns: new[] { "Code", "Name" },
                values: new object[] { "51.3", "51.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 514,
                columns: new[] { "Code", "Name" },
                values: new object[] { "51.4", "51.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 515,
                columns: new[] { "Code", "Name" },
                values: new object[] { "51.5", "51.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 516,
                columns: new[] { "Code", "Name" },
                values: new object[] { "51.6", "51.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 517,
                columns: new[] { "Code", "Name" },
                values: new object[] { "51.7", "51.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 518,
                columns: new[] { "Code", "Name" },
                values: new object[] { "51.8", "51.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 519,
                columns: new[] { "Code", "Name" },
                values: new object[] { "51.9", "51.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 521,
                columns: new[] { "Code", "Name" },
                values: new object[] { "52.1", "52.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 522,
                columns: new[] { "Code", "Name" },
                values: new object[] { "52.2", "52.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 523,
                columns: new[] { "Code", "Name" },
                values: new object[] { "52.3", "52.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 524,
                columns: new[] { "Code", "Name" },
                values: new object[] { "52.4", "52.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 525,
                columns: new[] { "Code", "Name" },
                values: new object[] { "52.5", "52.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 526,
                columns: new[] { "Code", "Name" },
                values: new object[] { "52.6", "52.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 527,
                columns: new[] { "Code", "Name" },
                values: new object[] { "52.7", "52.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 528,
                columns: new[] { "Code", "Name" },
                values: new object[] { "52.8", "52.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 529,
                columns: new[] { "Code", "Name" },
                values: new object[] { "52.9", "52.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 531,
                columns: new[] { "Code", "Name" },
                values: new object[] { "53.1", "53.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 532,
                columns: new[] { "Code", "Name" },
                values: new object[] { "53.2", "53.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 533,
                columns: new[] { "Code", "Name" },
                values: new object[] { "53.3", "53.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 534,
                columns: new[] { "Code", "Name" },
                values: new object[] { "53.4", "53.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 535,
                columns: new[] { "Code", "Name" },
                values: new object[] { "53.5", "53.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 536,
                columns: new[] { "Code", "Name" },
                values: new object[] { "53.6", "53.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 537,
                columns: new[] { "Code", "Name" },
                values: new object[] { "53.7", "53.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 538,
                columns: new[] { "Code", "Name" },
                values: new object[] { "53.8", "53.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 539,
                columns: new[] { "Code", "Name" },
                values: new object[] { "53.9", "53.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 541,
                columns: new[] { "Code", "Name" },
                values: new object[] { "54.1", "54.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 542,
                columns: new[] { "Code", "Name" },
                values: new object[] { "54.2", "54.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 543,
                columns: new[] { "Code", "Name" },
                values: new object[] { "54.3", "54.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 544,
                columns: new[] { "Code", "Name" },
                values: new object[] { "54.4", "54.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 545,
                columns: new[] { "Code", "Name" },
                values: new object[] { "54.5", "54.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 546,
                columns: new[] { "Code", "Name" },
                values: new object[] { "54.6", "54.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 547,
                columns: new[] { "Code", "Name" },
                values: new object[] { "54.7", "54.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 548,
                columns: new[] { "Code", "Name" },
                values: new object[] { "54.8", "54.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 549,
                columns: new[] { "Code", "Name" },
                values: new object[] { "54.9", "54.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 551,
                columns: new[] { "Code", "Name" },
                values: new object[] { "55.1", "55.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 552,
                columns: new[] { "Code", "Name" },
                values: new object[] { "55.2", "55.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 553,
                columns: new[] { "Code", "Name" },
                values: new object[] { "55.3", "55.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 554,
                columns: new[] { "Code", "Name" },
                values: new object[] { "55.4", "55.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 555,
                columns: new[] { "Code", "Name" },
                values: new object[] { "55.5", "55.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 556,
                columns: new[] { "Code", "Name" },
                values: new object[] { "55.6", "55.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 557,
                columns: new[] { "Code", "Name" },
                values: new object[] { "55.7", "55.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 558,
                columns: new[] { "Code", "Name" },
                values: new object[] { "55.8", "55.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 559,
                columns: new[] { "Code", "Name" },
                values: new object[] { "55.9", "55.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 561,
                columns: new[] { "Code", "Name" },
                values: new object[] { "56.1", "56.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 562,
                columns: new[] { "Code", "Name" },
                values: new object[] { "56.2", "56.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 563,
                columns: new[] { "Code", "Name" },
                values: new object[] { "56.3", "56.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 564,
                columns: new[] { "Code", "Name" },
                values: new object[] { "56.4", "56.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 565,
                columns: new[] { "Code", "Name" },
                values: new object[] { "56.5", "56.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 566,
                columns: new[] { "Code", "Name" },
                values: new object[] { "56.6", "56.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 567,
                columns: new[] { "Code", "Name" },
                values: new object[] { "56.7", "56.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 568,
                columns: new[] { "Code", "Name" },
                values: new object[] { "56.8", "56.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 569,
                columns: new[] { "Code", "Name" },
                values: new object[] { "56.9", "56.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 571,
                columns: new[] { "Code", "Name" },
                values: new object[] { "57.1", "57.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 572,
                columns: new[] { "Code", "Name" },
                values: new object[] { "57.2", "57.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 573,
                columns: new[] { "Code", "Name" },
                values: new object[] { "57.3", "57.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 574,
                columns: new[] { "Code", "Name" },
                values: new object[] { "57.4", "57.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 575,
                columns: new[] { "Code", "Name" },
                values: new object[] { "57.5", "57.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 576,
                columns: new[] { "Code", "Name" },
                values: new object[] { "57.6", "57.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 577,
                columns: new[] { "Code", "Name" },
                values: new object[] { "57.7", "57.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 578,
                columns: new[] { "Code", "Name" },
                values: new object[] { "57.8", "57.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 579,
                columns: new[] { "Code", "Name" },
                values: new object[] { "57.9", "57.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 581,
                columns: new[] { "Code", "Name" },
                values: new object[] { "58.1", "58.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 582,
                columns: new[] { "Code", "Name" },
                values: new object[] { "58.2", "58.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 583,
                columns: new[] { "Code", "Name" },
                values: new object[] { "58.3", "58.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 584,
                columns: new[] { "Code", "Name" },
                values: new object[] { "58.4", "58.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 585,
                columns: new[] { "Code", "Name" },
                values: new object[] { "58.5", "58.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 586,
                columns: new[] { "Code", "Name" },
                values: new object[] { "58.6", "58.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 587,
                columns: new[] { "Code", "Name" },
                values: new object[] { "58.7", "58.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 588,
                columns: new[] { "Code", "Name" },
                values: new object[] { "58.8", "58.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 589,
                columns: new[] { "Code", "Name" },
                values: new object[] { "58.9", "58.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 591,
                columns: new[] { "Code", "Name" },
                values: new object[] { "59.1", "59.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 592,
                columns: new[] { "Code", "Name" },
                values: new object[] { "59.2", "59.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 593,
                columns: new[] { "Code", "Name" },
                values: new object[] { "59.3", "59.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 594,
                columns: new[] { "Code", "Name" },
                values: new object[] { "59.4", "59.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 595,
                columns: new[] { "Code", "Name" },
                values: new object[] { "59.5", "59.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 596,
                columns: new[] { "Code", "Name" },
                values: new object[] { "59.6", "59.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 597,
                columns: new[] { "Code", "Name" },
                values: new object[] { "59.7", "59.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 598,
                columns: new[] { "Code", "Name" },
                values: new object[] { "59.8", "59.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 599,
                columns: new[] { "Code", "Name" },
                values: new object[] { "59.9", "59.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 601,
                columns: new[] { "Code", "Name" },
                values: new object[] { "60.1", "60.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 602,
                columns: new[] { "Code", "Name" },
                values: new object[] { "60.2", "60.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 603,
                columns: new[] { "Code", "Name" },
                values: new object[] { "60.3", "60.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 604,
                columns: new[] { "Code", "Name" },
                values: new object[] { "60.4", "60.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 605,
                columns: new[] { "Code", "Name" },
                values: new object[] { "60.5", "60.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 606,
                columns: new[] { "Code", "Name" },
                values: new object[] { "60.6", "60.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 607,
                columns: new[] { "Code", "Name" },
                values: new object[] { "60.7", "60.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 608,
                columns: new[] { "Code", "Name" },
                values: new object[] { "60.8", "60.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 609,
                columns: new[] { "Code", "Name" },
                values: new object[] { "60.9", "60.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 611,
                columns: new[] { "Code", "Name" },
                values: new object[] { "61.1", "61.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 612,
                columns: new[] { "Code", "Name" },
                values: new object[] { "61.2", "61.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 613,
                columns: new[] { "Code", "Name" },
                values: new object[] { "61.3", "61.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 614,
                columns: new[] { "Code", "Name" },
                values: new object[] { "61.4", "61.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 615,
                columns: new[] { "Code", "Name" },
                values: new object[] { "61.5", "61.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 616,
                columns: new[] { "Code", "Name" },
                values: new object[] { "61.6", "61.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 617,
                columns: new[] { "Code", "Name" },
                values: new object[] { "61.7", "61.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 618,
                columns: new[] { "Code", "Name" },
                values: new object[] { "61.8", "61.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 619,
                columns: new[] { "Code", "Name" },
                values: new object[] { "61.9", "61.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 621,
                columns: new[] { "Code", "Name" },
                values: new object[] { "62.1", "62.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 622,
                columns: new[] { "Code", "Name" },
                values: new object[] { "62.2", "62.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 623,
                columns: new[] { "Code", "Name" },
                values: new object[] { "62.3", "62.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 624,
                columns: new[] { "Code", "Name" },
                values: new object[] { "62.4", "62.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 625,
                columns: new[] { "Code", "Name" },
                values: new object[] { "62.5", "62.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 626,
                columns: new[] { "Code", "Name" },
                values: new object[] { "62.6", "62.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 627,
                columns: new[] { "Code", "Name" },
                values: new object[] { "62.7", "62.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 628,
                columns: new[] { "Code", "Name" },
                values: new object[] { "62.8", "62.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 629,
                columns: new[] { "Code", "Name" },
                values: new object[] { "62.9", "62.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 631,
                columns: new[] { "Code", "Name" },
                values: new object[] { "63.1", "63.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 632,
                columns: new[] { "Code", "Name" },
                values: new object[] { "63.2", "63.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 633,
                columns: new[] { "Code", "Name" },
                values: new object[] { "63.3", "63.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 634,
                columns: new[] { "Code", "Name" },
                values: new object[] { "63.4", "63.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 635,
                columns: new[] { "Code", "Name" },
                values: new object[] { "63.5", "63.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 636,
                columns: new[] { "Code", "Name" },
                values: new object[] { "63.6", "63.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 637,
                columns: new[] { "Code", "Name" },
                values: new object[] { "63.7", "63.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 638,
                columns: new[] { "Code", "Name" },
                values: new object[] { "63.8", "63.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 639,
                columns: new[] { "Code", "Name" },
                values: new object[] { "63.9", "63.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 641,
                columns: new[] { "Code", "Name" },
                values: new object[] { "64.1", "64.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 642,
                columns: new[] { "Code", "Name" },
                values: new object[] { "64.2", "64.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 643,
                columns: new[] { "Code", "Name" },
                values: new object[] { "64.3", "64.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 644,
                columns: new[] { "Code", "Name" },
                values: new object[] { "64.4", "64.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 645,
                columns: new[] { "Code", "Name" },
                values: new object[] { "64.5", "64.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 646,
                columns: new[] { "Code", "Name" },
                values: new object[] { "64.6", "64.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 647,
                columns: new[] { "Code", "Name" },
                values: new object[] { "64.7", "64.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 648,
                columns: new[] { "Code", "Name" },
                values: new object[] { "64.8", "64.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 649,
                columns: new[] { "Code", "Name" },
                values: new object[] { "64.9", "64.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 651,
                columns: new[] { "Code", "Name" },
                values: new object[] { "65.1", "65.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 652,
                columns: new[] { "Code", "Name" },
                values: new object[] { "65.2", "65.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 653,
                columns: new[] { "Code", "Name" },
                values: new object[] { "65.3", "65.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 654,
                columns: new[] { "Code", "Name" },
                values: new object[] { "65.4", "65.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 655,
                columns: new[] { "Code", "Name" },
                values: new object[] { "65.5", "65.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 656,
                columns: new[] { "Code", "Name" },
                values: new object[] { "65.6", "65.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 657,
                columns: new[] { "Code", "Name" },
                values: new object[] { "65.7", "65.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 658,
                columns: new[] { "Code", "Name" },
                values: new object[] { "65.8", "65.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 659,
                columns: new[] { "Code", "Name" },
                values: new object[] { "65.9", "65.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 661,
                columns: new[] { "Code", "Name" },
                values: new object[] { "66.1", "66.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 662,
                columns: new[] { "Code", "Name" },
                values: new object[] { "66.2", "66.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 663,
                columns: new[] { "Code", "Name" },
                values: new object[] { "66.3", "66.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 664,
                columns: new[] { "Code", "Name" },
                values: new object[] { "66.4", "66.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 665,
                columns: new[] { "Code", "Name" },
                values: new object[] { "66.5", "66.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 666,
                columns: new[] { "Code", "Name" },
                values: new object[] { "66.6", "66.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 667,
                columns: new[] { "Code", "Name" },
                values: new object[] { "66.7", "66.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 668,
                columns: new[] { "Code", "Name" },
                values: new object[] { "66.8", "66.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 669,
                columns: new[] { "Code", "Name" },
                values: new object[] { "66.9", "66.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 671,
                columns: new[] { "Code", "Name" },
                values: new object[] { "67.1", "67.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 672,
                columns: new[] { "Code", "Name" },
                values: new object[] { "67.2", "67.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 673,
                columns: new[] { "Code", "Name" },
                values: new object[] { "67.3", "67.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 674,
                columns: new[] { "Code", "Name" },
                values: new object[] { "67.4", "67.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 675,
                columns: new[] { "Code", "Name" },
                values: new object[] { "67.5", "67.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 676,
                columns: new[] { "Code", "Name" },
                values: new object[] { "67.6", "67.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 677,
                columns: new[] { "Code", "Name" },
                values: new object[] { "67.7", "67.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 678,
                columns: new[] { "Code", "Name" },
                values: new object[] { "67.8", "67.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 679,
                columns: new[] { "Code", "Name" },
                values: new object[] { "67.9", "67.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 681,
                columns: new[] { "Code", "Name" },
                values: new object[] { "68.1", "68.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 682,
                columns: new[] { "Code", "Name" },
                values: new object[] { "68.2", "68.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 683,
                columns: new[] { "Code", "Name" },
                values: new object[] { "68.3", "68.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 684,
                columns: new[] { "Code", "Name" },
                values: new object[] { "68.4", "68.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 685,
                columns: new[] { "Code", "Name" },
                values: new object[] { "68.5", "68.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 686,
                columns: new[] { "Code", "Name" },
                values: new object[] { "68.6", "68.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 687,
                columns: new[] { "Code", "Name" },
                values: new object[] { "68.7", "68.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 688,
                columns: new[] { "Code", "Name" },
                values: new object[] { "68.8", "68.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 689,
                columns: new[] { "Code", "Name" },
                values: new object[] { "68.9", "68.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 691,
                columns: new[] { "Code", "Name" },
                values: new object[] { "69.1", "69.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 692,
                columns: new[] { "Code", "Name" },
                values: new object[] { "69.2", "69.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 693,
                columns: new[] { "Code", "Name" },
                values: new object[] { "69.3", "69.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 694,
                columns: new[] { "Code", "Name" },
                values: new object[] { "69.4", "69.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 695,
                columns: new[] { "Code", "Name" },
                values: new object[] { "69.5", "69.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 696,
                columns: new[] { "Code", "Name" },
                values: new object[] { "69.6", "69.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 697,
                columns: new[] { "Code", "Name" },
                values: new object[] { "69.7", "69.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 698,
                columns: new[] { "Code", "Name" },
                values: new object[] { "69.8", "69.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 699,
                columns: new[] { "Code", "Name" },
                values: new object[] { "69.9", "69.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 701,
                columns: new[] { "Code", "Name" },
                values: new object[] { "70.1", "70.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 702,
                columns: new[] { "Code", "Name" },
                values: new object[] { "70.2", "70.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 703,
                columns: new[] { "Code", "Name" },
                values: new object[] { "70.3", "70.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 704,
                columns: new[] { "Code", "Name" },
                values: new object[] { "70.4", "70.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 705,
                columns: new[] { "Code", "Name" },
                values: new object[] { "70.5", "70.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 706,
                columns: new[] { "Code", "Name" },
                values: new object[] { "70.6", "70.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 707,
                columns: new[] { "Code", "Name" },
                values: new object[] { "70.7", "70.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 708,
                columns: new[] { "Code", "Name" },
                values: new object[] { "70.8", "70.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 709,
                columns: new[] { "Code", "Name" },
                values: new object[] { "70.9", "70.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 711,
                columns: new[] { "Code", "Name" },
                values: new object[] { "71.1", "71.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 712,
                columns: new[] { "Code", "Name" },
                values: new object[] { "71.2", "71.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 713,
                columns: new[] { "Code", "Name" },
                values: new object[] { "71.3", "71.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 714,
                columns: new[] { "Code", "Name" },
                values: new object[] { "71.4", "71.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 715,
                columns: new[] { "Code", "Name" },
                values: new object[] { "71.5", "71.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 716,
                columns: new[] { "Code", "Name" },
                values: new object[] { "71.6", "71.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 717,
                columns: new[] { "Code", "Name" },
                values: new object[] { "71.7", "71.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 718,
                columns: new[] { "Code", "Name" },
                values: new object[] { "71.8", "71.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 719,
                columns: new[] { "Code", "Name" },
                values: new object[] { "71.9", "71.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 721,
                columns: new[] { "Code", "Name" },
                values: new object[] { "72.1", "72.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 722,
                columns: new[] { "Code", "Name" },
                values: new object[] { "72.2", "72.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 723,
                columns: new[] { "Code", "Name" },
                values: new object[] { "72.3", "72.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 724,
                columns: new[] { "Code", "Name" },
                values: new object[] { "72.4", "72.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 725,
                columns: new[] { "Code", "Name" },
                values: new object[] { "72.5", "72.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 726,
                columns: new[] { "Code", "Name" },
                values: new object[] { "72.6", "72.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 727,
                columns: new[] { "Code", "Name" },
                values: new object[] { "72.7", "72.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 728,
                columns: new[] { "Code", "Name" },
                values: new object[] { "72.8", "72.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 729,
                columns: new[] { "Code", "Name" },
                values: new object[] { "72.9", "72.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 731,
                columns: new[] { "Code", "Name" },
                values: new object[] { "73.1", "73.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 732,
                columns: new[] { "Code", "Name" },
                values: new object[] { "73.2", "73.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 733,
                columns: new[] { "Code", "Name" },
                values: new object[] { "73.3", "73.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 734,
                columns: new[] { "Code", "Name" },
                values: new object[] { "73.4", "73.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 735,
                columns: new[] { "Code", "Name" },
                values: new object[] { "73.5", "73.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 736,
                columns: new[] { "Code", "Name" },
                values: new object[] { "73.6", "73.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 737,
                columns: new[] { "Code", "Name" },
                values: new object[] { "73.7", "73.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 738,
                columns: new[] { "Code", "Name" },
                values: new object[] { "73.8", "73.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 739,
                columns: new[] { "Code", "Name" },
                values: new object[] { "73.9", "73.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 741,
                columns: new[] { "Code", "Name" },
                values: new object[] { "74.1", "74.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 742,
                columns: new[] { "Code", "Name" },
                values: new object[] { "74.2", "74.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 743,
                columns: new[] { "Code", "Name" },
                values: new object[] { "74.3", "74.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 744,
                columns: new[] { "Code", "Name" },
                values: new object[] { "74.4", "74.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 745,
                columns: new[] { "Code", "Name" },
                values: new object[] { "74.5", "74.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 746,
                columns: new[] { "Code", "Name" },
                values: new object[] { "74.6", "74.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 747,
                columns: new[] { "Code", "Name" },
                values: new object[] { "74.7", "74.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 748,
                columns: new[] { "Code", "Name" },
                values: new object[] { "74.8", "74.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 749,
                columns: new[] { "Code", "Name" },
                values: new object[] { "74.9", "74.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 751,
                columns: new[] { "Code", "Name" },
                values: new object[] { "75.1", "75.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 752,
                columns: new[] { "Code", "Name" },
                values: new object[] { "75.2", "75.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 753,
                columns: new[] { "Code", "Name" },
                values: new object[] { "75.3", "75.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 754,
                columns: new[] { "Code", "Name" },
                values: new object[] { "75.4", "75.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 755,
                columns: new[] { "Code", "Name" },
                values: new object[] { "75.5", "75.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 756,
                columns: new[] { "Code", "Name" },
                values: new object[] { "75.6", "75.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 757,
                columns: new[] { "Code", "Name" },
                values: new object[] { "75.7", "75.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 758,
                columns: new[] { "Code", "Name" },
                values: new object[] { "75.8", "75.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 759,
                columns: new[] { "Code", "Name" },
                values: new object[] { "75.9", "75.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 761,
                columns: new[] { "Code", "Name" },
                values: new object[] { "76.1", "76.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 762,
                columns: new[] { "Code", "Name" },
                values: new object[] { "76.2", "76.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 763,
                columns: new[] { "Code", "Name" },
                values: new object[] { "76.3", "76.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 764,
                columns: new[] { "Code", "Name" },
                values: new object[] { "76.4", "76.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 765,
                columns: new[] { "Code", "Name" },
                values: new object[] { "76.5", "76.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 766,
                columns: new[] { "Code", "Name" },
                values: new object[] { "76.6", "76.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 767,
                columns: new[] { "Code", "Name" },
                values: new object[] { "76.7", "76.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 768,
                columns: new[] { "Code", "Name" },
                values: new object[] { "76.8", "76.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 769,
                columns: new[] { "Code", "Name" },
                values: new object[] { "76.9", "76.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 771,
                columns: new[] { "Code", "Name" },
                values: new object[] { "77.1", "77.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 772,
                columns: new[] { "Code", "Name" },
                values: new object[] { "77.2", "77.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 773,
                columns: new[] { "Code", "Name" },
                values: new object[] { "77.3", "77.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 774,
                columns: new[] { "Code", "Name" },
                values: new object[] { "77.4", "77.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 775,
                columns: new[] { "Code", "Name" },
                values: new object[] { "77.5", "77.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 776,
                columns: new[] { "Code", "Name" },
                values: new object[] { "77.6", "77.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 777,
                columns: new[] { "Code", "Name" },
                values: new object[] { "77.7", "77.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 778,
                columns: new[] { "Code", "Name" },
                values: new object[] { "77.8", "77.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 779,
                columns: new[] { "Code", "Name" },
                values: new object[] { "77.9", "77.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 781,
                columns: new[] { "Code", "Name" },
                values: new object[] { "78.1", "78.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 782,
                columns: new[] { "Code", "Name" },
                values: new object[] { "78.2", "78.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 783,
                columns: new[] { "Code", "Name" },
                values: new object[] { "78.3", "78.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 784,
                columns: new[] { "Code", "Name" },
                values: new object[] { "78.4", "78.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 785,
                columns: new[] { "Code", "Name" },
                values: new object[] { "78.5", "78.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 786,
                columns: new[] { "Code", "Name" },
                values: new object[] { "78.6", "78.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 787,
                columns: new[] { "Code", "Name" },
                values: new object[] { "78.7", "78.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 788,
                columns: new[] { "Code", "Name" },
                values: new object[] { "78.8", "78.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 789,
                columns: new[] { "Code", "Name" },
                values: new object[] { "78.9", "78.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 791,
                columns: new[] { "Code", "Name" },
                values: new object[] { "79.1", "79.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 792,
                columns: new[] { "Code", "Name" },
                values: new object[] { "79.2", "79.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 793,
                columns: new[] { "Code", "Name" },
                values: new object[] { "79.3", "79.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 794,
                columns: new[] { "Code", "Name" },
                values: new object[] { "79.4", "79.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 795,
                columns: new[] { "Code", "Name" },
                values: new object[] { "79.5", "79.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 796,
                columns: new[] { "Code", "Name" },
                values: new object[] { "79.6", "79.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 797,
                columns: new[] { "Code", "Name" },
                values: new object[] { "79.7", "79.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 798,
                columns: new[] { "Code", "Name" },
                values: new object[] { "79.8", "79.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 799,
                columns: new[] { "Code", "Name" },
                values: new object[] { "79.9", "79.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 801,
                columns: new[] { "Code", "Name" },
                values: new object[] { "80.1", "80.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 802,
                columns: new[] { "Code", "Name" },
                values: new object[] { "80.2", "80.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 803,
                columns: new[] { "Code", "Name" },
                values: new object[] { "80.3", "80.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 804,
                columns: new[] { "Code", "Name" },
                values: new object[] { "80.4", "80.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 805,
                columns: new[] { "Code", "Name" },
                values: new object[] { "80.5", "80.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 806,
                columns: new[] { "Code", "Name" },
                values: new object[] { "80.6", "80.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 807,
                columns: new[] { "Code", "Name" },
                values: new object[] { "80.7", "80.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 808,
                columns: new[] { "Code", "Name" },
                values: new object[] { "80.8", "80.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 809,
                columns: new[] { "Code", "Name" },
                values: new object[] { "80.9", "80.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 811,
                columns: new[] { "Code", "Name" },
                values: new object[] { "81.1", "81.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 812,
                columns: new[] { "Code", "Name" },
                values: new object[] { "81.2", "81.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 813,
                columns: new[] { "Code", "Name" },
                values: new object[] { "81.3", "81.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 814,
                columns: new[] { "Code", "Name" },
                values: new object[] { "81.4", "81.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 815,
                columns: new[] { "Code", "Name" },
                values: new object[] { "81.5", "81.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 816,
                columns: new[] { "Code", "Name" },
                values: new object[] { "81.6", "81.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 817,
                columns: new[] { "Code", "Name" },
                values: new object[] { "81.7", "81.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 818,
                columns: new[] { "Code", "Name" },
                values: new object[] { "81.8", "81.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 819,
                columns: new[] { "Code", "Name" },
                values: new object[] { "81.9", "81.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 821,
                columns: new[] { "Code", "Name" },
                values: new object[] { "82.1", "82.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 822,
                columns: new[] { "Code", "Name" },
                values: new object[] { "82.2", "82.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 823,
                columns: new[] { "Code", "Name" },
                values: new object[] { "82.3", "82.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 824,
                columns: new[] { "Code", "Name" },
                values: new object[] { "82.4", "82.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 825,
                columns: new[] { "Code", "Name" },
                values: new object[] { "82.5", "82.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 826,
                columns: new[] { "Code", "Name" },
                values: new object[] { "82.6", "82.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 827,
                columns: new[] { "Code", "Name" },
                values: new object[] { "82.7", "82.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 828,
                columns: new[] { "Code", "Name" },
                values: new object[] { "82.8", "82.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 829,
                columns: new[] { "Code", "Name" },
                values: new object[] { "82.9", "82.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 831,
                columns: new[] { "Code", "Name" },
                values: new object[] { "83.1", "83.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 832,
                columns: new[] { "Code", "Name" },
                values: new object[] { "83.2", "83.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 833,
                columns: new[] { "Code", "Name" },
                values: new object[] { "83.3", "83.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 834,
                columns: new[] { "Code", "Name" },
                values: new object[] { "83.4", "83.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 835,
                columns: new[] { "Code", "Name" },
                values: new object[] { "83.5", "83.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 836,
                columns: new[] { "Code", "Name" },
                values: new object[] { "83.6", "83.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 837,
                columns: new[] { "Code", "Name" },
                values: new object[] { "83.7", "83.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 838,
                columns: new[] { "Code", "Name" },
                values: new object[] { "83.8", "83.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 839,
                columns: new[] { "Code", "Name" },
                values: new object[] { "83.9", "83.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 841,
                columns: new[] { "Code", "Name" },
                values: new object[] { "84.1", "84.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 842,
                columns: new[] { "Code", "Name" },
                values: new object[] { "84.2", "84.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 843,
                columns: new[] { "Code", "Name" },
                values: new object[] { "84.3", "84.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 844,
                columns: new[] { "Code", "Name" },
                values: new object[] { "84.4", "84.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 845,
                columns: new[] { "Code", "Name" },
                values: new object[] { "84.5", "84.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 846,
                columns: new[] { "Code", "Name" },
                values: new object[] { "84.6", "84.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 847,
                columns: new[] { "Code", "Name" },
                values: new object[] { "84.7", "84.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 848,
                columns: new[] { "Code", "Name" },
                values: new object[] { "84.8", "84.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 849,
                columns: new[] { "Code", "Name" },
                values: new object[] { "84.9", "84.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 851,
                columns: new[] { "Code", "Name" },
                values: new object[] { "85.1", "85.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 852,
                columns: new[] { "Code", "Name" },
                values: new object[] { "85.2", "85.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 853,
                columns: new[] { "Code", "Name" },
                values: new object[] { "85.3", "85.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 854,
                columns: new[] { "Code", "Name" },
                values: new object[] { "85.4", "85.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 855,
                columns: new[] { "Code", "Name" },
                values: new object[] { "85.5", "85.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 856,
                columns: new[] { "Code", "Name" },
                values: new object[] { "85.6", "85.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 857,
                columns: new[] { "Code", "Name" },
                values: new object[] { "85.7", "85.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 858,
                columns: new[] { "Code", "Name" },
                values: new object[] { "85.8", "85.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 859,
                columns: new[] { "Code", "Name" },
                values: new object[] { "85.9", "85.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 861,
                columns: new[] { "Code", "Name" },
                values: new object[] { "86.1", "86.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 862,
                columns: new[] { "Code", "Name" },
                values: new object[] { "86.2", "86.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 863,
                columns: new[] { "Code", "Name" },
                values: new object[] { "86.3", "86.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 864,
                columns: new[] { "Code", "Name" },
                values: new object[] { "86.4", "86.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 865,
                columns: new[] { "Code", "Name" },
                values: new object[] { "86.5", "86.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 866,
                columns: new[] { "Code", "Name" },
                values: new object[] { "86.6", "86.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 867,
                columns: new[] { "Code", "Name" },
                values: new object[] { "86.7", "86.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 868,
                columns: new[] { "Code", "Name" },
                values: new object[] { "86.8", "86.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 869,
                columns: new[] { "Code", "Name" },
                values: new object[] { "86.9", "86.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 871,
                columns: new[] { "Code", "Name" },
                values: new object[] { "87.1", "87.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 872,
                columns: new[] { "Code", "Name" },
                values: new object[] { "87.2", "87.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 873,
                columns: new[] { "Code", "Name" },
                values: new object[] { "87.3", "87.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 874,
                columns: new[] { "Code", "Name" },
                values: new object[] { "87.4", "87.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 875,
                columns: new[] { "Code", "Name" },
                values: new object[] { "87.5", "87.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 876,
                columns: new[] { "Code", "Name" },
                values: new object[] { "87.6", "87.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 877,
                columns: new[] { "Code", "Name" },
                values: new object[] { "87.7", "87.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 878,
                columns: new[] { "Code", "Name" },
                values: new object[] { "87.8", "87.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 879,
                columns: new[] { "Code", "Name" },
                values: new object[] { "87.9", "87.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 881,
                columns: new[] { "Code", "Name" },
                values: new object[] { "88.1", "88.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 882,
                columns: new[] { "Code", "Name" },
                values: new object[] { "88.2", "88.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 883,
                columns: new[] { "Code", "Name" },
                values: new object[] { "88.3", "88.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 884,
                columns: new[] { "Code", "Name" },
                values: new object[] { "88.4", "88.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 885,
                columns: new[] { "Code", "Name" },
                values: new object[] { "88.5", "88.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 886,
                columns: new[] { "Code", "Name" },
                values: new object[] { "88.6", "88.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 887,
                columns: new[] { "Code", "Name" },
                values: new object[] { "88.7", "88.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 888,
                columns: new[] { "Code", "Name" },
                values: new object[] { "88.8", "88.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 889,
                columns: new[] { "Code", "Name" },
                values: new object[] { "88.9", "88.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 891,
                columns: new[] { "Code", "Name" },
                values: new object[] { "89.1", "89.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 892,
                columns: new[] { "Code", "Name" },
                values: new object[] { "89.2", "89.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 893,
                columns: new[] { "Code", "Name" },
                values: new object[] { "89.3", "89.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 894,
                columns: new[] { "Code", "Name" },
                values: new object[] { "89.4", "89.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 895,
                columns: new[] { "Code", "Name" },
                values: new object[] { "89.5", "89.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 896,
                columns: new[] { "Code", "Name" },
                values: new object[] { "89.6", "89.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 897,
                columns: new[] { "Code", "Name" },
                values: new object[] { "89.7", "89.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 898,
                columns: new[] { "Code", "Name" },
                values: new object[] { "89.8", "89.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 899,
                columns: new[] { "Code", "Name" },
                values: new object[] { "89.9", "89.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 901,
                columns: new[] { "Code", "Name" },
                values: new object[] { "90.1", "90.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 902,
                columns: new[] { "Code", "Name" },
                values: new object[] { "90.2", "90.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 903,
                columns: new[] { "Code", "Name" },
                values: new object[] { "90.3", "90.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 904,
                columns: new[] { "Code", "Name" },
                values: new object[] { "90.4", "90.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 905,
                columns: new[] { "Code", "Name" },
                values: new object[] { "90.5", "90.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 906,
                columns: new[] { "Code", "Name" },
                values: new object[] { "90.6", "90.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 907,
                columns: new[] { "Code", "Name" },
                values: new object[] { "90.7", "90.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 908,
                columns: new[] { "Code", "Name" },
                values: new object[] { "90.8", "90.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 909,
                columns: new[] { "Code", "Name" },
                values: new object[] { "90.9", "90.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 911,
                columns: new[] { "Code", "Name" },
                values: new object[] { "91.1", "91.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 912,
                columns: new[] { "Code", "Name" },
                values: new object[] { "91.2", "91.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 913,
                columns: new[] { "Code", "Name" },
                values: new object[] { "91.3", "91.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 914,
                columns: new[] { "Code", "Name" },
                values: new object[] { "91.4", "91.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 915,
                columns: new[] { "Code", "Name" },
                values: new object[] { "91.5", "91.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 916,
                columns: new[] { "Code", "Name" },
                values: new object[] { "91.6", "91.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 917,
                columns: new[] { "Code", "Name" },
                values: new object[] { "91.7", "91.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 918,
                columns: new[] { "Code", "Name" },
                values: new object[] { "91.8", "91.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 919,
                columns: new[] { "Code", "Name" },
                values: new object[] { "91.9", "91.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 921,
                columns: new[] { "Code", "Name" },
                values: new object[] { "92.1", "92.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 922,
                columns: new[] { "Code", "Name" },
                values: new object[] { "92.2", "92.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 923,
                columns: new[] { "Code", "Name" },
                values: new object[] { "92.3", "92.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 924,
                columns: new[] { "Code", "Name" },
                values: new object[] { "92.4", "92.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 925,
                columns: new[] { "Code", "Name" },
                values: new object[] { "92.5", "92.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 926,
                columns: new[] { "Code", "Name" },
                values: new object[] { "92.6", "92.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 927,
                columns: new[] { "Code", "Name" },
                values: new object[] { "92.7", "92.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 928,
                columns: new[] { "Code", "Name" },
                values: new object[] { "92.8", "92.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 929,
                columns: new[] { "Code", "Name" },
                values: new object[] { "92.9", "92.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 931,
                columns: new[] { "Code", "Name" },
                values: new object[] { "93.1", "93.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 932,
                columns: new[] { "Code", "Name" },
                values: new object[] { "93.2", "93.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 933,
                columns: new[] { "Code", "Name" },
                values: new object[] { "93.3", "93.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 934,
                columns: new[] { "Code", "Name" },
                values: new object[] { "93.4", "93.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 935,
                columns: new[] { "Code", "Name" },
                values: new object[] { "93.5", "93.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 936,
                columns: new[] { "Code", "Name" },
                values: new object[] { "93.6", "93.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 937,
                columns: new[] { "Code", "Name" },
                values: new object[] { "93.7", "93.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 938,
                columns: new[] { "Code", "Name" },
                values: new object[] { "93.8", "93.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 939,
                columns: new[] { "Code", "Name" },
                values: new object[] { "93.9", "93.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 941,
                columns: new[] { "Code", "Name" },
                values: new object[] { "94.1", "94.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 942,
                columns: new[] { "Code", "Name" },
                values: new object[] { "94.2", "94.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 943,
                columns: new[] { "Code", "Name" },
                values: new object[] { "94.3", "94.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 944,
                columns: new[] { "Code", "Name" },
                values: new object[] { "94.4", "94.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 945,
                columns: new[] { "Code", "Name" },
                values: new object[] { "94.5", "94.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 946,
                columns: new[] { "Code", "Name" },
                values: new object[] { "94.6", "94.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 947,
                columns: new[] { "Code", "Name" },
                values: new object[] { "94.7", "94.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 948,
                columns: new[] { "Code", "Name" },
                values: new object[] { "94.8", "94.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 949,
                columns: new[] { "Code", "Name" },
                values: new object[] { "94.9", "94.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 951,
                columns: new[] { "Code", "Name" },
                values: new object[] { "95.1", "95.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 952,
                columns: new[] { "Code", "Name" },
                values: new object[] { "95.2", "95.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 953,
                columns: new[] { "Code", "Name" },
                values: new object[] { "95.3", "95.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 954,
                columns: new[] { "Code", "Name" },
                values: new object[] { "95.4", "95.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 955,
                columns: new[] { "Code", "Name" },
                values: new object[] { "95.5", "95.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 956,
                columns: new[] { "Code", "Name" },
                values: new object[] { "95.6", "95.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 957,
                columns: new[] { "Code", "Name" },
                values: new object[] { "95.7", "95.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 958,
                columns: new[] { "Code", "Name" },
                values: new object[] { "95.8", "95.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 959,
                columns: new[] { "Code", "Name" },
                values: new object[] { "95.9", "95.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 961,
                columns: new[] { "Code", "Name" },
                values: new object[] { "96.1", "96.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 962,
                columns: new[] { "Code", "Name" },
                values: new object[] { "96.2", "96.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 963,
                columns: new[] { "Code", "Name" },
                values: new object[] { "96.3", "96.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 964,
                columns: new[] { "Code", "Name" },
                values: new object[] { "96.4", "96.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 965,
                columns: new[] { "Code", "Name" },
                values: new object[] { "96.5", "96.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 966,
                columns: new[] { "Code", "Name" },
                values: new object[] { "96.6", "96.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 967,
                columns: new[] { "Code", "Name" },
                values: new object[] { "96.7", "96.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 968,
                columns: new[] { "Code", "Name" },
                values: new object[] { "96.8", "96.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 969,
                columns: new[] { "Code", "Name" },
                values: new object[] { "96.9", "96.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 971,
                columns: new[] { "Code", "Name" },
                values: new object[] { "97.1", "97.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 972,
                columns: new[] { "Code", "Name" },
                values: new object[] { "97.2", "97.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 973,
                columns: new[] { "Code", "Name" },
                values: new object[] { "97.3", "97.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 974,
                columns: new[] { "Code", "Name" },
                values: new object[] { "97.4", "97.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 975,
                columns: new[] { "Code", "Name" },
                values: new object[] { "97.5", "97.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 976,
                columns: new[] { "Code", "Name" },
                values: new object[] { "97.6", "97.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 977,
                columns: new[] { "Code", "Name" },
                values: new object[] { "97.7", "97.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 978,
                columns: new[] { "Code", "Name" },
                values: new object[] { "97.8", "97.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 979,
                columns: new[] { "Code", "Name" },
                values: new object[] { "97.9", "97.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 981,
                columns: new[] { "Code", "Name" },
                values: new object[] { "98.1", "98.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 982,
                columns: new[] { "Code", "Name" },
                values: new object[] { "98.2", "98.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 983,
                columns: new[] { "Code", "Name" },
                values: new object[] { "98.3", "98.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 984,
                columns: new[] { "Code", "Name" },
                values: new object[] { "98.4", "98.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 985,
                columns: new[] { "Code", "Name" },
                values: new object[] { "98.5", "98.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 986,
                columns: new[] { "Code", "Name" },
                values: new object[] { "98.6", "98.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 987,
                columns: new[] { "Code", "Name" },
                values: new object[] { "98.7", "98.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 988,
                columns: new[] { "Code", "Name" },
                values: new object[] { "98.8", "98.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 989,
                columns: new[] { "Code", "Name" },
                values: new object[] { "98.9", "98.9" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 991,
                columns: new[] { "Code", "Name" },
                values: new object[] { "99.1", "99.1" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 992,
                columns: new[] { "Code", "Name" },
                values: new object[] { "99.2", "99.2" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 993,
                columns: new[] { "Code", "Name" },
                values: new object[] { "99.3", "99.3" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 994,
                columns: new[] { "Code", "Name" },
                values: new object[] { "99.4", "99.4" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 995,
                columns: new[] { "Code", "Name" },
                values: new object[] { "99.5", "99.5" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 996,
                columns: new[] { "Code", "Name" },
                values: new object[] { "99.6", "99.6" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 997,
                columns: new[] { "Code", "Name" },
                values: new object[] { "99.7", "99.7" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 998,
                columns: new[] { "Code", "Name" },
                values: new object[] { "99.8", "99.8" });

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 999,
                columns: new[] { "Code", "Name" },
                values: new object[] { "99.9", "99.9" });

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
                name: "IX_ZombieKill_ZombieId",
                table: "ZombieKill",
                column: "ZombieId");

            migrationBuilder.AddForeignKey(
                name: "FK_TowerProgress_UserProgress_UserProgressId",
                table: "TowerProgress",
                column: "UserProgressId",
                principalTable: "UserProgress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProgress_Stage_StageId",
                table: "UserProgress",
                column: "StageId",
                principalTable: "Stage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ZombieKill_Zombie_ZombieId",
                table: "ZombieKill",
                column: "ZombieId",
                principalTable: "Zombie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
