using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressApi.Migrations
{
    public partial class progress_splited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndGameScore",
                table: "UserProcess");

            migrationBuilder.DropColumn(
                name: "FailCount",
                table: "UserProcess");

            migrationBuilder.DropColumn(
                name: "KillCount",
                table: "UserProcess");

            migrationBuilder.DropColumn(
                name: "LevelEndTime",
                table: "UserProcess");

            migrationBuilder.AddColumn<double>(
                name: "BarrierHealth",
                table: "UserProcess",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "UserProcess",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ScrapValue",
                table: "UserProcess",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "StarCount",
                table: "UserProcess",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Time",
                table: "UserProcess",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stage",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Stage",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Stage",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarrierHealth",
                table: "UserProcess");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "UserProcess");

            migrationBuilder.DropColumn(
                name: "ScrapValue",
                table: "UserProcess");

            migrationBuilder.DropColumn(
                name: "StarCount",
                table: "UserProcess");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "UserProcess");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Stage");

            migrationBuilder.AddColumn<int>(
                name: "EndGameScore",
                table: "UserProcess",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FailCount",
                table: "UserProcess",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KillCount",
                table: "UserProcess",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LevelEndTime",
                table: "UserProcess",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stage",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
