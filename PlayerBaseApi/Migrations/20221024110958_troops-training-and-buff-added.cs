using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class troopstrainingandbuffadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastTroopCollect",
                table: "PlayerTroop",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "MaxDuration",
                table: "PlayerTroop",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "TrainingPerHour",
                table: "PlayerTroop",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TroopTrainingMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastTroopCollect",
                table: "PlayerTroop");

            migrationBuilder.DropColumn(
                name: "MaxDuration",
                table: "PlayerTroop");

            migrationBuilder.DropColumn(
                name: "TrainingPerHour",
                table: "PlayerTroop");

            migrationBuilder.DropColumn(
                name: "TroopTrainingMultiplier",
                table: "Buff");
        }
    }
}
