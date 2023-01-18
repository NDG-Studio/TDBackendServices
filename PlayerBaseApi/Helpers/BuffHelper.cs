using Microsoft.EntityFrameworkCore;
using PlayerBaseApi.Entities;
using SharedLibrary.Models;

namespace PlayerBaseApi.Helpers
{
    public static class BuffHelper
    {
        /// <summary>
        /// HeroId gönderilmezse veya null gönderilirse hero buffları eklenmez
        /// HeroId -1 gonderilirse sahip olunan butun herolar icin toplanir
        /// </summary>
        /// <param name="userId">bufflarına ulaşılmak istenen userın id değeri</param>
        /// <param name="heroId">heroya bağlı bufflara ulaşabilmek için gerekli olan heroId</param>
        /// <returns>Tüm buffların değerlerinin toplamı olan tek bir buff objesi döner</returns>
        public static async Task<BuffEffect> GetPlayersTotalBuff(long userId, int? heroId = null)
        {
            using (var _context = new PlayerBaseContext())
            {
                List<Buff> playerBuffs = new List<Buff>();

                if (heroId != null)
                {
                    var heroSkillBuffs = await _context.PlayerHeroSkillLevel.Include(l => l.HeroSkillLevel)
                        .ThenInclude(l => l.Buff)
                        .Where(l => l.UserId == userId && (l.HeroSkillLevel.HeroSkill.HeroId == heroId || heroId == -1))
                        .Select(l => l.HeroSkillLevel.Buff)
                        .ToListAsync();

                    var heroTalentBuffs = await _context.PlayerTalentTreeNode.Include(l => l.TalentTreeNodeLevel)
                        .ThenInclude(l => l.Buff)
                        .Where(l => l.UserId == userId && (l.TalentTreeNodeLevel.TalentTreeNode.HeroId == heroId || heroId == -1))
                        .Select(l => l.TalentTreeNodeLevel.Buff)
                        .ToListAsync();

                    var playerHeroLevel = await _context.PlayerHero.Where(l => l.UserId == userId && (l.HeroId == heroId || heroId == -1))
                        .Select(l => l.CurrentLevel)
                        .FirstOrDefaultAsync();
                    var heroLevelBuffs = await _context.HeroLevelThreshold.Include(l => l.Buff)
                        .Where(h => (h.HeroId == heroId || heroId == -1) && h.Level == playerHeroLevel)
                        .Select(l => l.Buff)
                        .ToListAsync();

                    playerBuffs.AddRange(heroSkillBuffs);
                    playerBuffs.AddRange(heroTalentBuffs);
                    playerBuffs.AddRange(heroLevelBuffs);

                }

                var researchBuffs = await _context.PlayerResearchNode.Include(l => l.ResearchNode)
                    .ThenInclude(l => l.Buff)
                    .Where(l => l.UserId == userId)
                    .Select(l => l.ResearchNode.Buff)
                    .ToListAsync();
                var now = DateTimeOffset.UtcNow;
                var playerBuff = await _context.PlayerBuff.Include(l => l.Buff)
                    .Where(l => l.UserId == userId && l.EndDate > now)
                    .Select(l => l.Buff)
                    .ToListAsync();

                playerBuffs.AddRange(researchBuffs);
                playerBuffs.AddRange(playerBuff);
                var bb = new BuffEffect();


                bb.LootBluePrintMultiplier = playerBuffs.Sum(l => l.LootBluePrintMultiplier);
                bb.LootCapacity = playerBuffs.Sum(l => l.LootCapacity);
                bb.LootDurationMultiplier = playerBuffs.Sum(l => l.LootDurationMultiplier);
                bb.LootGemMultiplier = playerBuffs.Sum(l => l.LootGemMultiplier);
                bb.LootPerfectRunMultiplier = playerBuffs.Sum(l => l.LootPerfectRunMultiplier);
                bb.LootScrapMultiplier = playerBuffs.Sum(l => l.LootScrapMultiplier);
                bb.PrisonCapacityMultiplier = playerBuffs.Sum(l => l.PrisonCapacityMultiplier);
                bb.PrisonCostMultiplier = playerBuffs.Sum(l => l.PrisonCostMultiplier);
                bb.PrisonerExecutionIncomeMultiplier = playerBuffs.Sum(l => l.PrisonerExecutionIncomeMultiplier);
                bb.PrisonerTrainCostMultiplier = playerBuffs.Sum(l => l.PrisonerTrainCostMultiplier);
                bb.PrisonTrainingDurationMultiplier = playerBuffs.Sum(l => l.PrisonTrainingDurationMultiplier);
                bb.BuildingUpgradeDurationMultiplier = playerBuffs.Sum(l => l.BuildingUpgradeDurationMultiplier);
                bb.TroopTrainingMultiplier = playerBuffs.Sum(l => l.TroopTrainingMultiplier);
                bb.TroopDamageMultiplier = playerBuffs.Sum(l => l.TroopDamageMultiplier);
                bb.ScrapProductionSpeedMultiplier = playerBuffs.Sum(l => l.ScrapProductionSpeedMultiplier);
                bb.BuildingUpgradeCostMultiplier = playerBuffs.Sum(l => l.BuildingUpgradeCostMultiplier);
                bb.TroopDefenseMultiplier = playerBuffs.Sum(l => l.TroopDefenseMultiplier);
                bb.SpyFakerMultiplier = playerBuffs.Sum(l => l.SpyFakerMultiplier);
                bb.TroopCapacityMultiplier = playerBuffs.Sum(l => l.TroopScrapCapacityMultiplier);
                bb.AutoLootRunActive = playerBuffs.Any(l => l.AutoLootRunActive);
                bb.CityShieldActive = playerBuffs.Any(l => l.CityShieldActive);
                bb.SpyProtectionActive = playerBuffs.Any(l => l.SpyProtectionActive);
                bb.CriticDamage = playerBuffs.Sum(l => l.CriticDamage);
                bb.CriticDamageChance = playerBuffs.Sum(l => l.CriticDamageChance);
                bb.AttackChance = playerBuffs.Sum(l => l.AttackChance);
                bb.DamageDiffrence = playerBuffs.Sum(l => l.DamageDiffrence);
                bb.FirstTimeDamage = (playerBuffs.Where(l => l.FirstTimeDamage != null).Select(l => l.FirstTimeDamage)
                    .ToList()??new List<string?>())!;
                bb.HealChance = playerBuffs.Sum(l => l.HealChance);
                bb.SkillDamage = playerBuffs.Sum(l => l.SkillDamage);
                bb.AfterBattleHealth = playerBuffs.Sum(l => l.AfterBattleHealth);
                bb.AfterCriticHeal = playerBuffs.Sum(l => l.AfterCriticHeal);
                bb.AttackReturnSpeed = playerBuffs.Sum(l => l.AttackReturnSpeed);
                bb.BaseDefenseMultiplier = playerBuffs.Sum(l => l.BaseDefenseMultiplier);
                bb.BeingPrisonerMultiplier = playerBuffs.Sum(l => l.BeingPrisonerMultiplier);
                bb.DamageDiffrenceNeutral = playerBuffs.Sum(l => l.DamageDiffrenceNeutral);
                bb.GettingPrisonerMultiplier = playerBuffs.Sum(l => l.GettingPrisonerMultiplier);
                bb.HealingCostMultiplier = playerBuffs.Sum(l => l.HealingCostMultiplier);
                bb.HeroBelowHealth = playerBuffs.Sum(l => l.HeroBelowHealth);
                bb.HeroDamageMultiplier = playerBuffs.Sum(l => l.HeroDamageMultiplier);
                bb.HeroHitCount = playerBuffs.Sum(l => l.HeroHitCount);
                bb.HeroHpMultiplier = playerBuffs.Sum(l => l.HeroHpMultiplier);
                bb.HeroExpMultiplier = playerBuffs.Sum(l => l.HeroExpMultiplier);
                bb.NeutralDamageMultiplier = playerBuffs.Sum(l => l.NeutralDamageMultiplier);
                bb.NeutralDefenseMultiplier = playerBuffs.Sum(l => l.NeutralDefenseMultiplier);
                bb.RallyReturnSpeed = playerBuffs.Sum(l => l.RallyReturnSpeed);
                bb.ResearchSpeedMultiplier = playerBuffs.Sum(l => l.ResearchSpeedMultiplier);
                bb.ResearchCostMultiplier = playerBuffs.Sum(l => l.ResearchCostMultiplier);
                bb.SkillDamageDefense = playerBuffs.Sum(l => l.SkillDamageDefense);
                bb.TeleportCostMultiplier = playerBuffs.Sum(l => l.TeleportCostMultiplier);
                bb.ActiveSkillCooldownDuration = playerBuffs.Sum(l => l.ActiveSkillCooldownDuration);
                bb.TroopHitCount = playerBuffs.Sum(l => l.TroopHitCount);
                bb.TroopHpMultiplier = playerBuffs.Sum(l => l.TroopHpMultiplier);
                bb.CityWallDefenseMultiplier = playerBuffs.Sum(l => l.CityWallDefenseMultiplier);
                bb.EnemyTroopDamageMultiplier = playerBuffs.Sum(l => l.EnemyTroopDamageMultiplier);
                bb.HeroMarchingSpeedMultiplier = playerBuffs.Sum(l => l.HeroMarchingSpeedMultiplier);
                bb.NeutralUnitCoinMultiplier = playerBuffs.Sum(l => l.NeutralUnitCoinMultiplier);
                bb.HeroSkillUseTroopGainHealth = playerBuffs.Sum(l => l.HeroSkillUseTroopGainHealth);
                bb.HeroLevelDamageMultiplier = playerBuffs.Sum(l => l.HeroLevelDamageMultiplier);
                bb.OtherGangDamageMultiplier = playerBuffs.Sum(l => l.OtherGangDamageMultiplier);
                bb.TroopMarchingSpeedMultiplier = playerBuffs.Sum(l => l.TroopMarchingSpeedMultiplier);
                bb.AfterActiveSkillImmuneSecond = playerBuffs.Count>0 ? playerBuffs.Select(l=>l.AfterActiveSkillImmuneSecond).Max() : 0;
                bb.OtherGangDefenseMultiplier = playerBuffs.Sum(l => l.OtherGangDefenseMultiplier);
                bb.SpyProductionTimeMultiplier = playerBuffs.Sum(l => l.SpyProductionTimeMultiplier);
                bb.SupportUnitTroopCapacityMultiplier = playerBuffs.Sum(l => l.SupportUnitTroopCapacityMultiplier);
                bb.TowerLevelPairs = playerBuffs
                    .Where(l => l.TowerId != 0 && l.TowerId != null && l.TowerLevel != null && l.TowerLevel != 0)
                    .Select(l => new TowerLevelPair()
                    {
                        TowerId = l.TowerId??0,
                        TowerLevel = l.TowerLevel??0
                    }).ToList();
                bb.AllTowerDamageMultiplier = playerBuffs.Sum(l => l.AllTowerDamageMultiplier);
                bb.AllTowerAttackSpeedMultiplier = playerBuffs.Sum(l => l.AllTowerAttackSpeedMultiplier);
                return bb;
            }
        }
        
        
        

