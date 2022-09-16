using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class talenttreenodesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TalentTree",
                columns: new[] { "Id", "BackgroundUrl", "Name", "ThemeColor" },
                values: new object[,]
                {
                    { 1, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg", "Talent Tree _1_", "#000000" },
                    { 2, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg", "Talent Tree _2_", "#2f2f2f" },
                    { 3, "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg", "Talent Tree _3_", "#ffffff" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TalentTree",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TalentTree",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TalentTree",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
