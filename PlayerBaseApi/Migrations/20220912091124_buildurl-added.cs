using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class buildurladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuildUrl",
                table: "BuildingType",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 1,
                column: "BuildUrl",
                value: "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-5.png");

            migrationBuilder.UpdateData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 2,
                column: "BuildUrl",
                value: "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png");

            migrationBuilder.UpdateData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 3,
                column: "BuildUrl",
                value: "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png");

            migrationBuilder.UpdateData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 4,
                column: "BuildUrl",
                value: "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png");

            migrationBuilder.UpdateData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 5,
                column: "BuildUrl",
                value: "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png");

            migrationBuilder.UpdateData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 6,
                column: "BuildUrl",
                value: "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png");

            migrationBuilder.UpdateData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 7,
                column: "BuildUrl",
                value: "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png");

            migrationBuilder.UpdateData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 8,
                column: "BuildUrl",
                value: "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png");

            migrationBuilder.UpdateData(
                table: "BuildingType",
                keyColumn: "Id",
                keyValue: 9,
                column: "BuildUrl",
                value: "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildUrl",
                table: "BuildingType");
        }
    }
}