        /// <param name="userId">bufflarına ulaşılmak istenen userın id değeri</param>
        /// <param name="heroId">heroya bağlı bufflara ulaşabilmek için gerekli olan heroId</param>
        /// <returns>Tüm buffların değerlerinin toplamı olan tek bir buff objesi döner</returns>
        public static async Task<BuffEffect> GetHeroTotalBuff(long userId, int heroId)
        {
            using (var _context = new PlayerBaseContext())
            {
                List<Buff> playerBuffs = new List<Buff>();

                if (heroId != null)
                {
                    var heroSkillBuffs = await _context.PlayerHeroSkillLevel.Include(l => l.HeroSkillLevel)
                        .ThenInclude(l => l.Buff)
                        .Where(l => l.UserId == userId && (l.HeroSkillLevel.HeroSkill.HeroId == heroId || heroId == -1))
                        .Select(l => l.HeroSkillLevel.Buff)
                        .ToListAsync();

                    var heroTalentBuffs = await _context.PlayerTalentTreeNode.Include(l => l.TalentTreeNodeLevel)
                        .ThenInclude(l => l.Buff)
                        .Where(l => l.UserId == userId && (l.TalentTreeNodeLevel.TalentTreeNode.HeroId == heroId || heroId == -1))
                        .Select(l => l.TalentTreeNodeLevel.Buff)
                        .ToListAsync();

                    var playerHeroLevel = await _context.PlayerHero.Where(l => l.UserId == userId && (l.HeroId == heroId || heroId == -1))
                        .Select(l => l.CurrentLevel)
                        .FirstOrDefaultAsync();
                    var heroLevelBuffs = await _context.HeroLevelThreshold.Include(l => l.Buff)
                        .Where(h => (h.HeroId == heroId || heroId == -1) && h.Level == playerHeroLevel)
                        .Select(l => l.Buff)
                        .ToListAsync();

                    playerBuffs.AddRange(heroSkillBuffs);
                    playerBuffs.AddRange(heroTalentBuffs);
                    playerBuffs.AddRange(heroLevelBuffs);

                }
                var bb = new BuffEffect();


                bb.LootBluePrintMultiplier = playerBuffs.Sum(l => l.LootBluePrintMultiplier);
                bb.LootCapacity = playerBuffs.Sum(l => l.LootCapacity);
                bb.LootDurationMultiplier = playerBuffs.Sum(l => l.LootDurationMultiplier);
                bb.LootGemMultiplier = playerBuffs.Sum(l => l.LootGemMultiplier);
                bb.LootPerfectRunMultiplier = playerBuffs.Sum(l => l.LootPerfectRunMultiplier);
                bb.LootScrapMultiplier = playerBuffs.Sum(l => l.LootScrapMultiplier);
                bb.PrisonCapacityMultiplier = playerBuffs.Sum(l => l.PrisonCapacityMultiplier);
                bb.PrisonCostMultiplier = playerBuffs.Sum(l => l.PrisonCostMultiplier);
                bb.PrisonerExecutionIncomeMultiplier = playerBuffs.Sum(l => l.PrisonerExecutionIncomeMultiplier);
                bb.PrisonerTrainCostMultiplier = playerBuffs.Sum(l => l.PrisonerTrainCostMultiplier);
                bb.PrisonTrainingDurationMultiplier = playerBuffs.Sum(l => l.PrisonTrainingDurationMultiplier);
                bb.BuildingUpgradeDurationMultiplier = playerBuffs.Sum(l => l.BuildingUpgradeDurationMultiplier);
                bb.TroopTrainingMultiplier = playerBuffs.Sum(l => l.TroopTrainingMultiplier);
                bb.TroopDamageMultiplier = playerBuffs.Sum(l => l.TroopDamageMultiplier);
                bb.ScrapProductionSpeedMultiplier = playerBuffs.Sum(l => l.ScrapProductionSpeedMultiplier);
                bb.BuildingUpgradeCostMultiplier = playerBuffs.Sum(l => l.BuildingUpgradeCostMultiplier);
                bb.TroopDefenseMultiplier = playerBuffs.Sum(l => l.TroopDefenseMultiplier);
                bb.SpyFakerMultiplier = playerBuffs.Sum(l => l.SpyFakerMultiplier);
                bb.TroopCapacityMultiplier = playerBuffs.Sum(l => l.TroopScrapCapacityMultiplier);
                bb.AutoLootRunActive = playerBuffs.Any(l => l.AutoLootRunActive);
                bb.CityShieldActive = playerBuffs.Any(l => l.CityShieldActive);
                bb.SpyProtectionActive = playerBuffs.Any(l => l.SpyProtectionActive);
                bb.CriticDamage = playerBuffs.Sum(l => l.CriticDamage);
                bb.CriticDamageChance = playerBuffs.Sum(l => l.CriticDamageChance);
                bb.AttackChance = playerBuffs.Sum(l => l.AttackChance);
                bb.DamageDiffrence = playerBuffs.Sum(l => l.DamageDiffrence);
                bb.FirstTimeDamage = (playerBuffs.Where(l => l.FirstTimeDamage != null).Select(l => l.FirstTimeDamage)
                    .ToList() ?? new List<string?>())!;
                bb.HealChance = playerBuffs.Sum(l => l.HealChance);
                bb.SkillDamage = playerBuffs.Sum(l => l.SkillDamage);
                bb.AfterBattleHealth = playerBuffs.Sum(l => l.AfterBattleHealth);
                bb.AfterCriticHeal = playerBuffs.Sum(l => l.AfterCriticHeal);
                bb.AttackReturnSpeed = playerBuffs.Sum(l => l.AttackReturnSpeed);
                bb.BaseDefenseMultiplier = playerBuffs.Sum(l => l.BaseDefenseMultiplier);
                bb.BeingPrisonerMultiplier = playerBuffs.Sum(l => l.BeingPrisonerMultiplier);
                bb.DamageDiffrenceNeutral = playerBuffs.Sum(l => l.DamageDiffrenceNeutral);
                bb.GettingPrisonerMultiplier = playerBuffs.Sum(l => l.GettingPrisonerMultiplier);
                bb.HealingCostMultiplier = playerBuffs.Sum(l => l.HealingCostMultiplier);
                bb.HeroBelowHealth = playerBuffs.Sum(l => l.HeroBelowHealth);
                bb.HeroDamageMultiplier = playerBuffs.Sum(l => l.HeroDamageMultiplier);
                bb.HeroHitCount = playerBuffs.Sum(l => l.HeroHitCount);
                bb.HeroHpMultiplier = playerBuffs.Sum(l => l.HeroHpMultiplier);
                bb.HeroExpMultiplier = playerBuffs.Sum(l => l.HeroExpMultiplier);
                bb.NeutralDamageMultiplier = playerBuffs.Sum(l => l.NeutralDamageMultiplier);
                bb.NeutralDefenseMultiplier = playerBuffs.Sum(l => l.NeutralDefenseMultiplier);
                bb.RallyReturnSpeed = playerBuffs.Sum(l => l.RallyReturnSpeed);
                bb.ResearchSpeedMultiplier = playerBuffs.Sum(l => l.ResearchSpeedMultiplier);
                bb.ResearchCostMultiplier = playerBuffs.Sum(l => l.ResearchCostMultiplier);
                bb.SkillDamageDefense = playerBuffs.Sum(l => l.SkillDamageDefense);
                bb.TeleportCostMultiplier = playerBuffs.Sum(l => l.TeleportCostMultiplier);
                bb.ActiveSkillCooldownDuration = playerBuffs.Sum(l => l.ActiveSkillCooldownDuration);
                bb.TroopHitCount = playerBuffs.Sum(l => l.TroopHitCount);
                bb.TroopHpMultiplier = playerBuffs.Sum(l => l.TroopHpMultiplier);
                bb.CityWallDefenseMultiplier = playerBuffs.Sum(l => l.CityWallDefenseMultiplier);
                bb.EnemyTroopDamageMultiplier = playerBuffs.Sum(l => l.EnemyTroopDamageMultiplier);
                bb.HeroMarchingSpeedMultiplier = playerBuffs.Sum(l => l.HeroMarchingSpeedMultiplier);
                bb.NeutralUnitCoinMultiplier = playerBuffs.Sum(l => l.NeutralUnitCoinMultiplier);
                bb.HeroSkillUseTroopGainHealth = playerBuffs.Sum(l => l.HeroSkillUseTroopGainHealth);
                bb.HeroLevelDamageMultiplier = playerBuffs.Sum(l => l.HeroLevelDamageMultiplier);
                bb.OtherGangDamageMultiplier = playerBuffs.Sum(l => l.OtherGangDamageMultiplier);
                bb.TroopMarchingSpeedMultiplier = playerBuffs.Sum(l => l.TroopMarchingSpeedMultiplier);
                bb.AfterActiveSkillImmuneSecond = playerBuffs.Count>0 ? playerBuffs.Select(l=>l.AfterActiveSkillImmuneSecond).Max() : 0;
                bb.OtherGangDefenseMultiplier = playerBuffs.Sum(l => l.OtherGangDefenseMultiplier);
                bb.SpyProductionTimeMultiplier = playerBuffs.Sum(l => l.SpyProductionTimeMultiplier);
                bb.SupportUnitTroopCapacityMultiplier = playerBuffs.Sum(l => l.SupportUnitTroopCapacityMultiplier);
                bb.TowerLevelPairs = playerBuffs
                    .Where(l => l.TowerId != 0 && l.TowerId != null && l.TowerLevel != null && l.TowerLevel != 0)
                    .Select(l => new TowerLevelPair()
                    {
                        TowerId = l.TowerId ?? 0,
                        TowerLevel = l.TowerLevel ?? 0
                    }).ToList();
                bb.AllTowerDamageMultiplier = playerBuffs.Sum(l => l.AllTowerDamageMultiplier);
                bb.AllTowerAttackSpeedMultiplier = playerBuffs.Sum(l => l.AllTowerAttackSpeedMultiplier);
                return bb;
            }
        }
    }
}