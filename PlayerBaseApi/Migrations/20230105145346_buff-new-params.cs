using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayerBaseApi.Migrations
{
    public partial class buffnewparams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTalentTreeNode_TalentTreeNode_TalentTreeNodeId",
                table: "PlayerTalentTreeNode");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentTreeNode_Buff_BuffId",
                table: "TalentTreeNode");

            migrationBuilder.DropIndex(
                name: "IX_TalentTreeNode_BuffId",
                table: "TalentTreeNode");

            migrationBuilder.DropColumn(
                name: "BuffId",
                table: "TalentTreeNode");

            migrationBuilder.RenameColumn(
                name: "TalentTreeNodeId",
                table: "PlayerTalentTreeNode",
                newName: "TalentTreeNodeLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTalentTreeNode_TalentTreeNodeId",
                table: "PlayerTalentTreeNode",
                newName: "IX_PlayerTalentTreeNode_TalentTreeNodeLevelId");

            migrationBuilder.RenameColumn(
                name: "PrisonTrainingCostMultiplier",
                table: "Buff",
                newName: "TroopMarchingSpeedMultiplier");

            migrationBuilder.RenameColumn(
                name: "PrisonExecutionEarnMultiplier",
                table: "Buff",
                newName: "TroopHpMultiplier");

            migrationBuilder.RenameColumn(
                name: "DefenseMultiplier",
                table: "Buff",
                newName: "TroopDefenseMultiplier");

            migrationBuilder.RenameColumn(
                name: "BaseResourceMultiplier",
                table: "Buff",
                newName: "TroopDamageMultiplier");

            migrationBuilder.RenameColumn(
                name: "AttackMultiplier",
                table: "Buff",
                newName: "TroopBelowHealth");

            migrationBuilder.AddColumn<double>(
                name: "ActiveSkillCooldownDuration",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "AfterActiveSkillImmuneSecond",
                table: "Buff",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "AfterBattleHealth",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AfterCriticHeal",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AllTowerAttackSpeedMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AllTowerDamageMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AttackChance",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AttackReturnSpeed",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BaseDefenseMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BeingPrisonerMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CityWallDefenseMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CriticDamage",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CriticDamageChance",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "DamageDiffrence",
                table: "Buff",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageDiffrenceNeutral",
                table: "Buff",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "DamageWithTime",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EnemyTroopDamageMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "EveryTroopsHitCount",
                table: "Buff",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirstTime",
                table: "Buff",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "GettingPrisonerMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HealChance",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HealChanceTroopCount",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HealingCostMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HeroBelowHealth",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HeroDamageMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HeroExpMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "HeroHitCount",
                table: "Buff",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "HeroHpMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HeroLevelDamageMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HeroMarchingSpeedMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HeroSkillUseTroopGainHealth",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LootRunCapacityMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LootRunDurationMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NeutralDamageMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NeutralDefenseMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NeutralUnitCoinMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OtherGangDamageMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OtherGangDefenseMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrisonerExecutionIncomeMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrisonerTrainCostMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RallyReturnSpeed",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ResearchCostMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ResearchSpeedMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ScrapProductionSpeedMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SkillDamage",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SkillDamageDefense",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SpyProductionTimeMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SupportUnitTroopCapacityMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TeleportCostMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TowerBuildCostMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TowerId",
                table: "Buff",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TowerKillCoinMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TowerLevel",
                table: "Buff",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TowerRangeMultiplier",
                table: "Buff",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TroopHitCount",
                table: "Buff",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TalentTreeNodeLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TalentTreeNodeId = table.Column<int>(type: "integer", nullable: false),
                    BuffId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentTreeNodeLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TalentTreeNodeLevel_Buff_BuffId",
                        column: x => x.BuffId,
                        principalTable: "Buff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TalentTreeNodeLevel_TalentTreeNode_TalentTreeNodeId",
                        column: x => x.TalentTreeNodeId,
                        principalTable: "TalentTreeNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TalentTreeNodeLevel_BuffId",
                table: "TalentTreeNodeLevel",
                column: "BuffId");

            migrationBuilder.CreateIndex(
                name: "IX_TalentTreeNodeLevel_TalentTreeNodeId",
                table: "TalentTreeNodeLevel",
                column: "TalentTreeNodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTalentTreeNode_TalentTreeNodeLevel_TalentTreeNodeLeve~",
                table: "PlayerTalentTreeNode",
                column: "TalentTreeNodeLevelId",
                principalTable: "TalentTreeNodeLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTalentTreeNode_TalentTreeNodeLevel_TalentTreeNodeLeve~",
                table: "PlayerTalentTreeNode");

            migrationBuilder.DropTable(
                name: "TalentTreeNodeLevel");

            migrationBuilder.DropColumn(
                name: "ActiveSkillCooldownDuration",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "AfterActiveSkillImmuneSecond",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "AfterBattleHealth",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "AfterCriticHeal",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "AllTowerAttackSpeedMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "AllTowerDamageMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "AttackChance",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "AttackReturnSpeed",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "BaseDefenseMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "BeingPrisonerMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "CityWallDefenseMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "CriticDamage",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "CriticDamageChance",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "DamageDiffrence",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "DamageDiffrenceNeutral",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "DamageWithTime",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "EnemyTroopDamageMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "EveryTroopsHitCount",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "FirstTime",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "GettingPrisonerMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HealChance",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HealChanceTroopCount",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HealingCostMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HeroBelowHealth",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HeroDamageMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HeroExpMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HeroHitCount",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HeroHpMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HeroLevelDamageMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HeroMarchingSpeedMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "HeroSkillUseTroopGainHealth",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "LootRunCapacityMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "LootRunDurationMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "NeutralDamageMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "NeutralDefenseMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "NeutralUnitCoinMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "OtherGangDamageMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "OtherGangDefenseMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "PrisonerExecutionIncomeMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "PrisonerTrainCostMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "RallyReturnSpeed",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "ResearchCostMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "ResearchSpeedMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "ScrapProductionSpeedMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "SkillDamage",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "SkillDamageDefense",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "SpyProductionTimeMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "SupportUnitTroopCapacityMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "TeleportCostMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "TowerBuildCostMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "TowerId",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "TowerKillCoinMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "TowerLevel",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "TowerRangeMultiplier",
                table: "Buff");

            migrationBuilder.DropColumn(
                name: "TroopHitCount",
                table: "Buff");

            migrationBuilder.RenameColumn(
                name: "TalentTreeNodeLevelId",
                table: "PlayerTalentTreeNode",
                newName: "TalentTreeNodeId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTalentTreeNode_TalentTreeNodeLevelId",
                table: "PlayerTalentTreeNode",
                newName: "IX_PlayerTalentTreeNode_TalentTreeNodeId");

            migrationBuilder.RenameColumn(
                name: "TroopMarchingSpeedMultiplier",
                table: "Buff",
                newName: "PrisonTrainingCostMultiplier");

            migrationBuilder.RenameColumn(
                name: "TroopHpMultiplier",
                table: "Buff",
                newName: "PrisonExecutionEarnMultiplier");

            migrationBuilder.RenameColumn(
                name: "TroopDefenseMultiplier",
                table: "Buff",
                newName: "DefenseMultiplier");

            migrationBuilder.RenameColumn(
                name: "TroopDamageMultiplier",
                table: "Buff",
                newName: "BaseResourceMultiplier");

            migrationBuilder.RenameColumn(
                name: "TroopBelowHealth",
                table: "Buff",
                newName: "AttackMultiplier");

            migrationBuilder.AddColumn<int>(
                name: "BuffId",
                table: "TalentTreeNode",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TalentTreeNode_BuffId",
                table: "TalentTreeNode",
                column: "BuffId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTalentTreeNode_TalentTreeNode_TalentTreeNodeId",
                table: "PlayerTalentTreeNode",
                column: "TalentTreeNodeId",
                principalTable: "TalentTreeNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentTreeNode_Buff_BuffId",
                table: "TalentTreeNode",
                column: "BuffId",
                principalTable: "Buff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
