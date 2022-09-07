using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class initialnigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MaxLevel = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<string>(type: "text", nullable: true),
                    EventName = table.Column<string>(type: "text", nullable: true),
                    Ip = table.Column<string>(type: "text", nullable: false),
                    DeviceId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DeviceType = table.Column<string>(type: "text", nullable: true),
                    DeviceModel = table.Column<string>(type: "text", nullable: true),
                    OsVersion = table.Column<string>(type: "text", nullable: true),
                    AppVersion = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Duration = table.Column<double>(type: "double precision", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    Exception = table.Column<string>(type: "text", nullable: true),
                    InnerException = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogAction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<string>(type: "text", nullable: true),
                    EventName = table.Column<string>(type: "text", nullable: true),
                    Ip = table.Column<string>(type: "text", nullable: false),
                    DeviceId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DeviceType = table.Column<string>(type: "text", nullable: true),
                    DeviceModel = table.Column<string>(type: "text", nullable: true),
                    OsVersion = table.Column<string>(type: "text", nullable: true),
                    AppVersion = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Duration = table.Column<double>(type: "double precision", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogAction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerBasePlacement",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BuildingTypeId = table.Column<int>(type: "integer", nullable: false),
                    BuildingLevel = table.Column<int>(type: "integer", nullable: false),
                    UpdateEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CoordX = table.Column<int>(type: "integer", nullable: false),
                    CoordY = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerBasePlacement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerBasePlacement_BuildingType_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "BuildingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BuildingType",
                columns: new[] { "Id", "IsActive", "MaxLevel", "Name" },
                values: new object[] { 1, true, 1000, "Base" });

            migrationBuilder.InsertData(
                table: "PlayerBasePlacement",
                columns: new[] { "Id", "BuildingLevel", "BuildingTypeId", "CoordX", "CoordY", "UpdateEndDate", "UserId" },
                values: new object[] { 1L, 1, 1, 1, 1, null, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBasePlacement_BuildingTypeId",
                table: "PlayerBasePlacement",
                column: "BuildingTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "LogAction");

            migrationBuilder.DropTable(
                name: "PlayerBasePlacement");

            migrationBuilder.DropTable(
                name: "BuildingType");
        }
    }
}
