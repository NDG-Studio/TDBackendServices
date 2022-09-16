using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class playerheroentbugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EndDate",
                table: "PlayerHero",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "PlayerHero",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerHero_HeroId",
                table: "PlayerHero",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerHero_Hero_HeroId",
                table: "PlayerHero",
                column: "HeroId",
                principalTable: "Hero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerHero_Hero_HeroId",
                table: "PlayerHero");

            migrationBuilder.DropIndex(
                name: "IX_PlayerHero_HeroId",
                table: "PlayerHero");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "PlayerHero");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EndDate",
                table: "PlayerHero",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
