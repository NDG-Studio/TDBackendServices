using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class buildingupdatetimemigrated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BuildingUpdateTime",
                columns: new[] { "Id", "BuildingTypeId", "Level", "UpdateDuration" },
                values: new object[,]
                {
                    { 1, 1, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 2, 2, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 3, 3, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 4, 4, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 5, 5, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 6, 6, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 7, 7, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 8, 8, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 9, 9, 2, new TimeSpan(0, 0, 2, 0, 0) },
                    { 10, 1, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 11, 2, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 12, 3, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 13, 4, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 14, 5, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 15, 6, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 16, 7, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 17, 8, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 18, 9, 3, new TimeSpan(0, 0, 5, 0, 0) },
                    { 19, 1, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 20, 2, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 21, 3, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 22, 4, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 23, 5, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 24, 6, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 25, 7, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 26, 8, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 27, 9, 4, new TimeSpan(0, 0, 10, 0, 0) },
                    { 28, 1, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 29, 2, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 30, 3, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 31, 4, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 32, 5, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 33, 6, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 34, 7, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 35, 8, 5, new TimeSpan(0, 0, 30, 0, 0) },
                    { 36, 9, 5, new TimeSpan(0, 0, 30, 0, 0) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "BuildingUpdateTime",
                keyColumn: "Id",
                keyValue: 36);
        }
    }
}
