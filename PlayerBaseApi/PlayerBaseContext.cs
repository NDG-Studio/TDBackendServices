
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

        public DbSet<BuildingType> BuildingType { get; set; }
        public DbSet<PlayerBasePlacement> PlayerBasePlacement { get; set; }
        public DbSet<PlayerBaseInfo> PlayerBaseInfo { get; set; }
        public DbSet<BuildingUpdateTime> BuildingUpdateTime { get; set; }

        public DbSet<Hero> Hero { get; set; }
        public DbSet<PlayerHero> PlayerHero { get; set; }
        public DbSet<HeroLevelThreshold> HeroLevelThreshold { get; set; }
        public DbSet<TalentTree> TalentTree { get; set; }
        public DbSet<TalentTreeNode> TalentTreeNode { get; set; }
        public DbSet<PlayerTalentTreeNode> PlayerTalentTreeNode { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<LogAction> LogAction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                new BuildingType() { Id = 9, Name = "Research Laboratory", MaxLevel = 1000, BuildUrl = "https://gaming.ndgstudio.com.tr/wp-content/uploads/2021/09/h1-client-img-4.png", IsActive = true }
            );
            modelBuilder.Entity<PlayerBasePlacement>().HasData(
                new PlayerBasePlacement() { Id = 1, BuildingTypeId = 1, BuildingLevel = 1, CoordX = 1, CoordY = 1, UpdateEndDate = null, UserId = 1 }
            );

            modelBuilder.Entity<BuildingUpdateTime>().HasData(
                new BuildingUpdateTime() { Id = 1, BuildingTypeId = 1, Level = 2, UpdateDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpdateTime() { Id = 2, BuildingTypeId = 2, Level = 2, UpdateDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpdateTime() { Id = 3, BuildingTypeId = 3, Level = 2, UpdateDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpdateTime() { Id = 4, BuildingTypeId = 4, Level = 2, UpdateDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpdateTime() { Id = 5, BuildingTypeId = 5, Level = 2, UpdateDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpdateTime() { Id = 6, BuildingTypeId = 6, Level = 2, UpdateDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpdateTime() { Id = 7, BuildingTypeId = 7, Level = 2, UpdateDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpdateTime() { Id = 8, BuildingTypeId = 8, Level = 2, UpdateDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpdateTime() { Id = 9, BuildingTypeId = 9, Level = 2, UpdateDuration = new TimeSpan(0, 2, 0) },
                new BuildingUpdateTime() { Id = 10, BuildingTypeId = 1, Level = 3, UpdateDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpdateTime() { Id = 11, BuildingTypeId = 2, Level = 3, UpdateDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpdateTime() { Id = 12, BuildingTypeId = 3, Level = 3, UpdateDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpdateTime() { Id = 13, BuildingTypeId = 4, Level = 3, UpdateDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpdateTime() { Id = 14, BuildingTypeId = 5, Level = 3, UpdateDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpdateTime() { Id = 15, BuildingTypeId = 6, Level = 3, UpdateDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpdateTime() { Id = 16, BuildingTypeId = 7, Level = 3, UpdateDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpdateTime() { Id = 17, BuildingTypeId = 8, Level = 3, UpdateDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpdateTime() { Id = 18, BuildingTypeId = 9, Level = 3, UpdateDuration = new TimeSpan(0, 5, 0) },
                new BuildingUpdateTime() { Id = 19, BuildingTypeId = 1, Level = 4, UpdateDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpdateTime() { Id = 20, BuildingTypeId = 2, Level = 4, UpdateDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpdateTime() { Id = 21, BuildingTypeId = 3, Level = 4, UpdateDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpdateTime() { Id = 22, BuildingTypeId = 4, Level = 4, UpdateDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpdateTime() { Id = 23, BuildingTypeId = 5, Level = 4, UpdateDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpdateTime() { Id = 24, BuildingTypeId = 6, Level = 4, UpdateDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpdateTime() { Id = 25, BuildingTypeId = 7, Level = 4, UpdateDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpdateTime() { Id = 26, BuildingTypeId = 8, Level = 4, UpdateDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpdateTime() { Id = 27, BuildingTypeId = 9, Level = 4, UpdateDuration = new TimeSpan(0, 10, 0) },
                new BuildingUpdateTime() { Id = 28, BuildingTypeId = 1, Level = 5, UpdateDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpdateTime() { Id = 29, BuildingTypeId = 2, Level = 5, UpdateDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpdateTime() { Id = 30, BuildingTypeId = 3, Level = 5, UpdateDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpdateTime() { Id = 31, BuildingTypeId = 4, Level = 5, UpdateDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpdateTime() { Id = 32, BuildingTypeId = 5, Level = 5, UpdateDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpdateTime() { Id = 33, BuildingTypeId = 6, Level = 5, UpdateDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpdateTime() { Id = 34, BuildingTypeId = 7, Level = 5, UpdateDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpdateTime() { Id = 35, BuildingTypeId = 8, Level = 5, UpdateDuration = new TimeSpan(0, 30, 0) },
                new BuildingUpdateTime() { Id = 36, BuildingTypeId = 9, Level = 5, UpdateDuration = new TimeSpan(0, 30, 0) }
            );
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
            var c = 1;
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

            #endregion
        }
    }
}
