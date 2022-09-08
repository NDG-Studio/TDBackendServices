using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapApi.Migrations
{
    public partial class arealisttest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Zone",
                columns: new[] { "Id", "XMax", "XMin", "YMax", "YMin" },
                values: new object[,]
                {
                    { 1, 450, 0, 450, 0 },
                    { 2, 900, 450, 450, 0 },
                    { 3, 1350, 900, 450, 0 },
                    { 4, 450, 0, 900, 450 },
                    { 5, 900, 450, 900, 450 },
                    { 6, 1350, 900, 900, 450 },
                    { 7, 450, 0, 1350, 900 },
                    { 8, 900, 450, 1350, 900 },
                    { 9, 1350, 900, 1350, 900 },
                    { 10, 450, 0, 1800, 1350 },
                    { 11, 900, 450, 1800, 1350 },
                    { 12, 1350, 900, 1800, 1350 },
                    { 13, 450, 0, 2250, 1800 },
                    { 14, 900, 450, 2250, 1800 },
                    { 15, 1350, 900, 2250, 1800 }
                });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "Id", "XMax", "XMin", "YMax", "YMin", "ZoneId" },
                values: new object[,]
                {
                    { 1, 150, 0, 150, 0, 1 },
                    { 2, 300, 150, 150, 0, 1 },
                    { 3, 450, 300, 150, 0, 1 },
                    { 4, 600, 450, 300, 150, 1 },
                    { 5, 750, 600, 300, 150, 1 },
                    { 6, 900, 750, 300, 150, 1 },
                    { 7, 1050, 900, 450, 300, 1 },
                    { 8, 1200, 1050, 450, 300, 1 },
                    { 9, 1350, 1200, 450, 300, 1 },
                    { 10, 150, 0, 150, 0, 2 },
                    { 11, 300, 150, 150, 0, 2 },
                    { 12, 450, 300, 150, 0, 2 },
                    { 13, 600, 450, 300, 150, 2 },
                    { 14, 750, 600, 300, 150, 2 },
                    { 15, 900, 750, 300, 150, 2 },
                    { 16, 1050, 900, 450, 300, 2 },
                    { 17, 1200, 1050, 450, 300, 2 },
                    { 18, 1350, 1200, 450, 300, 2 },
                    { 19, 150, 0, 150, 0, 3 },
                    { 20, 300, 150, 150, 0, 3 },
                    { 21, 450, 300, 150, 0, 3 },
                    { 22, 600, 450, 300, 150, 3 },
                    { 23, 750, 600, 300, 150, 3 },
                    { 24, 900, 750, 300, 150, 3 },
                    { 25, 1050, 900, 450, 300, 3 },
                    { 26, 1200, 1050, 450, 300, 3 },
                    { 27, 1350, 1200, 450, 300, 3 },
                    { 28, 150, 0, 600, 450, 4 },
                    { 29, 300, 150, 600, 450, 4 },
                    { 30, 450, 300, 600, 450, 4 },
                    { 31, 600, 450, 750, 600, 4 },
                    { 32, 750, 600, 750, 600, 4 },
                    { 33, 900, 750, 750, 600, 4 },
                    { 34, 1050, 900, 900, 750, 4 },
                    { 35, 1200, 1050, 900, 750, 4 },
                    { 36, 1350, 1200, 900, 750, 4 },
                    { 37, 150, 0, 600, 450, 5 },
                    { 38, 300, 150, 600, 450, 5 },
                    { 39, 450, 300, 600, 450, 5 },
                    { 40, 600, 450, 750, 600, 5 },
                    { 41, 750, 600, 750, 600, 5 },
                    { 42, 900, 750, 750, 600, 5 },
                    { 43, 1050, 900, 900, 750, 5 },
                    { 44, 1200, 1050, 900, 750, 5 },
                    { 45, 1350, 1200, 900, 750, 5 },
                    { 46, 150, 0, 600, 450, 6 },
                    { 47, 300, 150, 600, 450, 6 },
                    { 48, 450, 300, 600, 450, 6 },
                    { 49, 600, 450, 750, 600, 6 },
                    { 50, 750, 600, 750, 600, 6 },
                    { 51, 900, 750, 750, 600, 6 },
                    { 52, 1050, 900, 900, 750, 6 },
                    { 53, 1200, 1050, 900, 750, 6 },
                    { 54, 1350, 1200, 900, 750, 6 },
                    { 55, 150, 0, 1050, 900, 7 },
                    { 56, 300, 150, 1050, 900, 7 },
                    { 57, 450, 300, 1050, 900, 7 },
                    { 58, 600, 450, 1200, 1050, 7 },
                    { 59, 750, 600, 1200, 1050, 7 },
                    { 60, 900, 750, 1200, 1050, 7 },
                    { 61, 1050, 900, 1350, 1200, 7 },
                    { 62, 1200, 1050, 1350, 1200, 7 },
                    { 63, 1350, 1200, 1350, 1200, 7 },
                    { 64, 150, 0, 1050, 900, 8 },
                    { 65, 300, 150, 1050, 900, 8 },
                    { 66, 450, 300, 1050, 900, 8 },
                    { 67, 600, 450, 1200, 1050, 8 },
                    { 68, 750, 600, 1200, 1050, 8 },
                    { 69, 900, 750, 1200, 1050, 8 },
                    { 70, 1050, 900, 1350, 1200, 8 },
                    { 71, 1200, 1050, 1350, 1200, 8 },
                    { 72, 1350, 1200, 1350, 1200, 8 },
                    { 73, 150, 0, 1050, 900, 9 },
                    { 74, 300, 150, 1050, 900, 9 },
                    { 75, 450, 300, 1050, 900, 9 },
                    { 76, 600, 450, 1200, 1050, 9 },
                    { 77, 750, 600, 1200, 1050, 9 },
                    { 78, 900, 750, 1200, 1050, 9 },
                    { 79, 1050, 900, 1350, 1200, 9 },
                    { 80, 1200, 1050, 1350, 1200, 9 },
                    { 81, 1350, 1200, 1350, 1200, 9 },
                    { 82, 150, 0, 1500, 1350, 10 },
                    { 83, 300, 150, 1500, 1350, 10 },
                    { 84, 450, 300, 1500, 1350, 10 },
                    { 85, 600, 450, 1650, 1500, 10 },
                    { 86, 750, 600, 1650, 1500, 10 },
                    { 87, 900, 750, 1650, 1500, 10 },
                    { 88, 1050, 900, 1800, 1650, 10 },
                    { 89, 1200, 1050, 1800, 1650, 10 },
                    { 90, 1350, 1200, 1800, 1650, 10 },
                    { 91, 150, 0, 1500, 1350, 11 },
                    { 92, 300, 150, 1500, 1350, 11 },
                    { 93, 450, 300, 1500, 1350, 11 },
                    { 94, 600, 450, 1650, 1500, 11 },
                    { 95, 750, 600, 1650, 1500, 11 },
                    { 96, 900, 750, 1650, 1500, 11 },
                    { 97, 1050, 900, 1800, 1650, 11 },
                    { 98, 1200, 1050, 1800, 1650, 11 },
                    { 99, 1350, 1200, 1800, 1650, 11 },
                    { 100, 150, 0, 1500, 1350, 12 },
                    { 101, 300, 150, 1500, 1350, 12 },
                    { 102, 450, 300, 1500, 1350, 12 },
                    { 103, 600, 450, 1650, 1500, 12 },
                    { 104, 750, 600, 1650, 1500, 12 },
                    { 105, 900, 750, 1650, 1500, 12 },
                    { 106, 1050, 900, 1800, 1650, 12 },
                    { 107, 1200, 1050, 1800, 1650, 12 },
                    { 108, 1350, 1200, 1800, 1650, 12 },
                    { 109, 150, 0, 1950, 1800, 13 },
                    { 110, 300, 150, 1950, 1800, 13 },
                    { 111, 450, 300, 1950, 1800, 13 },
                    { 112, 600, 450, 2100, 1950, 13 },
                    { 113, 750, 600, 2100, 1950, 13 },
                    { 114, 900, 750, 2100, 1950, 13 },
                    { 115, 1050, 900, 2250, 2100, 13 },
                    { 116, 1200, 1050, 2250, 2100, 13 },
                    { 117, 1350, 1200, 2250, 2100, 13 },
                    { 118, 150, 0, 1950, 1800, 14 },
                    { 119, 300, 150, 1950, 1800, 14 },
                    { 120, 450, 300, 1950, 1800, 14 },
                    { 121, 600, 450, 2100, 1950, 14 },
                    { 122, 750, 600, 2100, 1950, 14 },
                    { 123, 900, 750, 2100, 1950, 14 },
                    { 124, 1050, 900, 2250, 2100, 14 },
                    { 125, 1200, 1050, 2250, 2100, 14 },
                    { 126, 1350, 1200, 2250, 2100, 14 },
                    { 127, 150, 0, 1950, 1800, 15 },
                    { 128, 300, 150, 1950, 1800, 15 },
                    { 129, 450, 300, 1950, 1800, 15 },
                    { 130, 600, 450, 2100, 1950, 15 },
                    { 131, 750, 600, 2100, 1950, 15 },
                    { 132, 900, 750, 2100, 1950, 15 },
                    { 133, 1050, 900, 2250, 2100, 15 },
                    { 134, 1200, 1050, 2250, 2100, 15 },
                    { 135, 1350, 1200, 2250, 2100, 15 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Area",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
