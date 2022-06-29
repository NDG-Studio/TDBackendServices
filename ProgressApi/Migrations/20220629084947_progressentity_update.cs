using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressApi.Migrations
{
    public partial class progressentity_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserProcess",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "UserProcess",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserProcess");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "UserProcess");
        }
    }
}
