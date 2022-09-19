using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class playerbaseinfonewpropsaddedfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ResourceProductionPerHour",
                table: "PlayerBaseInfo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ResourceProductionPerHour",
                table: "PlayerBaseInfo",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
