
using Microsoft.EntityFrameworkCore;
using PlayerBaseApi.Entities;
using SharedLibrary.Entities;

namespace PlayerBaseApi
{
    public class PlayerBaseContext : DbContext
    {
        public PlayerBaseContext(DbContextOptions<PlayerBaseContext> options) : base(options) { }

        public PlayerBaseContext()
        {
            Database.Migrate();
        }

        public DbSet<Buff> Buff { get; set; }
        public DbSet<BuildingType> BuildingType { get; set; }
        public DbSet<PlayerBasePlacement> PlayerBasePlacement { get; set; }
        public DbSet<PlayerBaseInfo> PlayerBaseInfo { get; set; }
        public DbSet<BuildingUpgradeTime> BuildingUpgradeTime { get; set; }
        public DbSet<ResearchTable> ResearchTable { get; set; }
        public DbSet<ResearchNode> ResearchNode { get; set; }
        public DbSet<PlayerResearchNode> PlayerResearchNode { get; set; }
        public DbSet<ResearchNodeUpgradeNecessaries> ResearchNodeUpgradeNecessaries { get; set; }
        public DbSet<PlayerTroop> PlayerTroop { get; set; }
        public DbSet<PlayerPrison> PlayerPrison { get; set; }

        public DbSet<Hero> Hero { get; set; }
        public DbSet<PlayerHero> PlayerHero { get; set; }
        public DbSet<HeroLevelThreshold> HeroLevelThreshold { get; set; }
        public DbSet<HeroSkill> HeroSkill { get; set; }
        public DbSet<HeroSkillLevel> HeroSkillLevel { get; set; }
        public DbSet<PlayerHeroSkillLevel> PlayerHeroSkillLevel { get; set; }
        public DbSet<TalentTree> TalentTree { get; set; }
        public DbSet<TalentTreeNode> TalentTreeNode { get; set; }
        public DbSet<PlayerTalentTreeNode> PlayerTalentTreeNode { get; set; }
        public DbSet<LootLevel> LootLevel { get; set; }
        public DbSet<PlayerHeroLoot> PlayerHeroLoot { get; set; }


        public DbSet<Log> Log { get; set; }
        public DbSet<LogAction> LogAction { get; set; }

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

