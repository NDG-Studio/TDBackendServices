using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class supportunitcoordadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientCoord",
                table: "SupportUnit",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostCoord",
                table: "SupportUnit",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientCoord",
                table: "SupportUnit");

            migrationBuilder.DropColumn(
                name: "HostCoord",
                table: "SupportUnit");
        }
    }
}
