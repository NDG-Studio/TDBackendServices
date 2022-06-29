using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProgressApi.Migrations
{
    public partial class init_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProcess",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    StageId = table.Column<int>(type: "integer", nullable: true),
                    FailCount = table.Column<int>(type: "integer", nullable: true),
                    KillCount = table.Column<int>(type: "integer", nullable: true),
                    EndGameScore = table.Column<int>(type: "integer", nullable: true),
                    Ip = table.Column<string>(type: "text", nullable: true),
                    DeviceId = table.Column<string>(type: "text", nullable: true),
                    LevelStartTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LevelEndTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProcess_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Stage",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[] { 1, true, "FirstStage" });

            migrationBuilder.CreateIndex(
                name: "IX_UserProcess_StageId",
                table: "UserProcess",
                column: "StageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProcess");

            migrationBuilder.DropTable(
                name: "Stage");
        }
    }
}
