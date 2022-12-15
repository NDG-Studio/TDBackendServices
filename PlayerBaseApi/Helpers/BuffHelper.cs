using Microsoft.EntityFrameworkCore;
using PlayerBaseApi.Entities;

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
        public static async Task<Buff> GetPlayersTotalBuff(long userId, int? heroId = null)
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

                    var heroTalentBuffs = await _context.PlayerTalentTreeNode.Include(l => l.TalentTreeNode)
                        .ThenInclude(l => l.Buff)
                        .Where(l => l.UserId == userId && (l.TalentTreeNode.HeroId == heroId || heroId == -1))
                        .Select(l => l.TalentTreeNode.Buff)
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
                return new Buff()
                {
                    Id = playerBuffs.Count,
                    Name = "user total buff",
                    Description = "",
                    LootBluePrintMultiplier = playerBuffs.Sum(l => l.LootBluePrintMultiplier),
                    LootCapacity = playerBuffs.Sum(l => l.LootCapacity),
                    LootDurationMultiplier = playerBuffs.Sum(l => l.LootDurationMultiplier),
                    LootGemMultiplier = playerBuffs.Sum(l => l.LootGemMultiplier),
                    LootPerfectRunMultiplier = playerBuffs.Sum(l => l.LootPerfectRunMultiplier),
                    LootScrapMultiplier = playerBuffs.Sum(l => l.LootScrapMultiplier),
                    PrisonCapacityMultiplier = playerBuffs.Sum(l => l.PrisonCapacityMultiplier),
                    PrisonCostMultiplier = playerBuffs.Sum(l => l.PrisonCostMultiplier),
                    PrisonExecutionEarnMultiplier = playerBuffs.Sum(l => l.PrisonExecutionEarnMultiplier),
                    PrisonTrainingCostMultiplier = playerBuffs.Sum(l => l.PrisonTrainingCostMultiplier),
                    PrisonTrainingDurationMultiplier = playerBuffs.Sum(l => l.PrisonTrainingDurationMultiplier),
                    BuildingUpgradeDurationMultiplier = playerBuffs.Sum(l => l.BuildingUpgradeDurationMultiplier),
                    TroopTrainingMultiplier = playerBuffs.Sum(l => l.TroopTrainingMultiplier),
                    AttackMultiplier = playerBuffs.Sum(l => l.AttackMultiplier),
                    BaseResourceMultiplier = playerBuffs.Sum(l => l.BaseResourceMultiplier),
                    BuildingUpgradeCostMultiplier = playerBuffs.Sum(l => l.BuildingUpgradeCostMultiplier),
                    DefenseMultiplier = playerBuffs.Sum(l => l.DefenseMultiplier),
                    SpyFakerMultiplier = playerBuffs.Sum(l => l.SpyFakerMultiplier),
                    TroopCapacityMultiplier = playerBuffs.Sum(l => l.TroopCapacityMultiplier),
                    AutoLootRunActive = playerBuffs.Any(l => l.AutoLootRunActive),
                    CityShieldActive = playerBuffs.Any(l => l.CityShieldActive),
                    SpyProtectionActive = playerBuffs.Any(l => l.SpyProtectionActive)
                };
            }
        }
    }
}