using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityApi.Migrations
{
    public partial class logchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Values",
                table: "Log");

            migrationBuilder.RenameColumn(
                name: "TimeMs",
                table: "Log",
                newName: "InnerException");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Log",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ip",
                table: "Log",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                table: "Log",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "Log",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "Log",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Log",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Duration",
                table: "Log",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventId",
                table: "Log",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "Log",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Exception",
                table: "Log",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LastSeen",
                value: new DateTimeOffset(new DateTime(2022, 7, 18, 17, 46, 23, 457, DateTimeKind.Unspecified).AddTicks(9231), new TimeSpan(0, 3, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "EventName",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Exception",
                table: "Log");

            migrationBuilder.RenameColumn(
                name: "InnerException",
                table: "Log",
                newName: "TimeMs");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Log",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Ip",
                table: "Log",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                table: "Log",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Values",
                table: "Log",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LastSeen",
                value: new DateTimeOffset(new DateTime(2022, 7, 16, 13, 56, 18, 784, DateTimeKind.Unspecified).AddTicks(8267), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
