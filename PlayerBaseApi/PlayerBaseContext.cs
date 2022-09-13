
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
        public DbSet<Log> Log { get; set; }
        public DbSet<LogAction> LogAction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

        }
    }
}
