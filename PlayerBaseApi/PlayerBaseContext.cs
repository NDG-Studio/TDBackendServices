﻿
using Microsoft.EntityFrameworkCore;
using PlayerBaseApi.Entities;
using PlayerBaseApi.Enums;
using PlayerBaseApi.Helpers;
using SharedLibrary.Entities;
using SharedLibrary.Models;

namespace PlayerBaseApi
{
    public class PlayerBaseContext : DbContext
    {
        public PlayerBaseContext(DbContextOptions<PlayerBaseContext> options) : base(options) { }

        public PlayerBaseContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionStrings__PlayerBaseContext"));
            }
        }

        public DbSet<Buff> Buff { get; set; }
        public DbSet<PlayerBuff> PlayerBuff { get; set; }
        public DbSet<BuildingType> BuildingType { get; set; }
        public DbSet<PlayerBasePlacement> PlayerBasePlacement { get; set; }
        public DbSet<PlayerBaseInfo> PlayerBaseInfo { get; set; } 
        public DbSet<BuildingUpgradeTime> BuildingUpgradeTime { get; set; }
        public DbSet<ResearchTable> ResearchTable { get; set; }
        public DbSet<ResearchNode> ResearchNode { get; set; }
        public DbSet<PlayerResearchNode> PlayerResearchNode { get; set; }
        public DbSet<ResearchNodeUpgradeNecessaries> ResearchNodeUpgradeNecessaries { get; set; }
        public DbSet<ResearchNodeUpgradeCondition> ResearchNodeUpgradeCondition { get; set; }
        public DbSet<PlayerTroop> PlayerTroop { get; set; }
        public DbSet<PlayerPrison> PlayerPrison { get; set; }
        public DbSet<PrisonLevel> PrisonLevel { get; set; }
        public DbSet<PlayerHospital> PlayerHospital { get; set; }
        public DbSet<HospitalLevel> HospitalLevel { get; set; }

        public DbSet<Hero> Hero { get; set; }
        public DbSet<PlayerHero> PlayerHero { get; set; }
        public DbSet<HeroLevelThreshold> HeroLevelThreshold { get; set; }
        public DbSet<HeroSkill> HeroSkill { get; set; }
        public DbSet<HeroSkillLevel> HeroSkillLevel { get; set; }
        public DbSet<PlayerHeroSkillLevel> PlayerHeroSkillLevel { get; set; }
        public DbSet<TalentTree> TalentTree { get; set; }
        public DbSet<TalentTreeNode> TalentTreeNode { get; set; }
        public DbSet<TalentTreeNodeLevel> TalentTreeNodeLevel { get; set; }
        public DbSet<PlayerTalentTreeNode> PlayerTalentTreeNode { get; set; }
        public DbSet<LootLevel> LootLevel { get; set; }
        public DbSet<PlayerHeroLoot> PlayerHeroLoot { get; set; }

        public DbSet<ItemCategory> ItemCategory { get; set; }
        public DbSet<ItemType> ItemType { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<PlayerItem> PlayerItem { get; set; }
        public DbSet<MarketItem> MarketItem { get; set; }
        public DbSet<PlayerMarketHistory> PlayerMarketHistory { get; set; }

        public DbSet<DialogScene> DialogScene { get; set; }
        public DbSet<Dialog> Dialog { get; set; }
        public DbSet<TutorialQuest> TutorialQuest { get; set; }
        public DbSet<TutorialQuestsGift> TutorialQuestsGift { get; set; }
        public DbSet<PlayerTutorialQuest> PlayerTutorialQuest { get; set; }
        public DbSet<BuildingUpgradeCondition> BuildingUpgradeCondition { get; set; }
        public DbSet<PlayerTDReward> PlayerTDReward { get; set; }
        public DbSet<PlayerTDRewardHistory> PlayerTDRewardHistory { get; set; }
        public DbSet<Scout> Scout { get; set; }
        public DbSet<Attack> Attack { get; set; }
        public DbSet<Rally> Rally { get; set; }
        public DbSet<RallyPart> RallyPart { get; set; }
        public DbSet<FirstTimeTutorial> FirstTimeTutorial { get; set; }
        public DbSet<SupportUnit> SupportUnit { get; set; }
        public DbSet<PlayerScout> PlayerScout { get; set; }
        public DbSet<ScoutLevel> ScoutLevel { get; set; }
        public DbSet<GateInfo> GateInfo { get; set; }
        




        public DbSet<Log> Log { get; set; }
        public DbSet<LogAction> LogAction { get; set; }

        #region Model Creator

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buff>().HasData(
                new Buff()
                {
                    Id = 1,
                    Description = "",
                    Name = "0-Buff"
                });

            #region PlayerBaseEntities
            modelBuilder.Entity<BuildingType>().HasData(
                new BuildingType() { Id = 1, Name = "Base", MaxLevel = 1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-5.png", IsActive = true },
                new BuildingType() { Id = 2, Name = "Gang Tower", MaxLevel = 1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true },
                new BuildingType() { Id = 3, Name = "Wall", MaxLevel = 1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true },
                new BuildingType() { Id = 4, Name = "Hospital", MaxLevel = 1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true },
                new BuildingType() { Id = 5, Name = "Prison", MaxLevel = 1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true },
                new BuildingType() { Id = 6, Name = "Market", MaxLevel = 1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png", IsActive = true },
                new BuildingType() { Id = 7, Name = "Altar", MaxLevel = 1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true },
                new BuildingType() { Id = 8, Name = "Watch Tower", MaxLevel = 1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true },
                new BuildingType() { Id = 9, Name = "Research Laboratory", MaxLevel = 1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true },
                new BuildingType() { Id = 10, Name = "Military Base", MaxLevel = 1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true }
            );
            modelBuilder.Entity<PlayerBasePlacement>().HasData(
                new PlayerBasePlacement() { Id = 1, BuildingTypeId = 1, BuildingLevel = 1, CoordX = 1, CoordY = 1, UpdateEndDate = null, UserId = 1 }
            );

            modelBuilder.Entity<ResearchTable>().HasData(
                new ResearchTable() { Id = 1, Name = "Military Research", ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png" },
                new ResearchTable() { Id = 2, Name = "Economical Research", ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png" },
                new ResearchTable() { Id = 3, Name = "General Research", ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png" },
                new ResearchTable() { Id = 4, Name = "Tower Defense Research", ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png" }
                );

            var c = 1;

            #endregion

            //    #region PrisonerEntities

            //    List<PrisonLevel> prisonLevels = new List<PrisonLevel>();
            //    for (int i = 1; i < 101; i++)
            //    {
            //        prisonLevels.Add(new PrisonLevel()
            //        {
            //            Id = i,
            //            Level = i,
            //            ExecutionEarnPerUnit = i * 1.2,
            //            MaxPrisonerCount = i * 5 - i,
            //            TrainingCostPerUnit = 100 / i,
            //            TrainingDurationPerUnit = new TimeSpan(6000000000 / i),
            //        });
            //    }
            //    modelBuilder.Entity<PrisonLevel>().HasData(
            //        prisonLevels);

            //    #endregion

            //    #region HospitalEntities

            //    List<HospitalLevel> hospitalLevels = new List<HospitalLevel>();
            //    for (int i = 1; i < 101; i++)
            //    {
            //        hospitalLevels.Add(new HospitalLevel()
            //        {
            //            Id = i,
            //            Level = i,
            //            HospitalCapacity = i * 10,
            //            HealingCostPerUnit = 100 / i,
            //            HealingDurationPerUnit = new TimeSpan(6000000000 / i)
            //        });
            //    }
            //    modelBuilder.Entity<HospitalLevel>().HasData(
            //        hospitalLevels);

            //    #endregion

            #region HeroEntities



            modelBuilder.Entity<Hero>().HasData(
                new Hero()
                {
                    Id = 1,
                    Name = "Zeus",
                    Description = "dummydescription",
                    Story = "Dummyherostory",
                    BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                    MaxLevel = 30,
                    ThemeColor = "#993333",
                    ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png",
                    IsApe = false,
                    IsActive = true
                },
                new Hero()
                {
                    Id = 2,
                    Name = "Hades",
                    Description = "Hadesdescription",
                    Story = "Hadesherostory",
                    BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                    MaxLevel = 30,
                    ThemeColor = "#2F4F4F",
                    ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-2-100x100.png",
                    IsApe = false,
                    IsActive = true
                },
                new Hero()
                {
                    Id = 3,
                    Name = "Poseidon",
                    Description = "Poseidondescription",
                    Story = "Poseidonherostory",
                    BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                    MaxLevel = 30,
                    ThemeColor = "#00FFFF",
                    ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-3-100x100.png",
                    IsApe = false,
                    IsActive = true
                },
                new Hero()
                {
                    Id = 4,
                    Name = "Odin",
                    Description = "Odindescription",
                    Story = "Odinherostory",
                    BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                    MaxLevel = 30,
                    ThemeColor = "#993333",
                    ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png",
                    IsApe = false,
                    IsActive = true
                },
                new Hero()
                {
                    Id = 5,
                    Name = "Thor",
                    Description = "Thordescription",
                    Story = "Thorherostory",
                    BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                    MaxLevel = 30,
                    ThemeColor = "#993333",
                    ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png",
                    IsApe = false,
                    IsActive = true
                },
                new Hero()
                {
                    Id = 6,
                    Name = "Hulk",
                    Description = "Smasher",
                    Story = "Hulkherostory",
                    BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                    MaxLevel = 30,
                    ThemeColor = "#006400",
                    ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png",
                    IsApe = true,
                    IsActive = true
                },
                new Hero()
                {
                    Id = 7,
                    Name = "Abomination",
                    Description = "Abominationdescription",
                    Story = "Abominationherostory",
                    BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                    MaxLevel = 30,
                    ThemeColor = "#7CFC00",
                    ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png",
                    IsApe = true,
                    IsActive = true
                },
                new Hero()
                {
                    Id = 8,
                    Name = "Dr. Octopus",
                    Description = "octopusdescription",
                    Story = "Octopusherostory",
                    BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                    MaxLevel = 30,
                    ThemeColor = "#778899",
                    ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png",
                    IsApe = true,
                    IsActive = true
                },
                new Hero()
                {
                    Id = 9,
                    Name = "Joker",
                    Description = "Just Joker",
                    Story = "Dramatic Hero Story",
                    BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                    MaxLevel = 30,
                    ThemeColor = "#FF8C00",
                    ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png",
                    IsApe = true,
                    IsActive = true
                },
                new Hero()
                {
                    Id = 10,
                    Name = "Black Noir",
                    Description = "Black Noir description",
                    Story = "Black Noir herostory",
                    BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                    MaxLevel = 30,
                    ThemeColor = "#000000",
                    ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png",
                    IsApe = true,
                    IsActive = true
                },
                new Hero()
                {
                    Id = 11,
                    Name = "Thanos",
                    Description = "Invinsible Gauntlet Lover",
                    Story = "Long Story",
                    BackgroundPictureUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg",
                    MaxLevel = 30,
                    ThemeColor = "#8A2BE2",
                    ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png",
                    IsApe = true,
                    IsActive = false
                }

            );


            //    List<HeroLevelThreshold> listThreshold = new List<HeroLevelThreshold>();
            //    c = 1;
            //    for (int i = 1; i < 12; i++)
            //    {
            //        long thresholdStart = 100;
            //        var autoThresholdPercent = 30;
            //        for (int k = 2; k < 51; k++)
            //        {
            //            listThreshold.Add(new HeroLevelThreshold()
            //            {
            //                Id = c,
            //                HeroId = i,
            //                Level = k,
            //                Experience = thresholdStart
            //            });
            //            thresholdStart += (long)((double)thresholdStart * ((double)autoThresholdPercent / 100));
            //            c++;
            //        }

            //    }

            //    modelBuilder.Entity<HeroLevelThreshold>().HasData(listThreshold);


            //    List<HeroSkill> heroSkills = new List<HeroSkill>();
            //    List<HeroSkillLevel> heroSkillLevels = new List<HeroSkillLevel>();
            //    c = 1;
            //    var cl = 1;
            //    for (int i = 1; i < 12; i++)
            //    {
            //        for (int k = 1; k < 5; k++)
            //        {
            //            heroSkills.Add(new HeroSkill()
            //            {
            //                Id = c,
            //                PlaceId = k,
            //                IsPassiveSkill = k == 1 ? false : true,
            //                Description = "dummy hero description",
            //                HeroId = i,
            //                MaksLevel = 5,
            //                Name = "HeroSkill_" + k,
            //                TumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png"

            //            });
            //            c++;
            //            for (int l = 1; l < 6; l++)
            //            {
            //                heroSkillLevels.Add(new HeroSkillLevel()
            //                {
            //                    Id = cl,
            //                    BuffId = 1,
            //                    HeroSkillId = c - 1,
            //                    Level = l
            //                });
            //                cl++;
            //            }
            //        }
            //    }

            //    modelBuilder.Entity<HeroSkill>().HasData(heroSkills);
            //    modelBuilder.Entity<HeroSkillLevel>().HasData(heroSkillLevels);





            //    modelBuilder.Entity<TalentTree>().HasData(
            //        new TalentTree() { Id = 1, Name = "Talent Tree _1_", ThemeColor = "#000000", BackgroundUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg" },
            //        new TalentTree() { Id = 2, Name = "Talent Tree _2_", ThemeColor = "#2f2f2f", BackgroundUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg" },
            //        new TalentTree() { Id = 3, Name = "Talent Tree _3_", ThemeColor = "#ffffff", BackgroundUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg" }
            //        );

            //    List<TalentTreeNode> talentTreeNodes = new List<TalentTreeNode>();
            //    c = 1;
            //    for (int h = 1; h < 12; h++)
            //    {
            //        for (int tt = 1; tt < 4; tt++)
            //        {
            //            for (int n = 1; n < 34; n++)
            //            {
            //                var node = new TalentTreeNode() { Id = c, Name = "node_" + n.ToString(), PlaceId = n, Capacity = 5, Description = "dummynodedescription", HeroId = h, TalentTreeId = tt, ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", BuffId = 1, IsActive = true };
            //                talentTreeNodes.Add(node);
            //                c++;
            //            }
            //        }
            //    }
            //    modelBuilder.Entity<TalentTreeNode>().HasData(talentTreeNodes);






            #endregion

            //    #region LootLevel
            //    List<LootLevel> lootLevels = new List<LootLevel>();
            //    for (int i = 1; i < 101; i++)
            //    {
            //        lootLevels.Add(new LootLevel()
            //        {
            //            Id = i,
            //            MinBlueprintCount = i,
            //            MaxBlueprintCount = i+((int)(i * 0.5)),
            //            MinGemCount = i,
            //            MaxGemCount = i + ((int)(i * 0.2)),
            //            MinScrapCount = i,
            //            MaxScrapCount = (i + ((int)(i * 0.5)))*10,
            //            LootDuration = new TimeSpan(0, 1, 0) * i / 2
            //        });
            //    }
            //    modelBuilder.Entity<LootLevel>().HasData(lootLevels);
            //    #endregion
        }

        public async Task<PlayerBaseInfo?> GetPlayerBaseInfoByUser(UserDto user)
        {
            var playerBaseInfo = await PlayerBaseInfo.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
            if (playerBaseInfo == null)
            {
                playerBaseInfo = new PlayerBaseInfo()
                {
                    BaseLevel = 1,
                    BluePrints = 1,
                    Gems = 5000,
                    BaseFullDuration = new TimeSpan(10, 0, 0),//TODO: Confige alınacak
                    Fuel = 100,
                    ResourceProductionPerHour = 1000,//TODO: SONRADAN Değiştirilebilecek
                    RareHeroCards = 0,
                    EpicHeroCards = 0,
                    LegendaryHeroCards = 0,
                    LastBaseCollect = DateTimeOffset.Now,
                    Scraps = 10000,
                    UserId = user.Id,
                    Username = user.Username,
                    IsApe = false,
                    Bio = "-",
                    AvatarId = 0
                };
                var playerTroop = await PlayerTroop.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (playerTroop==null)
                {
                    var ent = new PlayerTroop()
                    {
                        UserId = user.Id,
                        TroopCount = 0,
                        LastTroopCollect = DateTimeOffset.Now-TimeSpan.FromHours(13),
                        MaxDuration = TimeSpan.FromHours(12),
                        TrainingPerHour = 100
                    };
                    await AddAsync(ent);
                }                
                var playerHospital = await PlayerHospital.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (playerHospital==null)
                {
                    var ent = new PlayerHospital()
                    {
                        HospitalLevelId = 1,
                        InjuredCount = 0,
                        InHealingCount = 0,
                        HealingDoneDate = null,
                        UserId = user.Id
                    };
                    await AddAsync(ent);
                }                
                var playerScout = await PlayerScout.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (playerScout==null)
                {
                    var ent = new PlayerScout()
                    {
                        ScoutLevelId = 1,
                        SpyCount = 0,
                        InTrainingCount = 0,
                        TrainingDoneDate = null,
                        UserId = user.Id
                    };
                    await AddAsync(ent);
                }                
                var playerPrison = await PlayerPrison.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (playerPrison==null)
                {
                    var ent = new PlayerPrison()
                    {
                        PrisonLevelId = 1,
                        PrisonerCount = 0,
                        InTrainingPrisonerCount = 0,
                        TrainingDoneDate = null,
                        UserId = user.Id
                    };
                    await AddAsync(ent);
                }
                await AddAsync(playerBaseInfo);
                await SaveChangesAsync();
            }

            if (playerBaseInfo.Username!=user.Username)
            {
                playerBaseInfo.Username = user.Username;
                await SaveChangesAsync();
            }

            #region Resource Addition

            if ((DateTimeOffset.Now - playerBaseInfo.LastBaseCollect).TotalMilliseconds >= (new TimeSpan(0, 1, 0)).TotalMilliseconds)
            {

                var duration = DateTimeOffset.Now - playerBaseInfo.LastBaseCollect;
                duration = playerBaseInfo.BaseFullDuration < duration ? playerBaseInfo.BaseFullDuration : duration;
                var buffs = await BuffHelper.GetPlayersTotalBuff(user.Id);
                playerBaseInfo.Fuel += (int)(duration.TotalHours * playerBaseInfo.ResourceProductionPerHour);
                playerBaseInfo.Scraps += (int)(duration.TotalHours * (playerBaseInfo.ResourceProductionPerHour + (playerBaseInfo.ResourceProductionPerHour * buffs.ScrapProductionSpeedMultiplier)));
                var playerPrison = await PlayerPrison.Where(l => l.UserId == user.Id).FirstOrDefaultAsync();
                if (playerPrison!=null)
                {
                    
                    playerBaseInfo.Scraps -= (int)(duration.TotalHours * (playerPrison.PrisonerCount +
                                                                          (playerPrison.PrisonerCount *
                                                                           buffs.PrisonCostMultiplier)));
                    playerBaseInfo.Scraps = playerBaseInfo.Scraps < 0 ? 0 : playerBaseInfo.Scraps;
                }
                
                playerBaseInfo.LastBaseCollect = DateTimeOffset.Now;

                await SaveChangesAsync();
            }

            #endregion

            return playerBaseInfo;
        }
        public async Task<PlayerBaseInfo?> GetPlayerBaseInfoByUserId(long userId)
        {
            var playerBaseInfo = await PlayerBaseInfo.Where(l => l.UserId == userId).FirstOrDefaultAsync();
            if (playerBaseInfo==null)
            {
                return null;
            }
            #region Resource Addition

            if ((DateTimeOffset.Now - playerBaseInfo.LastBaseCollect).TotalMilliseconds >= (new TimeSpan(0, 1, 0)).TotalMilliseconds)
            {
                var duration = DateTimeOffset.Now - playerBaseInfo.LastBaseCollect;
                duration = playerBaseInfo.BaseFullDuration < duration ? playerBaseInfo.BaseFullDuration : duration;
                var buffs = await BuffHelper.GetPlayersTotalBuff(userId);
                playerBaseInfo.Fuel += (int)(duration.TotalHours * playerBaseInfo.ResourceProductionPerHour);
                playerBaseInfo.Scraps += (int)(duration.TotalHours * (playerBaseInfo.ResourceProductionPerHour + (playerBaseInfo.ResourceProductionPerHour * buffs.ScrapProductionSpeedMultiplier)));
                var playerPrison = await PlayerPrison.Where(l => l.UserId == userId).FirstOrDefaultAsync();
                if (playerPrison!=null)
                {

                    playerBaseInfo.Scraps -= (int)(duration.TotalHours * (playerPrison.PrisonerCount +
                                                                          (playerPrison.PrisonerCount *
                                                                           buffs.PrisonCostMultiplier)));
                    playerBaseInfo.Scraps = playerBaseInfo.Scraps < 0 ? 0 : playerBaseInfo.Scraps;
                }
                playerBaseInfo.LastBaseCollect = DateTimeOffset.Now;

                await SaveChangesAsync();
            }

            #endregion

            return playerBaseInfo;
        }

        public void CreateHeroLevelBuffs()
        {
            var query = HeroLevelThreshold.Include(l => l.Hero).Include(l => l.Buff).OrderBy(l => l.Level).ToList();
            foreach (var hl in query)
            {
                double k = 0;
                double l = 0;

                switch (hl.Hero.Rarity)
                {
                    case (int)HeroRarity.Rare:
                        k = 0.01;
                        l = 1.05;
                        break;
                    case (int)HeroRarity.Epic:
                        k = 0.012;
                        l = 1.10;
                        break;
                    case (int)HeroRarity.Legendary:
                        k = 0.014;
                        l = 1.20;
                        break;
                }
                hl.Buff.LootBluePrintMultiplier = Math.Round(k * hl.Level, 4);
                hl.Buff.LootScrapMultiplier = Math.Round(l * hl.Level, 2);
                SaveChanges();
            }
        }
        #endregion
    }
}
