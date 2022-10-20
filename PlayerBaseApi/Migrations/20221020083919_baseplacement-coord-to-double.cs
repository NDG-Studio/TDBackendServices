using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class baseplacementcoordtodouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "CoordY",
                table: "PlayerBasePlacement",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "CoordX",
                table: "PlayerBasePlacement",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "PlayerBasePlacement",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CoordX", "CoordY" },
                values: new object[] { 1.0, 1.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CoordY",
                table: "PlayerBasePlacement",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "CoordX",
                table: "PlayerBasePlacement",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.UpdateData(
                table: "PlayerBasePlacement",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CoordX", "CoordY" },
                values: new object[] { 1, 1 });
        }
    }
}
