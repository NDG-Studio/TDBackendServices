using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class heropriceadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Hero",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rarity",
                table: "Hero",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Hero",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "Rarity" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Hero",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "Rarity" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Hero",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price", "Rarity" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Hero",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Price", "Rarity" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Hero",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Price", "Rarity" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Hero",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Price", "Rarity" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Hero",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Price", "Rarity" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Hero",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Price", "Rarity" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Hero",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Price", "Rarity" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Hero",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Price", "Rarity" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Hero",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Price", "Rarity" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "Rarity",
                table: "Hero");
        }
    }
}
