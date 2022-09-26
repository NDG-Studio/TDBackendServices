using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class buffinteractionforeignkeyproblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TalentTreeNode_BuffId",
                table: "TalentTreeNode",
                column: "BuffId");

            migrationBuilder.AddForeignKey(
                name: "FK_TalentTreeNode_Buff_BuffId",
                table: "TalentTreeNode",
                column: "BuffId",
                principalTable: "Buff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TalentTreeNode_Buff_BuffId",
                table: "TalentTreeNode");

            migrationBuilder.DropIndex(
                name: "IX_TalentTreeNode_BuffId",
                table: "TalentTreeNode");
        }
    }
}
