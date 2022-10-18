using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class playerbuffadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AttackMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "AutoLootRunActive",
                table: "Buff",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CityShieldActive",
                table: "Buff",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "DefenseMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SpyFakerMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "SpyProtectionActive",
                table: "Buff",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TroopCapacityMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "PlayerBuff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BuffId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerBuff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerBuff_Buff_BuffId",
                        column: x => x.BuffId,
                        principalTable: "Buff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBuff_BuffId",
                table: "PlayerBuff",
                column: "BuffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerBuff");

            migrationBuilder.DropColumn(
                name: "AttackMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "AutoLootRunActive",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "CityShieldActive",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "DefenseMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "SpyFakerMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "SpyProtectionActive",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "TroopCapacityMultiplier",
                table: "Buff");
        }
    }
}