            modelBuilder.Entity<BuildingUpgradeTime>().HasData(
                new BuildingUpgradeTime() { Id = 1, BuildingTypeId = 1, Level = 2, UpgradeDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpgradeTime() { Id = 2, BuildingTypeId = 2, Level = 2, UpgradeDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpgradeTime() { Id = 3, BuildingTypeId = 3, Level = 2, UpgradeDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpgradeTime() { Id = 4, BuildingTypeId = 4, Level = 2, UpgradeDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpgradeTime() { Id = 5, BuildingTypeId = 5, Level = 2, UpgradeDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpgradeTime() { Id = 6, BuildingTypeId = 6, Level = 2, UpgradeDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpgradeTime() { Id = 7, BuildingTypeId = 7, Level = 2, UpgradeDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpgradeTime() { Id = 8, BuildingTypeId = 8, Level = 2, UpgradeDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpgradeTime() { Id = 9, BuildingTypeId = 9, Level = 2, UpgradeDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpgradeTime() { Id = 10, BuildingTypeId = 1, Level = 3, UpgradeDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpgradeTime() { Id = 11, BuildingTypeId = 2, Level = 3, UpgradeDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpgradeTime() { Id = 12, BuildingTypeId = 3, Level = 3, UpgradeDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpgradeTime() { Id = 13, BuildingTypeId = 4, Level = 3, UpgradeDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpgradeTime() { Id = 14, BuildingTypeId = 5, Level = 3, UpgradeDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpgradeTime() { Id = 15, BuildingTypeId = 6, Level = 3, UpgradeDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpgradeTime() { Id = 16, BuildingTypeId = 7, Level = 3, UpgradeDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpgradeTime() { Id = 17, BuildingTypeId = 8, Level = 3, UpgradeDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpgradeTime() { Id = 18, BuildingTypeId = 9, Level = 3, UpgradeDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpgradeTime() { Id = 19, BuildingTypeId = 1, Level = 4, UpgradeDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpgradeTime() { Id = 20, BuildingTypeId = 2, Level = 4, UpgradeDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpgradeTime() { Id = 21, BuildingTypeId = 3, Level = 4, UpgradeDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpgradeTime() { Id = 22, BuildingTypeId = 4, Level = 4, UpgradeDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpgradeTime() { Id = 23, BuildingTypeId = 5, Level = 4, UpgradeDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpgradeTime() { Id = 24, BuildingTypeId = 6, Level = 4, UpgradeDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpgradeTime() { Id = 25, BuildingTypeId = 7, Level = 4, UpgradeDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpgradeTime() { Id = 26, BuildingTypeId = 8, Level = 4, UpgradeDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpgradeTime() { Id = 27, BuildingTypeId = 9, Level = 4, UpgradeDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpgradeTime() { Id = 28, BuildingTypeId = 1, Level = 5, UpgradeDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpgradeTime() { Id = 29, BuildingTypeId = 2, Level = 5, UpgradeDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpgradeTime() { Id = 30, BuildingTypeId = 3, Level = 5, UpgradeDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpgradeTime() { Id = 31, BuildingTypeId = 4, Level = 5, UpgradeDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpgradeTime() { Id = 32, BuildingTypeId = 5, Level = 5, UpgradeDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpgradeTime() { Id = 33, BuildingTypeId = 6, Level = 5, UpgradeDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpgradeTime() { Id = 34, BuildingTypeId = 7, Level = 5, UpgradeDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpgradeTime() { Id = 35, BuildingTypeId = 8, Level = 5, UpgradeDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpgradeTime() { Id = 36, BuildingTypeId = 9, Level = 5, UpgradeDuration = new TimeSpan(0, 30, 0) }
            );

            modelBuilder.Entity<ResearchTable>().HasData(
                new ResearchTable() { Id = 1, Name = "Military Research", ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png" },
                new ResearchTable() { Id = 2, Name = "Economical Research", ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png" },
                new ResearchTable() { Id = 3, Name = "General Research", ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png" },
                new ResearchTable() { Id = 4, Name = "Tower Defense Research", ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-6.png" }
                );

            var c = 1;
            var researchNodeList = new List<ResearchNode>();
            for (int i = 1; i < 5; i++)
            {
                for (int l = 1; l < 6; l++)
                {
                    researchNodeList.Add(new ResearchNode()
                    {
                        Id = c,
                        BuffId = 1,
                        Name = "Node_" + l.ToString(),
                        Description = "research description",
                        Capacity = 5,
                        PlaceId = l,
                        ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png",
                        ResearchTableId = i,
                        IsActive = true
                    });
                    c++;
                }
            }

            modelBuilder.Entity<ResearchNode>().HasData(
                researchNodeList
                );

            var researchNodeUpgradeNecessaries = new List<ResearchNodeUpgradeNecessaries>();
            c = 1;
            for (int i = 1; i < 21; i++)
            {
                for (int l = 1; l < 6; l++)
                {
                    researchNodeUpgradeNecessaries.Add(new ResearchNodeUpgradeNecessaries()
                    {
                        Id = c,
                        BluePrintCount = l * 10,
                        Duration = new TimeSpan(0, 0, l * 2, 0),
                        ResearchNodeId = i,
                        ScrapCount = l * 100,
                        UpgradeLevel = l
                    });
                    c++;
                }
            }

            modelBuilder.Entity<ResearchNodeUpgradeNecessaries>().HasData(
                researchNodeUpgradeNecessaries
            );

            #endregion

            #region PrisonerEntities

            List<PrisonLevel> prisonLevels = new List<PrisonLevel>();
            for (int i = 1; i < 101; i++)
            {
                prisonLevels.Add(new PrisonLevel()
                {
                    Id = i,
                    Level = i,
                    ExecutionEarnPerUnit = i * 1.2,
                    MaxPrisonerCount = i * 5 - i,
                    TrainingCostPerUnit = 100 / i,
                    TrainingDurationPerUnit = new TimeSpan(6000000000 / i),
                });
            }
            modelBuilder.Entity<PrisonLevel>().HasData(
                prisonLevels);

            #endregion

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


            List<HeroLevelThreshold> listThreshold = new List<HeroLevelThreshold>();
            c = 1;
            for (int i = 1; i < 12; i++)
            {
                long thresholdStart = 100;
                var autoThresholdPercent = 30;
                for (int k = 2; k < 51; k++)
                {
                    listThreshold.Add(new HeroLevelThreshold()
                    {
                        Id = c,
                        HeroId = i,
                        Level = k,
                        Experience = thresholdStart
                    });
                    thresholdStart += (long)((double)thresholdStart * ((double)autoThresholdPercent / 100));
                    c++;
                }

            }

            modelBuilder.Entity<HeroLevelThreshold>().HasData(listThreshold);


            List<HeroSkill> heroSkills = new List<HeroSkill>();
            List<HeroSkillLevel> heroSkillLevels = new List<HeroSkillLevel>();
            c = 1;
            var cl = 1;
            for (int i = 1; i < 12; i++)
            {
                for (int k = 1; k < 5; k++)
                {
                    heroSkills.Add(new HeroSkill()
                    {
                        Id = c,
                        PlaceId = k,
                        IsPassiveSkill = k == 1 ? false : true,
                        Description = "dummy hero description",
                        HeroId = i,
                        MaksLevel = 5,
                        Name = "HeroSkill_" + k,
                        TumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2018/06/h2-custom-icon-img-1.png"

                    });
                    c++;
                    for (int l = 1; l < 6; l++)
                    {
                        heroSkillLevels.Add(new HeroSkillLevel()
                        {
                            Id = cl,
                            BuffId = 1,
                            HeroSkillId = c - 1,
                            Level = l
                        });
                        cl++;
                    }
                }
            }

            modelBuilder.Entity<HeroSkill>().HasData(heroSkills);
            modelBuilder.Entity<HeroSkillLevel>().HasData(heroSkillLevels);





            modelBuilder.Entity<TalentTree>().HasData(
                new TalentTree() { Id = 1, Name = "Talent Tree _1_", ThemeColor = "#000000", BackgroundUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg" },
                new TalentTree() { Id = 2, Name = "Talent Tree _2_", ThemeColor = "#2f2f2f", BackgroundUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg" },
                new TalentTree() { Id = 3, Name = "Talent Tree _3_", ThemeColor = "#ffffff", BackgroundUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2022/09/Background-min-scaled.jpg" }
                );

            List<TalentTreeNode> talentTreeNodes = new List<TalentTreeNode>();
            c = 1;
            for (int h = 1; h < 12; h++)
            {
                for (int tt = 1; tt < 4; tt++)
                {
                    for (int n = 1; n < 34; n++)
                    {
                        var node = new TalentTreeNode() { Id = c, Name = "node_" + n.ToString(), PlaceId = n, Capacity = 5, Description = "dummynodedescription", HeroId = h, TalentTreeId = tt, ThumbnailUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", BuffId = 1, IsActive = true };
                        talentTreeNodes.Add(node);
                        c++;
                    }
                }
            }
            modelBuilder.Entity<TalentTreeNode>().HasData(talentTreeNodes);






            #endregion

            #region LootLevel
            List<LootLevel> lootLevels = new List<LootLevel>();
            for (int i = 1; i < 101; i++)
            {
                lootLevels.Add(new LootLevel()
                {
                    Id = i,
                    MinBlueprintCount = i,
                    MaxBlueprintCount = i+((int)(i * 0.5)),
                    MinGemCount = i,
                    MaxGemCount = i + ((int)(i * 0.2)),
                    MinScrapCount = i,
                    MaxScrapCount = (i + ((int)(i * 0.5)))*10,
                    LootDuration = new TimeSpan(0, 1, 0) * i / 2
                });
            }
            modelBuilder.Entity<LootLevel>().HasData(lootLevels);
            #endregion
        }
    }
}
