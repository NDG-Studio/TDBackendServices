using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class playerbaseinfonewpropsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "BaseFullDuration",
                table: "PlayerBaseInfo",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "Fuel",
                table: "PlayerBaseInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ResourceProductionPerHour",
                table: "PlayerBaseInfo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseFullDuration",
                table: "PlayerBaseInfo");

            migrationBuilder.DropColumn(
                name: "Fuel",
                table: "PlayerBaseInfo");

            migrationBuilder.DropColumn(
                name: "ResourceProductionPerHour",
                table: "PlayerBaseInfo");
        }
    }
}
