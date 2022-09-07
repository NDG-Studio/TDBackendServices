using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class buildingtypesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BuildingType",
                columns: new[] { "Id", "IsActive", "MaxLevel", "Name" },
                values: new object[,]
                {
                    { 2, true, 1000, "Gang Tower" },
                    { 3, true, 1000, "Wall" },
                    { 4, true, 1000, "Hospital" },
                    { 5, true, 1000, "Prison" },
                    { 6, true, 1000, "Market" },
                    { 7, true, 1000, "Altar" },
                    { 8, true, 1000, "Watch Tower" },
                    { 9, true, 1000, "Research Laboratory" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
