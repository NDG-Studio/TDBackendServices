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
                return new BuffEffect()
                {
                                     LootBluePrintMultiplier = playerBuffs.Sum(l => l.LootBluePrintMultiplier),
                    LootCapacity = playerBuffs.Sum(l => l.LootCapacity),
                    LootDurationMultiplier = playerBuffs.Sum(l => l.LootDurationMultiplier),
                    LootGemMultiplier = playerBuffs.Sum(l => l.LootGemMultiplier),
                    LootPerfectRunMultiplier = playerBuffs.Sum(l => l.LootPerfectRunMultiplier),
                    LootScrapMultiplier = playerBuffs.Sum(l => l.LootScrapMultiplier),
                    PrisonCapacityMultiplier = playerBuffs.Sum(l => l.PrisonCapacityMultiplier),
                    PrisonCostMultiplier = playerBuffs.Sum(l => l.PrisonCostMultiplier),
                    PrisonerExecutionIncomeMultiplier = playerBuffs.Sum(l => l.PrisonerExecutionIncomeMultiplier),
                    PrisonerTrainCostMultiplier = playerBuffs.Sum(l => l.PrisonerTrainCostMultiplier),
                    PrisonTrainingDurationMultiplier = playerBuffs.Sum(l => l.PrisonTrainingDurationMultiplier),
                    BuildingUpgradeDurationMultiplier = playerBuffs.Sum(l => l.BuildingUpgradeDurationMultiplier),
                    TroopTrainingMultiplier = playerBuffs.Sum(l => l.TroopTrainingMultiplier),
                    TroopDamageMultiplier = playerBuffs.Sum(l => l.TroopDamageMultiplier),
                    ScrapProductionSpeedMultiplier = playerBuffs.Sum(l => l.ScrapProductionSpeedMultiplier),
                    BuildingUpgradeCostMultiplier = playerBuffs.Sum(l => l.BuildingUpgradeCostMultiplier),
                    TroopDefenseMultiplier = playerBuffs.Sum(l => l.TroopDefenseMultiplier),
                    SpyFakerMultiplier = playerBuffs.Sum(l => l.SpyFakerMultiplier),
                    TroopCapacityMultiplier = playerBuffs.Sum(l => l.TroopCapacityMultiplier),
                    AutoLootRunActive = playerBuffs.Any(l => l.AutoLootRunActive),
                    CityShieldActive = playerBuffs.Any(l => l.CityShieldActive),
                    SpyProtectionActive = playerBuffs.Any(l => l.SpyProtectionActive),
                    CriticDamage = playerBuffs.Sum(l => l.CriticDamage),
                    CriticDamageChance = playerBuffs.Sum(l => l.CriticDamageChance),
                    AttackChance = playerBuffs.Sum(l=>l.AttackChance),
                    DamageDiffrence = playerBuffs.Sum(l=>l.DamageDiffrence),
                    FirstTime = playerBuffs.Sum(l=>l.FirstTime),
                    HealChance = playerBuffs.Sum(l=>l.HealChance),
                    SkillDamage = playerBuffs.Sum(l=>l.SkillDamage),
                    AfterBattleHealth = playerBuffs.Sum(l=>l.AfterBattleHealth),
                    AfterCriticHeal = playerBuffs.Sum(l=>l.AfterCriticHeal),
                    AttackReturnSpeed = playerBuffs.Sum(l=>l.AttackReturnSpeed),
                    BaseDefenseMultiplier = playerBuffs.Sum(l=>l.BaseDefenseMultiplier),
                    BeingPrisonerMultiplier = playerBuffs.Sum(l=>l.BeingPrisonerMultiplier),
                    DamageDiffrenceNeutral = playerBuffs.Sum(l=>l.DamageDiffrenceNeutral),
                    DamageWithTime = playerBuffs.Sum(l=>l.DamageWithTime),
                    GettingPrisonerMultiplier = playerBuffs.Sum(l=>l.GettingPrisonerMultiplier),
                    HealingCostMultiplier = playerBuffs.Sum(l=>l.HealingCostMultiplier),
                    HeroBelowHealth = playerBuffs.Sum(l=>l.HeroBelowHealth),
                    HeroDamageMultiplier = playerBuffs.Sum(l=>l.HeroDamageMultiplier),
                    HeroHitCount = playerBuffs.Sum(l=>l.HeroHitCount),
                    HeroHpMultiplier = playerBuffs.Sum(l=>l.HeroHpMultiplier),
                    HeroExpMultiplier = playerBuffs.Sum(l=>l.HeroExpMultiplier),
                    NeutralDamageMultiplier = playerBuffs.Sum(l=>l.NeutralDamageMultiplier),
                    NeutralDefenseMultiplier = playerBuffs.Sum(l=>l.NeutralDefenseMultiplier),
                    RallyReturnSpeed = playerBuffs.Sum(l=>l.RallyReturnSpeed),
                    ResearchSpeedMultiplier = playerBuffs.Sum(l=>l.ResearchSpeedMultiplier),
                    ResearchCostMultiplier = playerBuffs.Sum(l=>l.ResearchCostMultiplier),
                    SkillDamageDefense = playerBuffs.Sum(l=>l.SkillDamageDefense),
                    TeleportCostMultiplier = playerBuffs.Sum(l=>l.TeleportCostMultiplier),
                    ActiveSkillCooldownDuration = playerBuffs.Sum(l=>l.ActiveSkillCooldownDuration),
                    TroopHitCount = playerBuffs.Sum(l=>l.TroopHitCount),
                    TroopHpMultiplier = playerBuffs.Sum(l=>l.TroopHpMultiplier),
                    CityWallDefenseMultiplier = playerBuffs.Sum(l=>l.CityWallDefenseMultiplier),
                    EnemyTroopDamageMultiplier = playerBuffs.Sum(l=>l.EnemyTroopDamageMultiplier),
                    HeroMarchingSpeedMultiplier = playerBuffs.Sum(l=>l.HeroMarchingSpeedMultiplier),
                    NeutralUnitCoinMultiplier = playerBuffs.Sum(l=>l.NeutralUnitCoinMultiplier),
                    LootRunCapacityMultiplier = playerBuffs.Sum(l=>l.LootRunCapacityMultiplier),
                    HeroSkillUseTroopGainHealth = playerBuffs.Sum(l=>l.HeroSkillUseTroopGainHealth),
                    HeroLevelDamageMultiplier = playerBuffs.Sum(l=>l.HeroLevelDamageMultiplier),
                    LootRunDurationMultiplier = playerBuffs.Sum(l=>l.LootRunDurationMultiplier),
                    OtherGangDamageMultiplier = playerBuffs.Sum(l=>l.OtherGangDamageMultiplier),
                    TroopMarchingSpeedMultiplier = playerBuffs.Sum(l=>l.TroopMarchingSpeedMultiplier),
                    AfterActiveSkillImmuneSecond = playerBuffs.Sum(l=>l.AfterActiveSkillImmuneSecond),
                    OtherGangDefenseMultiplier = playerBuffs.Sum(l=>l.OtherGangDefenseMultiplier),
                    SpyProductionTimeMultiplier = playerBuffs.Sum(l=>l.SpyProductionTimeMultiplier),
                    SupportUnitTroopCapacityMultiplier = playerBuffs.Sum(l=>l.SupportUnitTroopCapacityMultiplier),
                    
                    
                };
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
                return new BuffEffect()
                {
                    LootBluePrintMultiplier = playerBuffs.Sum(l => l.LootBluePrintMultiplier),
                    LootCapacity = playerBuffs.Sum(l => l.LootCapacity),
                    LootDurationMultiplier = playerBuffs.Sum(l => l.LootDurationMultiplier),
                    LootGemMultiplier = playerBuffs.Sum(l => l.LootGemMultiplier),
                    LootPerfectRunMultiplier = playerBuffs.Sum(l => l.LootPerfectRunMultiplier),
                    LootScrapMultiplier = playerBuffs.Sum(l => l.LootScrapMultiplier),
                    PrisonCapacityMultiplier = playerBuffs.Sum(l => l.PrisonCapacityMultiplier),
                    PrisonCostMultiplier = playerBuffs.Sum(l => l.PrisonCostMultiplier),
                    PrisonerExecutionIncomeMultiplier = playerBuffs.Sum(l => l.PrisonerExecutionIncomeMultiplier),
                    PrisonerTrainCostMultiplier = playerBuffs.Sum(l => l.PrisonerTrainCostMultiplier),
                    PrisonTrainingDurationMultiplier = playerBuffs.Sum(l => l.PrisonTrainingDurationMultiplier),
                    BuildingUpgradeDurationMultiplier = playerBuffs.Sum(l => l.BuildingUpgradeDurationMultiplier),
                    TroopTrainingMultiplier = playerBuffs.Sum(l => l.TroopTrainingMultiplier),
                    TroopDamageMultiplier = playerBuffs.Sum(l => l.TroopDamageMultiplier),
                    ScrapProductionSpeedMultiplier = playerBuffs.Sum(l => l.ScrapProductionSpeedMultiplier),
                    BuildingUpgradeCostMultiplier = playerBuffs.Sum(l => l.BuildingUpgradeCostMultiplier),
                    TroopDefenseMultiplier = playerBuffs.Sum(l => l.TroopDefenseMultiplier),
                    SpyFakerMultiplier = playerBuffs.Sum(l => l.SpyFakerMultiplier),
                    TroopCapacityMultiplier = playerBuffs.Sum(l => l.TroopCapacityMultiplier),
                    AutoLootRunActive = playerBuffs.Any(l => l.AutoLootRunActive),
                    CityShieldActive = playerBuffs.Any(l => l.CityShieldActive),
                    SpyProtectionActive = playerBuffs.Any(l => l.SpyProtectionActive),
                    CriticDamage = playerBuffs.Sum(l => l.CriticDamage),
                    CriticDamageChance = playerBuffs.Sum(l => l.CriticDamageChance),
                    AttackChance = playerBuffs.Sum(l=>l.AttackChance),
                    DamageDiffrence = playerBuffs.Sum(l=>l.DamageDiffrence),
                    FirstTime = playerBuffs.Sum(l=>l.FirstTime),
                    HealChance = playerBuffs.Sum(l=>l.HealChance),
                    SkillDamage = playerBuffs.Sum(l=>l.SkillDamage),
                    AfterBattleHealth = playerBuffs.Sum(l=>l.AfterBattleHealth),
                    AfterCriticHeal = playerBuffs.Sum(l=>l.AfterCriticHeal),
                    AttackReturnSpeed = playerBuffs.Sum(l=>l.AttackReturnSpeed),
                    BaseDefenseMultiplier = playerBuffs.Sum(l=>l.BaseDefenseMultiplier),
                    BeingPrisonerMultiplier = playerBuffs.Sum(l=>l.BeingPrisonerMultiplier),
                    DamageDiffrenceNeutral = playerBuffs.Sum(l=>l.DamageDiffrenceNeutral),
                    DamageWithTime = playerBuffs.Sum(l=>l.DamageWithTime),
                    GettingPrisonerMultiplier = playerBuffs.Sum(l=>l.GettingPrisonerMultiplier),
                    HealingCostMultiplier = playerBuffs.Sum(l=>l.HealingCostMultiplier),
                    HeroBelowHealth = playerBuffs.Sum(l=>l.HeroBelowHealth),
                    HeroDamageMultiplier = playerBuffs.Sum(l=>l.HeroDamageMultiplier),
                    HeroHitCount = playerBuffs.Sum(l=>l.HeroHitCount),
                    HeroHpMultiplier = playerBuffs.Sum(l=>l.HeroHpMultiplier),
                    HeroExpMultiplier = playerBuffs.Sum(l=>l.HeroExpMultiplier),
                    NeutralDamageMultiplier = playerBuffs.Sum(l=>l.NeutralDamageMultiplier),
                    NeutralDefenseMultiplier = playerBuffs.Sum(l=>l.NeutralDefenseMultiplier),
                    RallyReturnSpeed = playerBuffs.Sum(l=>l.RallyReturnSpeed),
                    ResearchSpeedMultiplier = playerBuffs.Sum(l=>l.ResearchSpeedMultiplier),
                    ResearchCostMultiplier = playerBuffs.Sum(l=>l.ResearchCostMultiplier),
                    SkillDamageDefense = playerBuffs.Sum(l=>l.SkillDamageDefense),
                    TeleportCostMultiplier = playerBuffs.Sum(l=>l.TeleportCostMultiplier),
                    ActiveSkillCooldownDuration = playerBuffs.Sum(l=>l.ActiveSkillCooldownDuration),
                    TroopHitCount = playerBuffs.Sum(l=>l.TroopHitCount),
                    TroopHpMultiplier = playerBuffs.Sum(l=>l.TroopHpMultiplier),
                    CityWallDefenseMultiplier = playerBuffs.Sum(l=>l.CityWallDefenseMultiplier),
                    EnemyTroopDamageMultiplier = playerBuffs.Sum(l=>l.EnemyTroopDamageMultiplier),
                    HeroMarchingSpeedMultiplier = playerBuffs.Sum(l=>l.HeroMarchingSpeedMultiplier),
                    NeutralUnitCoinMultiplier = playerBuffs.Sum(l=>l.NeutralUnitCoinMultiplier),
                    LootRunCapacityMultiplier = playerBuffs.Sum(l=>l.LootRunCapacityMultiplier),
                    HeroSkillUseTroopGainHealth = playerBuffs.Sum(l=>l.HeroSkillUseTroopGainHealth),
                    HeroLevelDamageMultiplier = playerBuffs.Sum(l=>l.HeroLevelDamageMultiplier),
                    LootRunDurationMultiplier = playerBuffs.Sum(l=>l.LootRunDurationMultiplier),
                    OtherGangDamageMultiplier = playerBuffs.Sum(l=>l.OtherGangDamageMultiplier),
                    TroopMarchingSpeedMultiplier = playerBuffs.Sum(l=>l.TroopMarchingSpeedMultiplier),
                    AfterActiveSkillImmuneSecond = playerBuffs.Sum(l=>l.AfterActiveSkillImmuneSecond),
                    OtherGangDefenseMultiplier = playerBuffs.Sum(l=>l.OtherGangDefenseMultiplier),
                    SpyProductionTimeMultiplier = playerBuffs.Sum(l=>l.SpyProductionTimeMultiplier),
                    SupportUnitTroopCapacityMultiplier = playerBuffs.Sum(l=>l.SupportUnitTroopCapacityMultiplier),
                    
                    
                };
            }
        }
    }
}