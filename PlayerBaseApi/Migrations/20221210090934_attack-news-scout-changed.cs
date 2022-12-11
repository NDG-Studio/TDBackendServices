using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class attacknewsscoutchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenderUsername",
                table: "Scout",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetUsername",
                table: "Scout",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderUsername",
                table: "Scout");

            migrationBuilder.DropColumn(
                name: "TargetUsername",
                table: "Scout");
        }
    }
}
